using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Interface for classes that must implement a summary of their functionality
    /// </summary>
    public interface IHasSummary
    {
        string CreateSummary();
    }
}
