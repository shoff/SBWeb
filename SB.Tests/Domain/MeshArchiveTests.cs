namespace SB.Tests.Domain
{
    using AutoFixture;
    using BenchmarkDotNet.Running;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Moq;
    using SB.Domain;
    using SB.Domain.Configuration;
    using SB.Domain.Extensions;
    using Xunit;

    public class MeshArchiveTests : BaseTest
    {
        private readonly Archives archives;
        private readonly Mock<IOptions<Archives>> options;
        private readonly Mock<ILogger<CacheArchive>> logger;
        private readonly MeshArchive meshArchive;
        
        public MeshArchiveTests()
        {
            this.archives = this.fixture.Create<Archives>();
            this.options = new Mock<IOptions<Archives>>();
            this.logger = new Mock<ILogger<CacheArchive>>();

            this.archives.CacheFolder = ".\\cache\\";
            this.options.SetupGet(archive => archive.Value).Returns(this.archives);

            this.meshArchive = new MeshArchive(this.options.Object, this.logger.Object);
        }


        [Fact]
        public void Constructor_Sets_Name_To_Mesh_Cache()
        {
            Assert.Equal("Mesh.cache", this.meshArchive.Name);
        }

        [Fact]
        public void LoadCacheHeader_Should_Load_The_Correct_Information()
        {
            //this.cacheHeader.indexCount = reader.ReadUInt32();
            //this.cacheHeader.dataOffset = reader.ReadUInt32();
            //this.cacheHeader.fileSize = reader.ReadUInt32();
            //this.cacheHeader.junk1 = reader.ReadUInt32();

            this.meshArchive.LoadCacheHeader();

            Assert.Equal((uint)4294967295, this.meshArchive.CacheHeader.junk1);
            Assert.Equal((uint)37232460, this.meshArchive.CacheHeader.fileSize);
            Assert.Equal((uint)487756, this.meshArchive.CacheHeader.dataOffset);
            Assert.Equal((uint)24387, this.meshArchive.CacheHeader.indexCount);
        }

        [Fact]
        public void LoadingCacheHeader_As_Slice_Returns_Same_Values()
        {
            CacheHeader header = new CacheHeader();
            using (var reader = this.meshArchive.Data.Slice(0, 16).ToArray().CreateBinaryReaderUtf32())
            {
                header.indexCount = reader.ReadUInt32();
                header.dataOffset = reader.ReadUInt32();
                header.fileSize = reader.ReadUInt32();
                header.junk1 = reader.ReadUInt32();
            }

            this.meshArchive.LoadCacheHeader();

            Assert.Equal(meshArchive.CacheHeader.indexCount, header.indexCount);
            Assert.Equal(meshArchive.CacheHeader.dataOffset, header.dataOffset);
            Assert.Equal(meshArchive.CacheHeader.fileSize, header.fileSize);
            Assert.Equal(meshArchive.CacheHeader.junk1, header.junk1);
        }

        [Fact]
        public void High_Twenty_Thousand_Mesh_Id_Is_Valid()
        {
            this.meshArchive.LoadIndexes();
            var identity = this.meshArchive.GetIdentityAtIndexOf(24000);
            var meshObject = this.meshArchive[identity];
            Assert.NotNull(meshObject);
        }

        [Fact]
        public void LoadIndexes_Loads_All_Indexes()
        {
            this.meshArchive.LoadIndexes();
            Assert.Equal(24387, this.meshArchive.CacheIndices.Length);
        }

    }
}