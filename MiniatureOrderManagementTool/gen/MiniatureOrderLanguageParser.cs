//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from F:/DevelopmentData/CSharp/MiniatureOrderManagementTool/MiniatureOrderLanguage/src\MiniatureOrderLanguage.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class MiniatureOrderLanguageParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		Types=1, Count=2, CountEach=3, Total=4, Price=5, Dot=6, Comma=7, Spaces=8, 
		Comment=9, Newline=10, DecimalInteger=11, Name=12;
	public const int
		RULE_main = 0, RULE_line = 1, RULE_part = 2, RULE_single = 3, RULE_group = 4, 
		RULE_each = 5, RULE_total = 6, RULE_itemLine = 7, RULE_item = 8;
	public static readonly string[] ruleNames = {
		"main", "line", "part", "single", "group", "each", "total", "itemLine", 
		"item"
	};

	private static readonly string[] _LiteralNames = {
	};
	private static readonly string[] _SymbolicNames = {
		null, "Types", "Count", "CountEach", "Total", "Price", "Dot", "Comma", 
		"Spaces", "Comment", "Newline", "DecimalInteger", "Name"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "MiniatureOrderLanguage.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static MiniatureOrderLanguageParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public MiniatureOrderLanguageParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public MiniatureOrderLanguageParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class MainContext : ParserRuleContext {
		public LineContext[] line() {
			return GetRuleContexts<LineContext>();
		}
		public LineContext line(int i) {
			return GetRuleContext<LineContext>(i);
		}
		public MainContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_main; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniatureOrderLanguageVisitor<TResult> typedVisitor = visitor as IMiniatureOrderLanguageVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMain(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MainContext main() {
		MainContext _localctx = new MainContext(Context, State);
		EnterRule(_localctx, 0, RULE_main);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 19;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 18; line();
				}
				}
				State = 21;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==Dot || _la==Newline );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LineContext : ParserRuleContext {
		public PartContext part() {
			return GetRuleContext<PartContext>(0);
		}
		public ITerminalNode Newline() { return GetToken(MiniatureOrderLanguageParser.Newline, 0); }
		public LineContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_line; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniatureOrderLanguageVisitor<TResult> typedVisitor = visitor as IMiniatureOrderLanguageVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLine(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public LineContext line() {
		LineContext _localctx = new LineContext(Context, State);
		EnterRule(_localctx, 2, RULE_line);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 25;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,1,Context) ) {
			case 1:
				{
				State = 23; part();
				}
				break;
			case 2:
				{
				State = 24; Match(Newline);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PartContext : ParserRuleContext {
		public ITerminalNode Dot() { return GetToken(MiniatureOrderLanguageParser.Dot, 0); }
		public SingleContext single() {
			return GetRuleContext<SingleContext>(0);
		}
		public GroupContext group() {
			return GetRuleContext<GroupContext>(0);
		}
		public ITerminalNode[] Newline() { return GetTokens(MiniatureOrderLanguageParser.Newline); }
		public ITerminalNode Newline(int i) {
			return GetToken(MiniatureOrderLanguageParser.Newline, i);
		}
		public ITerminalNode[] Name() { return GetTokens(MiniatureOrderLanguageParser.Name); }
		public ITerminalNode Name(int i) {
			return GetToken(MiniatureOrderLanguageParser.Name, i);
		}
		public ITerminalNode Types() { return GetToken(MiniatureOrderLanguageParser.Types, 0); }
		public PartContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_part; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniatureOrderLanguageVisitor<TResult> typedVisitor = visitor as IMiniatureOrderLanguageVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPart(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PartContext part() {
		PartContext _localctx = new PartContext(Context, State);
		EnterRule(_localctx, 4, RULE_part);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 30;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==Newline) {
				{
				{
				State = 27; Match(Newline);
				}
				}
				State = 32;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 33; Match(Dot);
			State = 35;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 34; Match(Name);
				}
				}
				State = 37;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==Name );
			State = 40;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==Types) {
				{
				State = 39; Match(Types);
				}
			}

			State = 44;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,5,Context) ) {
			case 1:
				{
				State = 42; single();
				}
				break;
			case 2:
				{
				State = 43; group();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class SingleContext : ParserRuleContext {
		public ITerminalNode Count() { return GetToken(MiniatureOrderLanguageParser.Count, 0); }
		public ITerminalNode Comma() { return GetToken(MiniatureOrderLanguageParser.Comma, 0); }
		public ITerminalNode Price() { return GetToken(MiniatureOrderLanguageParser.Price, 0); }
		public SingleContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_single; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniatureOrderLanguageVisitor<TResult> typedVisitor = visitor as IMiniatureOrderLanguageVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSingle(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public SingleContext single() {
		SingleContext _localctx = new SingleContext(Context, State);
		EnterRule(_localctx, 6, RULE_single);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 47;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==Count) {
				{
				State = 46; Match(Count);
				}
			}

			State = 50;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==Comma) {
				{
				State = 49; Match(Comma);
				}
			}

			State = 53;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==Price) {
				{
				State = 52; Match(Price);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class GroupContext : ParserRuleContext {
		public EachContext each() {
			return GetRuleContext<EachContext>(0);
		}
		public TotalContext total() {
			return GetRuleContext<TotalContext>(0);
		}
		public ItemLineContext[] itemLine() {
			return GetRuleContexts<ItemLineContext>();
		}
		public ItemLineContext itemLine(int i) {
			return GetRuleContext<ItemLineContext>(i);
		}
		public GroupContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_group; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniatureOrderLanguageVisitor<TResult> typedVisitor = visitor as IMiniatureOrderLanguageVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitGroup(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public GroupContext group() {
		GroupContext _localctx = new GroupContext(Context, State);
		EnterRule(_localctx, 8, RULE_group);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 56;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==CountEach) {
				{
				State = 55; each();
				}
			}

			State = 59;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==Total) {
				{
				State = 58; total();
				}
			}

			State = 64;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,11,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					State = 61; itemLine();
					}
					} 
				}
				State = 66;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,11,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class EachContext : ParserRuleContext {
		public ITerminalNode CountEach() { return GetToken(MiniatureOrderLanguageParser.CountEach, 0); }
		public ITerminalNode Comma() { return GetToken(MiniatureOrderLanguageParser.Comma, 0); }
		public ITerminalNode Price() { return GetToken(MiniatureOrderLanguageParser.Price, 0); }
		public EachContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_each; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniatureOrderLanguageVisitor<TResult> typedVisitor = visitor as IMiniatureOrderLanguageVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitEach(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public EachContext each() {
		EachContext _localctx = new EachContext(Context, State);
		EnterRule(_localctx, 10, RULE_each);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 67; Match(CountEach);
			State = 70;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==Comma) {
				{
				State = 68; Match(Comma);
				State = 69; Match(Price);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TotalContext : ParserRuleContext {
		public ITerminalNode Total() { return GetToken(MiniatureOrderLanguageParser.Total, 0); }
		public ITerminalNode Comma() { return GetToken(MiniatureOrderLanguageParser.Comma, 0); }
		public ITerminalNode Price() { return GetToken(MiniatureOrderLanguageParser.Price, 0); }
		public TotalContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_total; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniatureOrderLanguageVisitor<TResult> typedVisitor = visitor as IMiniatureOrderLanguageVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTotal(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TotalContext total() {
		TotalContext _localctx = new TotalContext(Context, State);
		EnterRule(_localctx, 12, RULE_total);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 72; Match(Total);
			State = 75;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==Comma) {
				{
				State = 73; Match(Comma);
				State = 74; Match(Price);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ItemLineContext : ParserRuleContext {
		public ItemContext item() {
			return GetRuleContext<ItemContext>(0);
		}
		public ITerminalNode Newline() { return GetToken(MiniatureOrderLanguageParser.Newline, 0); }
		public ItemLineContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_itemLine; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniatureOrderLanguageVisitor<TResult> typedVisitor = visitor as IMiniatureOrderLanguageVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitItemLine(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ItemLineContext itemLine() {
		ItemLineContext _localctx = new ItemLineContext(Context, State);
		EnterRule(_localctx, 14, RULE_itemLine);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 79;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case Dot:
				{
				State = 77; item();
				}
				break;
			case Newline:
				{
				State = 78; Match(Newline);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ItemContext : ParserRuleContext {
		public ITerminalNode Dot() { return GetToken(MiniatureOrderLanguageParser.Dot, 0); }
		public ITerminalNode Newline() { return GetToken(MiniatureOrderLanguageParser.Newline, 0); }
		public ITerminalNode[] Name() { return GetTokens(MiniatureOrderLanguageParser.Name); }
		public ITerminalNode Name(int i) {
			return GetToken(MiniatureOrderLanguageParser.Name, i);
		}
		public ItemContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_item; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniatureOrderLanguageVisitor<TResult> typedVisitor = visitor as IMiniatureOrderLanguageVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitItem(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ItemContext item() {
		ItemContext _localctx = new ItemContext(Context, State);
		EnterRule(_localctx, 16, RULE_item);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 81; Match(Dot);
			State = 83;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 82; Match(Name);
				}
				}
				State = 85;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==Name );
			State = 87; Match(Newline);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\xE', '\\', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x3', '\x2', '\x6', 
		'\x2', '\x16', '\n', '\x2', '\r', '\x2', '\xE', '\x2', '\x17', '\x3', 
		'\x3', '\x3', '\x3', '\x5', '\x3', '\x1C', '\n', '\x3', '\x3', '\x4', 
		'\a', '\x4', '\x1F', '\n', '\x4', '\f', '\x4', '\xE', '\x4', '\"', '\v', 
		'\x4', '\x3', '\x4', '\x3', '\x4', '\x6', '\x4', '&', '\n', '\x4', '\r', 
		'\x4', '\xE', '\x4', '\'', '\x3', '\x4', '\x5', '\x4', '+', '\n', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x5', '\x4', '/', '\n', '\x4', '\x3', '\x5', 
		'\x5', '\x5', '\x32', '\n', '\x5', '\x3', '\x5', '\x5', '\x5', '\x35', 
		'\n', '\x5', '\x3', '\x5', '\x5', '\x5', '\x38', '\n', '\x5', '\x3', '\x6', 
		'\x5', '\x6', ';', '\n', '\x6', '\x3', '\x6', '\x5', '\x6', '>', '\n', 
		'\x6', '\x3', '\x6', '\a', '\x6', '\x41', '\n', '\x6', '\f', '\x6', '\xE', 
		'\x6', '\x44', '\v', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x5', 
		'\a', 'I', '\n', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x5', '\b', 
		'N', '\n', '\b', '\x3', '\t', '\x3', '\t', '\x5', '\t', 'R', '\n', '\t', 
		'\x3', '\n', '\x3', '\n', '\x6', '\n', 'V', '\n', '\n', '\r', '\n', '\xE', 
		'\n', 'W', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x2', '\x2', '\v', 
		'\x2', '\x4', '\x6', '\b', '\n', '\f', '\xE', '\x10', '\x12', '\x2', '\x2', 
		'\x2', '\x62', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x4', '\x1B', 
		'\x3', '\x2', '\x2', '\x2', '\x6', ' ', '\x3', '\x2', '\x2', '\x2', '\b', 
		'\x31', '\x3', '\x2', '\x2', '\x2', '\n', ':', '\x3', '\x2', '\x2', '\x2', 
		'\f', '\x45', '\x3', '\x2', '\x2', '\x2', '\xE', 'J', '\x3', '\x2', '\x2', 
		'\x2', '\x10', 'Q', '\x3', '\x2', '\x2', '\x2', '\x12', 'S', '\x3', '\x2', 
		'\x2', '\x2', '\x14', '\x16', '\x5', '\x4', '\x3', '\x2', '\x15', '\x14', 
		'\x3', '\x2', '\x2', '\x2', '\x16', '\x17', '\x3', '\x2', '\x2', '\x2', 
		'\x17', '\x15', '\x3', '\x2', '\x2', '\x2', '\x17', '\x18', '\x3', '\x2', 
		'\x2', '\x2', '\x18', '\x3', '\x3', '\x2', '\x2', '\x2', '\x19', '\x1C', 
		'\x5', '\x6', '\x4', '\x2', '\x1A', '\x1C', '\a', '\f', '\x2', '\x2', 
		'\x1B', '\x19', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x1A', '\x3', '\x2', 
		'\x2', '\x2', '\x1C', '\x5', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x1F', 
		'\a', '\f', '\x2', '\x2', '\x1E', '\x1D', '\x3', '\x2', '\x2', '\x2', 
		'\x1F', '\"', '\x3', '\x2', '\x2', '\x2', ' ', '\x1E', '\x3', '\x2', '\x2', 
		'\x2', ' ', '!', '\x3', '\x2', '\x2', '\x2', '!', '#', '\x3', '\x2', '\x2', 
		'\x2', '\"', ' ', '\x3', '\x2', '\x2', '\x2', '#', '%', '\a', '\b', '\x2', 
		'\x2', '$', '&', '\a', '\xE', '\x2', '\x2', '%', '$', '\x3', '\x2', '\x2', 
		'\x2', '&', '\'', '\x3', '\x2', '\x2', '\x2', '\'', '%', '\x3', '\x2', 
		'\x2', '\x2', '\'', '(', '\x3', '\x2', '\x2', '\x2', '(', '*', '\x3', 
		'\x2', '\x2', '\x2', ')', '+', '\a', '\x3', '\x2', '\x2', '*', ')', '\x3', 
		'\x2', '\x2', '\x2', '*', '+', '\x3', '\x2', '\x2', '\x2', '+', '.', '\x3', 
		'\x2', '\x2', '\x2', ',', '/', '\x5', '\b', '\x5', '\x2', '-', '/', '\x5', 
		'\n', '\x6', '\x2', '.', ',', '\x3', '\x2', '\x2', '\x2', '.', '-', '\x3', 
		'\x2', '\x2', '\x2', '/', '\a', '\x3', '\x2', '\x2', '\x2', '\x30', '\x32', 
		'\a', '\x4', '\x2', '\x2', '\x31', '\x30', '\x3', '\x2', '\x2', '\x2', 
		'\x31', '\x32', '\x3', '\x2', '\x2', '\x2', '\x32', '\x34', '\x3', '\x2', 
		'\x2', '\x2', '\x33', '\x35', '\a', '\t', '\x2', '\x2', '\x34', '\x33', 
		'\x3', '\x2', '\x2', '\x2', '\x34', '\x35', '\x3', '\x2', '\x2', '\x2', 
		'\x35', '\x37', '\x3', '\x2', '\x2', '\x2', '\x36', '\x38', '\a', '\a', 
		'\x2', '\x2', '\x37', '\x36', '\x3', '\x2', '\x2', '\x2', '\x37', '\x38', 
		'\x3', '\x2', '\x2', '\x2', '\x38', '\t', '\x3', '\x2', '\x2', '\x2', 
		'\x39', ';', '\x5', '\f', '\a', '\x2', ':', '\x39', '\x3', '\x2', '\x2', 
		'\x2', ':', ';', '\x3', '\x2', '\x2', '\x2', ';', '=', '\x3', '\x2', '\x2', 
		'\x2', '<', '>', '\x5', '\xE', '\b', '\x2', '=', '<', '\x3', '\x2', '\x2', 
		'\x2', '=', '>', '\x3', '\x2', '\x2', '\x2', '>', '\x42', '\x3', '\x2', 
		'\x2', '\x2', '?', '\x41', '\x5', '\x10', '\t', '\x2', '@', '?', '\x3', 
		'\x2', '\x2', '\x2', '\x41', '\x44', '\x3', '\x2', '\x2', '\x2', '\x42', 
		'@', '\x3', '\x2', '\x2', '\x2', '\x42', '\x43', '\x3', '\x2', '\x2', 
		'\x2', '\x43', '\v', '\x3', '\x2', '\x2', '\x2', '\x44', '\x42', '\x3', 
		'\x2', '\x2', '\x2', '\x45', 'H', '\a', '\x5', '\x2', '\x2', '\x46', 'G', 
		'\a', '\t', '\x2', '\x2', 'G', 'I', '\a', '\a', '\x2', '\x2', 'H', '\x46', 
		'\x3', '\x2', '\x2', '\x2', 'H', 'I', '\x3', '\x2', '\x2', '\x2', 'I', 
		'\r', '\x3', '\x2', '\x2', '\x2', 'J', 'M', '\a', '\x6', '\x2', '\x2', 
		'K', 'L', '\a', '\t', '\x2', '\x2', 'L', 'N', '\a', '\a', '\x2', '\x2', 
		'M', 'K', '\x3', '\x2', '\x2', '\x2', 'M', 'N', '\x3', '\x2', '\x2', '\x2', 
		'N', '\xF', '\x3', '\x2', '\x2', '\x2', 'O', 'R', '\x5', '\x12', '\n', 
		'\x2', 'P', 'R', '\a', '\f', '\x2', '\x2', 'Q', 'O', '\x3', '\x2', '\x2', 
		'\x2', 'Q', 'P', '\x3', '\x2', '\x2', '\x2', 'R', '\x11', '\x3', '\x2', 
		'\x2', '\x2', 'S', 'U', '\a', '\b', '\x2', '\x2', 'T', 'V', '\a', '\xE', 
		'\x2', '\x2', 'U', 'T', '\x3', '\x2', '\x2', '\x2', 'V', 'W', '\x3', '\x2', 
		'\x2', '\x2', 'W', 'U', '\x3', '\x2', '\x2', '\x2', 'W', 'X', '\x3', '\x2', 
		'\x2', '\x2', 'X', 'Y', '\x3', '\x2', '\x2', '\x2', 'Y', 'Z', '\a', '\f', 
		'\x2', '\x2', 'Z', '\x13', '\x3', '\x2', '\x2', '\x2', '\x12', '\x17', 
		'\x1B', ' ', '\'', '*', '.', '\x31', '\x34', '\x37', ':', '=', '\x42', 
		'H', 'M', 'Q', 'W',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
