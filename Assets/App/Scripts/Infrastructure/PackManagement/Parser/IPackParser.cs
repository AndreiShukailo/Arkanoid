using System.Collections.Generic;
using App.Scripts.Infrastructure.LevelsManagement;

namespace App.Scripts.Infrastructure.PackManagement
{
    public interface IPackParser
    {
        Dictionary<int, Pack> GetPacks(PackConfig config);
    }
}