using MiniatureOrderManagementTool.Models.Dtos;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MiniatureOrderManagementTool.Models
{
    public class StockItemNameComparer : IComparer<StockItem>
    {
        public int Compare([DisallowNull] StockItem x, [DisallowNull] StockItem y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
