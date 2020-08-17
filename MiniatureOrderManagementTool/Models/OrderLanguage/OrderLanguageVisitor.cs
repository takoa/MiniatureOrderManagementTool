using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniatureOrderManagementTool.Models.OrderLanguage
{
    public class OrderLanguageVisitor : MiniatureOrderLanguageBaseVisitor<object>
    {
        public override object VisitErrorNode(Antlr4.Runtime.Tree.IErrorNode node)
        {
            return base.VisitErrorNode(node);
        }

        public override object VisitMain([NotNull] MiniatureOrderLanguageParser.MainContext context)
        {
            var parts = new List<Part>();

            foreach (var item in context.children)
            {
                if (this.Visit(item) is IEnumerable<Part> enumerable)
                {
                    foreach (var part in enumerable)
                    {
                        parts.Add(part);
                    }
                }
            }

            return parts;
        }

        public override object VisitLine([NotNull] MiniatureOrderLanguageParser.LineContext context)
        {
            var part = context.part();

            return part != null ? this.Visit(part) : null;
        }

        public override object VisitPart([NotNull] MiniatureOrderLanguageParser.PartContext context)
        {
            IEnumerable<Part> parts;
            var names = context.Name();
            var name = "";
            var groupContext = context.group();

            for (int i = 0; i < names.Length; i++)
            {
                if (i != 0)
                {
                    name += " ";
                }

                name += names[i];
            }

            if (groupContext != null)
            {
                parts = (IEnumerable<Part>)this.Visit(groupContext);

                foreach (var item in parts)
                {
                    item.Name = name + " " + item.Name;
                }
            }
            else
            {
                var types = context.Types();
                (decimal UnitPrice, int Count) single;

                if (types != null)
                {
                    name += " " + types.GetText();
                }

                single = ((decimal, int))this.Visit(context.single());
                parts = new Part[] { new Part(name, single.UnitPrice, single.Count) };
            }

            return parts;
        }

        public override object VisitSingle([NotNull] MiniatureOrderLanguageParser.SingleContext context)
        {
            (decimal UnitPrice, int Count) result = (0m, 1);

            int.TryParse(context.Count()?.GetText()[0..^1], out result.Count);
            decimal.TryParse(context.Price()?.GetText()[0..^1], out result.UnitPrice);

            return result;
        }

        public override object VisitGroup([NotNull] MiniatureOrderLanguageParser.GroupContext context)
        {
            var parts = new List<Part>();
            var eachContext = context.each();
            (decimal UnitPrice, int Count) each;

            if (eachContext != null)
            {
                each = ((decimal, int))this.Visit(eachContext);
            }
            else
            {
                each = (0m, 1);
            }

            foreach (var item in context.itemLine())
            {
                var o = this.Visit(item);

                if (o != null)
                {
                    parts.Add(new Part((string)o, each.UnitPrice, each.Count));
                }
            }

            return parts;
        }

        public override object VisitEach([NotNull] MiniatureOrderLanguageParser.EachContext context)
        {
            (decimal UnitPrice, int Count) result = (0m, 1);

            int.TryParse(context.CountEach()?.GetText()[1..^1], out result.Count);
            decimal.TryParse(context.Price()?.GetText()[0..^1], out result.UnitPrice);

            return result;
        }

        public override object VisitItemLine([NotNull] MiniatureOrderLanguageParser.ItemLineContext context)
        {
            if (context.item() != null)
            {
                return this.Visit(context.item());
            }
            else
            {
                return null;
            }
        }

        public override object VisitItem([NotNull] MiniatureOrderLanguageParser.ItemContext context)
        {
            var names = context.Name();
            var name = "";

            for (int i = 0; i < names.Length; i++)
            {
                if (i != 0)
                {
                    name += " ";
                }

                name += names[i];
            }

            return name;
        }
    }
}
