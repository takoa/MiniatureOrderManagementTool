using MiniatureOrderManagementTool.Dtos;
using System;

namespace MiniatureOrderManagementTool.Models
{
    public interface ICommonOrderInfo
    {
        string Name { get; set; }
        decimal Price { get; set; }
        string Description { get; set; }
        string Customer { get; set; }
        DateTime Deadline { get; set; }
        Part[] Parts { get; set; }
    }
}
