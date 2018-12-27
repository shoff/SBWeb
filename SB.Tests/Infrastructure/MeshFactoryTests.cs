namespace SB.Tests.Infrastructure
{
    using System;
    using AutoFixture;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Moq;
    using SB.Domain;
    using SB.Domain.Configuration;
    using SB.Infrastructure;
    using Xunit;

    public class MeshFactoryTests : BaseTest, IDisposable
    {
        private readonly Archives archives;
        private readonly Mock<IOptions<Archives>> options;
        private readonly Mock<ILogger<CacheArchive>> meshLogger;
        private readonly MeshArchive meshArchive;
        private readonly Mock<ILogger<MeshFactory>> logger;
        private readonly MeshFactory meshFactory;

        public MeshFactoryTests()
        {
            this.archives = this.fixture.Create<Archives>();
            this.options = new Mock<IOptions<Archives>>();
            this.meshLogger = new Mock<ILogger<CacheArchive>>();

            this.archives.CacheFolder = ".\\cache\\";
            this.options.SetupGet(archive => archive.Value).Returns(this.archives);

            this.meshArchive = new MeshArchive(this.options.Object, this.meshLogger.Object);
            this.meshArchive.LoadIndexes();
            this.logger = new Mock<ILogger<MeshFactory>>();
            this.meshFactory = new MeshFactory(this.meshArchive, this.logger.Object);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(20)]
        [InlineData(21)]
        [InlineData(22)]
        [InlineData(23)]
        [InlineData(24)]
        [InlineData(25)]
        [InlineData(26)]
        [InlineData(27)]
        [InlineData(28)]
        [InlineData(200)]
        [InlineData(201)]
        [InlineData(203)]
        [InlineData(342)]
        [InlineData(542)]
        [InlineData(562)]
        [InlineData(772)]
        [InlineData(572)]
        [InlineData(456)]
        [InlineData(4564)]
        [InlineData(21234)]
        [InlineData(22222)]
        public void Create_With_Valid_Id_Creates_Mesh(int indexId)
        {
            var index = this.meshArchive.GetIdentityAtIndexOf(indexId);
            var mesh = this.meshFactory.Create(index);
            Assert.NotNull(mesh);
        } 

        public void Dispose()
        {
            this.meshArchive?.Dispose();
        }


    }
}