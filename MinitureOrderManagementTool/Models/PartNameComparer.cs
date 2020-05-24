using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MinitureOrderManagementTool.Models
{
    public class PartNameComparer : IComparer<Part>
    {
        public int Compare([DisallowNull] Part x, [DisallowNull] Part y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
