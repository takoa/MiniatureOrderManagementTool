using MiniatureOrderManagementTool.Models.OrderLanguage;
using System.Collections.Generic;

namespace MiniatureOrderManagementTool.Models.OrderLanguage
{
    public class ParseResult
    {
        public IEnumerable<Part> Parts { get; }
        public IList<ParseError> ParseErrors { get; }

        public ParseResult()
        {
        }

        public ParseResult(IEnumerable<Part> parts, IList<ParseError> parseErrors)
        {
            this.Parts = parts;
            this.ParseErrors = parseErrors;
        }
    }
}
