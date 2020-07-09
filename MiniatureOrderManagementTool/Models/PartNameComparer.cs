using MiniatureOrderManagementTool.Models.Dtos;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MiniatureOrderManagementTool.Models
{
    public class PartNameComparer : IComparer<Part>
    {
        public int Compare([DisallowNull] Part x, [DisallowNull] Part y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
