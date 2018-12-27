namespace SB.Domain.IO
{
    using System;
    using System.IO;
    using System.Security;
    using System.Threading.Tasks;

    public class FileWriter
    {
        public static FileWriter Writer { get; } = new FileWriter();

        public async Task WriteAsync(byte[] data, string path)
        {
            if (data.Length == 0)
            {
                throw new ArgumentException("Cannot write an empty collection", nameof(data));
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(path));
            }

            await Task.Run(() =>
            {
                FileStream fs = null;

                try
                {
                    fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                    using (var writer = new BinaryWriter(fs))
                    {
                        writer.Write(data);
                    }
                }
                finally
                {
                    fs?.Dispose();
                }
            });
        }

        public void Write(byte[] data, string path)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new BinaryWriter(fs))
                {
                    writer.Write(data);
                }
            }
        }
    }
}