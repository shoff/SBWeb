namespace SB.Tests.Domain
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using SB.Domain.IO;
    using Xunit;

    public class FileWriterTests : BaseTest
    {
        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("")]
        public void Write_Should_Throw_If_Filename_Is_Null_Or_Whitespace(string filename)
        {
            Assert.Throws<ArgumentException>(() => FileWriter.Writer.Write(Encoding.UTF8.GetBytes("hello"), "file.cache", filename));
        }


        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("")]
        public async Task WriteAsync_Should_Throw_If_Filename_Is_Null_Or_Whitespace(string filename)
        {
            await Assert.ThrowsAsync<ArgumentException>(() => FileWriter.Writer.WriteAsync(Encoding.UTF8.GetBytes("hello"), "path", filename));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("")]
        public void Write_Should_Throw_If_Folder_Is_Null_Or_Whitespace(string path)
        {
            Assert.Throws<ArgumentException>(() => FileWriter.Writer.Write(Encoding.UTF8.GetBytes("hello"), path, "file.cache"));
        }


        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("")]
        public async Task WriteAsync_Should_Throw_If_Folder_Is_Null_Or_Whitespace(string path)
        {
           await Assert.ThrowsAsync<ArgumentException>(() => FileWriter.Writer.WriteAsync(Encoding.UTF8.GetBytes("hello"), path, "file.cache"));
        }
    }
}