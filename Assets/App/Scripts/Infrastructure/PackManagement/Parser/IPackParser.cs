using System.Collections.Generic;
using App.Scripts.Infrastructure.PackManagement.Config;

namespace App.Scripts.Infrastructure.PackManagement.Parser
{
    public interface IPackParser
    {
        Dictionary<int, Pack> GetPacks(PackConfig config);
    }
}