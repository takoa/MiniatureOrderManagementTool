using Antlr4.Runtime;
using System.Collections.Generic;
using System.IO;

namespace MiniatureOrderManagementTool.Models.OrderLanguage
{
    class OrderLanguageErrorListener : IAntlrErrorListener<IToken>
    {
        public IList<ParsingError> ErrorPositions { get; } = new List<ParsingError>();

        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            this.ErrorPositions.Add(new ParsingError(line, charPositionInLine, offendingSymbol.Text.Length, offendingSymbol.Text));
        }
    }
}
