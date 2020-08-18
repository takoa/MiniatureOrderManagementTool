using Antlr4.Runtime;
using DynamicData;
using DynamicData.Binding;
using MiniatureOrderManagementTool.Models.OrderLanguage;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace MiniatureOrderManagementTool.Models
{
    public class PartManager
    {
        private SourceCache<Part, string> partsCache = new SourceCache<Part, string>(p => p.Name);

        public IObservableCollection<Part> ObservableParts { get; } = new ObservableCollectionExtended<Part>();

        public Part[] Parts => this.ObservableParts.ToArray();

        public event Action WhenPartChanged;

        public PartManager()
            : this(null)
        {
        }

        public PartManager(IEnumerable<Part> parts)
        {
            this.partsCache.Connect()
                           .ObserveOn(RxApp.MainThreadScheduler)
                           .Sort(new PartNameComparer())
                           .Bind(this.ObservableParts)
                           .WhenAnyPropertyChanged("Name", "UnitPrice", "Count")
                           .Subscribe(_ => this.WhenPartChanged?.Invoke());

            if (parts != null)
            {
                this.partsCache.AddOrUpdate(parts);
            }
        }

        public static int GetPartAmountInt(string str)
        {

            if (Int32.TryParse(str, out int i))
            {
                return i;
            }
            else if (str == "" || i < 0)
            {
                return 0;
            }
            else
            {
                return int.MaxValue;
            }
        }

        public static string GetTotalPartCountString(int totalPartCount)
        {
            return totalPartCount + "個";
        }

        public static string GetTotalPartValueString(decimal totalPartValue)
        {
            return totalPartValue + "円";
        }

        public static string GetErrorString(IList<ParseError> errorPositions)
        {
            var sb = new StringBuilder();

            sb.Append("文法エラー").AppendLine();

            foreach (var item in errorPositions)
            {
                sb.Append("行").Append(item.Line).Append(" ");
                sb.Append("列").Append(item.Column).Append(": ");
                sb.Append(item.Message);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void AddOrUpdatePart(Part part)
        {
            this.partsCache.AddOrUpdate(part);
        }

        public void RemovePart(Part part)
        {
            this.partsCache.Remove(part);
        }

        public bool TryGetPart(string name, out Part part)
        {
            var p = this.partsCache.Lookup(name);

            if (p.HasValue)
            {
                part = p.Value;

                return true;
            }
            else
            {
                part = null;

                return false;
            }
        }

        public static ParseResult ParseOrderComment(string comment)
        {
            if (!comment.EndsWith(Environment.NewLine))
            {
                comment += Environment.NewLine;
            }

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(comment));
            var inputStream = new AntlrInputStream(stream);
            var lexer = new MiniatureOrderLanguageLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new MiniatureOrderLanguageParser(commonTokenStream);
            var visitor = new OrderLanguageVisitor();
            var errorListener = new OrderLanguageErrorListener();

            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);

            return new ParseResult((IEnumerable<Part>)visitor.Visit(parser.main()), errorListener.ErrorPositions);
        }

        public IList<ParseError> AddFromOrderComment(string comment)
        {
            var parseResult = PartManager.ParseOrderComment(comment);

            if (parseResult.ParseErrors.Count == 0)
            {
                this.partsCache.AddOrUpdate(parseResult.Parts);
            }

            return parseResult.ParseErrors;
        }
    }
}
