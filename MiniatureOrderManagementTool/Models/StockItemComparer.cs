using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MiniatureOrderManagementTool.Models
{
    public class StockedPartNameComparer : IComparer<StockedPart>
    {
        public int Compare([DisallowNull] StockedPart x, [DisallowNull] StockedPart y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
