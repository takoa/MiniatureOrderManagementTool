using System;
using System.Collections.Generic;
using System.Text;

namespace MiniatureOrderManagementTool.Models.OrderLanguage
{
    public class ParsingError
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public int Length { get; set; }
        public string Message { get; set; }

        public ParsingError(int line, int column, int length, string message)
        {
            this.Line = line;
            this.Column = column;
            this.Length = length;
            this.Message = message;
        }
    }
}
