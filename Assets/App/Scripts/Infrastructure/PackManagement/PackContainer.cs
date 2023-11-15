using System.Collections.Generic;
using System.Linq;
using App.Scripts.Infrastructure.PackManagement.Config;
using App.Scripts.Infrastructure.PackManagement.Parser;

namespace App.Scripts.Infrastructure.PackManagement
{
    public class PackContainer
    {
        private Dictionary<int, Pack> _packs;

        public PackContainer(IPackParser packParser, PackConfig packConfig)
        {
            _packs = packParser.GetPacks(packConfig);
        }

        public Pack GetPack(int id)
        {
            return _packs[id];
        }

        public IEnumerable<Pack> GetAll()
        {
            return _packs.Values.Reverse();
        }
    }
}