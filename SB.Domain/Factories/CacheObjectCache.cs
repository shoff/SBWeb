namespace SB.Domain.Factories
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Extensions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Models;
    using Models.Base;

    // TODO this is poorly named, it should just be the CObjects Cache or something
    public class CacheObjectsCache
    {
        private readonly IServiceCollection services;
        private ServiceProvider serviceProvider;

        /// <summary>
        ///     Prevents a default instance of the <see cref="CacheObjectsCache" /> class from being created.
        /// </summary>
        public CacheObjectsCache(IServiceCollection services)
        {
            this.services = services;
            this.serviceProvider = this.services.BuildServiceProvider();
#if DEBUG
            var sw = new Stopwatch();
            sw.Start();
#endif
            this.CacheObjectsArchive = this.serviceProvider.GetRequiredService<CObjectsArchive>();
                // (CObjects)ArchiveFactory.Instance.Build(CacheFile.CObjects, true);

#if DEBUG
            sw.Stop();
            this.LoadTime = sw.ElapsedTicks;
#endif
        }

        /// <summary>Gets the indexes.</summary>
        public ICollection<CacheIndex> Indexes => this.CacheObjectsArchive.CacheIndices;

        
        /// <summary>Gets the load time.</summary>
        public long LoadTime { get; }

        internal CObjectsArchive CacheObjectsArchive { get; }

        public async Task<CacheObject> CreateAndParseAsync(CacheIndex cacheIndex)
        {
            return await Task.FromResult(this.CreateAndParse(cacheIndex));
        }

        internal CacheObject Create(CacheIndex cacheIndex)
        {
            var asset = this.CacheObjectsArchive[cacheIndex.Identity];
            using (var reader = asset.Item1.CreateBinaryReaderUtf32())
            {
                // reader.skip(4); // ignore "TNLC" tag
                // ReSharper disable once UnusedVariable
                var tnlc = reader.ReadInt32();

                // 4
                var flag = (ObjectType)reader.ReadInt32();
                var nameLength = reader.ReadUInt32();
                var name = reader.ReadAsciiString(nameLength);

                // why are we using this inner offset?
                var innerOffset = (int)reader.BaseStream.Position;

                // what are we doing with the offset here??
                // so I think this must be the bug? 
                var offset = (int)reader.BaseStream.Position + 25;
                var logger = this.serviceProvider.GetRequiredService<ILogger<ModelObject>>();
                return new UnknownObject(logger, cacheIndex, flag, name, offset, asset.Item1, innerOffset);
            }
        }

        public CacheObject CreateAndParse(uint identity)
        {
            // TODO there is still the shit with multiple cache objects having the same Identity
            var asset = this.CacheObjectsArchive[identity];
            return this.CreateAndParse(asset.CacheIndex1);
        }

        public CacheObject CreateAndParse(CacheIndex cacheIndex)
        {
            var asset = this.CacheObjectsArchive[cacheIndex.Identity];
            int innerOffset;
            int offset;
            ObjectType flag;
            string name;
            using (var reader = asset.Item1.CreateBinaryReaderUtf32())
            {
                // reader.skip(4); // ignore "TNLC" tag
                // ReSharper disable once UnusedVariable
                var tnlc = reader.ReadInt32();

                // 4
                flag = (ObjectType)reader.ReadInt32();
                var nameLength = reader.ReadUInt32();
                name = reader.ReadAsciiString(nameLength);

                // why are we using this inner offset?
                innerOffset = (int)reader.BaseStream.Position;

                // what are we doing with the offset here??
                // so I think this must be the bug? 
                offset = (int)reader.BaseStream.Position + 25;
            }
            var logger = this.serviceProvider.GetRequiredService<ILogger<ModelObject>>();

            // TODO this can be optimized by passing the reader to the parse method.
            switch (flag)
            {

                case ObjectType.Simple:
                    var simple = new Simple(logger, cacheIndex, flag, name, offset, asset.Item1, innerOffset);
                    simple.Parse(asset.Item1);
                    return simple;

                case ObjectType.Structure:
                    var structure = new Structure(logger, cacheIndex, flag, name, offset, asset.Item1, innerOffset);
                    structure.Parse(asset.Item1);
                    return structure;

                case ObjectType.Interactive:
                    var interactive = new Interactive(logger, cacheIndex, flag, name, offset, asset.Item1, innerOffset);
                    interactive.Parse(asset.Item1);
                    return interactive;

                case ObjectType.Equipment:
                    var equipment = new Equipment(logger, cacheIndex, flag, name, offset, asset.Item1, innerOffset);
                    equipment.Parse(asset.Item1);
                    return equipment;

                case ObjectType.Mobile:

                    var mobile = new Mobile(logger, cacheIndex, flag, name, offset, asset.Item1, innerOffset);
                    // mobile.Parse(asset.Item1);
                    return mobile;

                case ObjectType.Deed:
                    var deed = new DeedObject(logger, cacheIndex, flag, name, offset, asset.Item1, innerOffset);
                    deed.Parse(asset.Item1);
                    return deed;

                case ObjectType.Sun:
                    return new Sun(logger, cacheIndex, flag, name, offset, asset.Item1, innerOffset);

                case ObjectType.Warrant:
                    var warrant = new Warrant(logger, cacheIndex, flag, name, offset, asset.Item1, innerOffset);
                    warrant.Parse(asset.Item1);
                    return warrant;

                case ObjectType.Unknown:
                    return new UnknownObject(logger, cacheIndex, flag, name, offset, asset.Item1, innerOffset);

                case ObjectType.Particle:
                    return new Particle(logger, cacheIndex, flag, name, offset, asset.Item1, innerOffset);
            }

            return null;
        }
    }
}