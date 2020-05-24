using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MinitureOrderManagementTool.Models
{
    class OrderDeadlineComparer : IComparer<Order>
    {
        public int Compare([DisallowNull] Order x, [DisallowNull] Order y)
        {
            return x.Deadline.CompareTo(y.Deadline);
        }
    }
}
