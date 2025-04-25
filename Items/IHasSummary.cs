using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Defines the contract for an entity that can generate a summary.
    /// </summary>
    public interface IHasSummary
    {
        string CreateSummary();
    }
}
