namespace SB.Tests.Domain
{
    using AutoFixture;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Moq;
    using SB.Domain;
    using SB.Domain.Configuration;
    using Xunit;

    public class RenderArchiveTests : BaseTest
    {
        private readonly Archives archives;
        private readonly Mock<IOptions<Archives>> options;
        private readonly Mock<ILogger<CacheArchive>> logger;
        private readonly RenderArchive renderArchive;

        public RenderArchiveTests()
        {
            this.archives = this.fixture.Create<Archives>();
            this.options = new Mock<IOptions<Archives>>();
            this.logger = new Mock<ILogger<CacheArchive>>();
            this.archives.CacheFolder = ".\\cache\\";
            this.options.SetupGet(archive => archive.Value).Returns(this.archives);
            this.renderArchive = new RenderArchive(this.options.Object, this.logger.Object);
        }

        [Fact]
        public void Constructor_Sets_Name_To_Mesh_Cache()
        {
            Assert.Equal("Render.cache", this.renderArchive.Name);
        }

        [Fact]
        public void LoadCacheHeader_Should_Load_The_Correct_Information()
        {
            this.renderArchive.LoadCacheHeader();

            Assert.Equal((uint)4294967295, this.renderArchive.CacheHeader.junk1);
            Assert.Equal((uint)3675552, this.renderArchive.CacheHeader.fileSize);
            Assert.Equal((uint)835576, this.renderArchive.CacheHeader.dataOffset);
            Assert.Equal((uint)41778, this.renderArchive.CacheHeader.indexCount);
        }

        [Fact]
        public void High_Forty_Thousand_Render_Id_Is_Valid()
        {
            this.renderArchive.LoadIndexes();
            var identity = this.renderArchive.GetIdentityAtIndexOf(41000);
            var renderObject = this.renderArchive[identity];
            Assert.NotNull(renderObject);
        }
    }
}