namespace MiniatureOrderManagementTool.Models.OrderLanguage
{
    public class ParseError
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public int Length { get; set; }
        public string Message { get; set; }

        public ParseError(int line, int column, int length, string message)
        {
            this.Line = line;
            this.Column = column;
            this.Length = length;
            this.Message = message;
        }
    }
}
