namespace SB.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Security.Claims;
    using System.Security.Principal;
    using AutoFixture;
    using AutoFixture.Kernel;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Moq;

    /// <summary>
    ///     The most basic test class, with inversion of control functionality
    /// </summary>
    public abstract class BaseTest
    {
        /// <summary>
        ///     AutoFixture is an open source library for .NET designed to minimize the 'Arrange'
        ///     phase of your unit tests in order to maximize maintainability. Its primary goal is to
        ///     allow developers to focus on what is being tested rather than how to setup the test
        ///     scenario, by making it easier to create object graphs containing test data.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected IFixture fixture;

        protected BaseTest()
        {
            this.fixture = new Fixture().Customize(new DoNotFillCollectionProperties());
            this.fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => this.fixture.Behaviors.Remove(b));
            this.fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }

    public class CollectionPropertyOmitter : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi != null
                && pi.PropertyType.IsGenericType
                && pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
            {
                return new OmitSpecimen();
            }

            return new NoSpecimen();
        }
    }

    public abstract class ControllerBaseTests : BaseTest
    {
        protected readonly Mock<ITempDataDictionary> tempDataDictionary;
        protected readonly Mock<IServiceProvider> requestServices;
        protected readonly Mock<IUrlHelper> urlHelper;
        protected ControllerContext controllerContext;
        protected IPrincipal user;

        protected ControllerBaseTests()
        {
            this.tempDataDictionary = new Mock<ITempDataDictionary>();
            this.requestServices = new Mock<IServiceProvider>();
            this.urlHelper = new Mock<IUrlHelper>();
            this.SetupMocks();
        }

        private void SetupMocks()
        {
            // this.controller.Url = this.urlHelper.Object;
            var identity = new FakeClaimsIdentity();
            this.user = new FakePrincipal(identity, new string[0]);

            var httpContext = new DefaultHttpContext
            {
                User = (ClaimsPrincipal)this.user,
                RequestServices = this.requestServices.Object,
            };
            httpContext.Connection.LocalIpAddress = System.Net.IPAddress.Parse("127.0.0.1");
            httpContext.Connection.RemoteIpAddress = System.Net.IPAddress.Parse("127.0.0.1");

            this.controllerContext = new ControllerContext { HttpContext = httpContext };
        }
    }

    public class DoNotFill<T> : ICustomization
        where T : class
    {
        /// <summary>
        ///     Customizes the specified fixture.
        /// </summary>
        /// <param name="fixture">The fixture to customize.</param>
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new IgnoreSpecimen<T>());
        }
    }


    public class DoNotFillCollectionProperties : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new CollectionPropertyOmitter());
        }
    }



    public class IgnoreSpecimen<T> : ISpecimenBuilder
        where T : class
    {
        /// <summary>
        ///     Creates a new specimen based on a request.
        /// </summary>
        /// <param name="request">The request that describes what to create.</param>
        /// <param name="context">A context that can be used to create other specimens.</param>
        /// <returns>
        ///     The requested specimen if possible; otherwise a <see cref="T:Ploeh.AutoFixture.Kernel.NoSpecimen" /> instance.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The <paramref name="request" /> can be any object, but will often be a
        ///         <see cref="T:System.Type" /> or other <see cref="T:System.Reflection.MemberInfo" /> instances.
        ///     </para>
        ///     <para>
        ///         Note to implementers: Implementations are expected to return a
        ///         <see cref="T:Ploeh.AutoFixture.Kernel.NoSpecimen" /> instance if they can't satisfy the request.
        ///     </para>
        /// </remarks>
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi != null && pi.PropertyType == typeof(T))
            {
                return new OmitSpecimen();
            }

            return new NoSpecimen();
        }
    }

    public class FakePrincipal : GenericPrincipal
    {
        public List<Claim> claims = new List<Claim>
        {
            new Claim("sub", "username"),
            new Claim(ClaimTypes.Email, "god@ems.com"),
            new Claim(ClaimTypes.Country, "USA"),
            new Claim(ClaimTypes.NameIdentifier, "Joe_DumbAsShit")
        };

        public FakePrincipal(IIdentity identity, string[] roles)
            : base(identity, roles)
        {
            this.Identity = identity;
        }

        public new IIdentity Identity { get; set; }

        public void AddClaim(Claim claim)
        {
            this.claims.Add(claim);
        }

        public override Claim FindFirst(string type)
        {
            return this.claims.FirstOrDefault(c => c.Type == type);
        }

        public override IEnumerable<Claim> Claims => this.claims;
    }

    public class FakeClaimsIdentity : ClaimsIdentity
    {
        private readonly bool isAuthenticated;

        public FakeClaimsIdentity(bool isAuthenticated = false)
        {
            this.isAuthenticated = isAuthenticated;
        }

        // ReSharper disable once ConvertToAutoProperty
        public override bool IsAuthenticated => this.isAuthenticated;

        public override Claim FindFirst(string type)
        {
            return new Claim("type", "da-fuck", "10-dollar", "fucky-sucky");
        }
    }
}