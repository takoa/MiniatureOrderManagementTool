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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class MiniatureOrderLanguageLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		Types=1, Count=2, CountEach=3, Total=4, Price=5, Dot=6, Comma=7, Spaces=8, 
		Comment=9, Newline=10, DecimalInteger=11, Name=12;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"Types", "Count", "CountEach", "Total", "Price", "Dot", "Comma", "Spaces", 
		"Comment", "Newline", "DecimalInteger", "Name", "NonZeroDigit", "Digit", 
		"IdStart", "IdContinue", "Emoji", "CommentSign"
	};


	public MiniatureOrderLanguageLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public MiniatureOrderLanguageLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

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

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static MiniatureOrderLanguageLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\xE', '\x88', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', 
		'\x3', '\b', '\x3', '\b', '\x3', '\t', '\x6', '\t', '?', '\n', '\t', '\r', 
		'\t', '\xE', '\t', '@', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', 
		'\n', '\a', '\n', 'G', '\n', '\n', '\f', '\n', '\xE', '\n', 'J', '\v', 
		'\n', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x5', '\v', 'O', '\n', '\v', 
		'\x3', '\v', '\x3', '\v', '\x5', '\v', 'S', '\n', '\v', '\x3', '\v', '\x5', 
		'\v', 'V', '\n', '\v', '\x3', '\f', '\x3', '\f', '\a', '\f', 'Z', '\n', 
		'\f', '\f', '\f', '\xE', '\f', ']', '\v', '\f', '\x3', '\f', '\x6', '\f', 
		'`', '\n', '\f', '\r', '\f', '\xE', '\f', '\x61', '\x5', '\f', '\x64', 
		'\n', '\f', '\x3', '\r', '\x3', '\r', '\a', '\r', 'h', '\n', '\r', '\f', 
		'\r', '\xE', '\r', 'k', '\v', '\r', '\x3', '\r', '\x3', '\r', '\x6', '\r', 
		'o', '\n', '\r', '\r', '\r', '\xE', '\r', 'p', '\x3', '\r', '\x3', '\r', 
		'\x5', '\r', 'u', '\n', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x5', '\x10', 
		'~', '\n', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x5', 
		'\x11', '\x83', '\n', '\x11', '\x3', '\x12', '\x3', '\x12', '\x3', '\x13', 
		'\x3', '\x13', '\x2', '\x2', '\x14', '\x3', '\x3', '\x5', '\x4', '\a', 
		'\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', 
		'\x13', '\v', '\x15', '\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\x2', 
		'\x1D', '\x2', '\x1F', '\x2', '!', '\x2', '#', '\x2', '%', '\x2', '\x3', 
		'\x2', '\f', '\x4', '\x2', '\xB9', '\xB9', '\x30FD', '\x30FD', '\x5', 
		'\x2', '.', '.', '\x3003', '\x3003', '\xFF0E', '\xFF0E', '\x5', '\x2', 
		'\v', '\v', '\"', '\"', '\x3002', '\x3002', '\x4', '\x2', '\f', '\f', 
		'\xF', '\xF', '\x3', '\x2', '\x33', ';', '\x3', '\x2', '\x32', ';', '\x5', 
		'\x2', '\x43', '\\', '\x61', '\x61', '\x63', '|', '\x126', '\x2', '\xAC', 
		'\xAC', '\xB7', '\xB7', '\xBC', '\xBC', '\xC2', '\xD8', '\xDA', '\xF8', 
		'\xFA', '\x243', '\x252', '\x2C3', '\x2C8', '\x2D3', '\x2E2', '\x2E6', 
		'\x2F0', '\x2F0', '\x37C', '\x37C', '\x388', '\x388', '\x38A', '\x38C', 
		'\x38E', '\x38E', '\x390', '\x3A3', '\x3A5', '\x3D0', '\x3D2', '\x3F7', 
		'\x3F9', '\x483', '\x48C', '\x4D0', '\x4D2', '\x4FB', '\x502', '\x511', 
		'\x533', '\x558', '\x55B', '\x55B', '\x563', '\x589', '\x5D2', '\x5EC', 
		'\x5F2', '\x5F4', '\x623', '\x63C', '\x642', '\x64C', '\x670', '\x671', 
		'\x673', '\x6D5', '\x6D7', '\x6D7', '\x6E7', '\x6E8', '\x6F0', '\x6F1', 
		'\x6FC', '\x6FE', '\x701', '\x701', '\x712', '\x712', '\x714', '\x731', 
		'\x74F', '\x76F', '\x782', '\x7A7', '\x7B3', '\x7B3', '\x906', '\x93B', 
		'\x93F', '\x93F', '\x952', '\x952', '\x95A', '\x963', '\x97F', '\x97F', 
		'\x987', '\x98E', '\x991', '\x992', '\x995', '\x9AA', '\x9AC', '\x9B2', 
		'\x9B4', '\x9B4', '\x9B8', '\x9BB', '\x9BF', '\x9BF', '\x9D0', '\x9D0', 
		'\x9DE', '\x9DF', '\x9E1', '\x9E3', '\x9F2', '\x9F3', '\xA07', '\xA0C', 
		'\xA11', '\xA12', '\xA15', '\xA2A', '\xA2C', '\xA32', '\xA34', '\xA35', 
		'\xA37', '\xA38', '\xA3A', '\xA3B', '\xA5B', '\xA5E', '\xA60', '\xA60', 
		'\xA74', '\xA76', '\xA87', '\xA8F', '\xA91', '\xA93', '\xA95', '\xAAA', 
		'\xAAC', '\xAB2', '\xAB4', '\xAB5', '\xAB7', '\xABB', '\xABF', '\xABF', 
		'\xAD2', '\xAD2', '\xAE2', '\xAE3', '\xB07', '\xB0E', '\xB11', '\xB12', 
		'\xB15', '\xB2A', '\xB2C', '\xB32', '\xB34', '\xB35', '\xB37', '\xB3B', 
		'\xB3F', '\xB3F', '\xB5E', '\xB5F', '\xB61', '\xB63', '\xB73', '\xB73', 
		'\xB85', '\xB85', '\xB87', '\xB8C', '\xB90', '\xB92', '\xB94', '\xB97', 
		'\xB9B', '\xB9C', '\xB9E', '\xB9E', '\xBA0', '\xBA1', '\xBA5', '\xBA6', 
		'\xBAA', '\xBAC', '\xBB0', '\xBBB', '\xC07', '\xC0E', '\xC10', '\xC12', 
		'\xC14', '\xC2A', '\xC2C', '\xC35', '\xC37', '\xC3B', '\xC62', '\xC63', 
		'\xC87', '\xC8E', '\xC90', '\xC92', '\xC94', '\xCAA', '\xCAC', '\xCB5', 
		'\xCB7', '\xCBB', '\xCBF', '\xCBF', '\xCE0', '\xCE0', '\xCE2', '\xCE3', 
		'\xD07', '\xD0E', '\xD10', '\xD12', '\xD14', '\xD2A', '\xD2C', '\xD3B', 
		'\xD62', '\xD63', '\xD87', '\xD98', '\xD9C', '\xDB3', '\xDB5', '\xDBD', 
		'\xDBF', '\xDBF', '\xDC2', '\xDC8', '\xE03', '\xE32', '\xE34', '\xE35', 
		'\xE42', '\xE48', '\xE83', '\xE84', '\xE86', '\xE86', '\xE89', '\xE8A', 
		'\xE8C', '\xE8C', '\xE8F', '\xE8F', '\xE96', '\xE99', '\xE9B', '\xEA1', 
		'\xEA3', '\xEA5', '\xEA7', '\xEA7', '\xEA9', '\xEA9', '\xEAC', '\xEAD', 
		'\xEAF', '\xEB2', '\xEB4', '\xEB5', '\xEBF', '\xEBF', '\xEC2', '\xEC6', 
		'\xEC8', '\xEC8', '\xEDE', '\xEDF', '\xF02', '\xF02', '\xF42', '\xF49', 
		'\xF4B', '\xF6C', '\xF8A', '\xF8D', '\x1002', '\x1023', '\x1025', '\x1029', 
		'\x102B', '\x102C', '\x1052', '\x1057', '\x10A2', '\x10C7', '\x10D2', 
		'\x10FC', '\x10FE', '\x10FE', '\x1102', '\x115B', '\x1161', '\x11A4', 
		'\x11AA', '\x11FB', '\x1202', '\x124A', '\x124C', '\x124F', '\x1252', 
		'\x1258', '\x125A', '\x125A', '\x125C', '\x125F', '\x1262', '\x128A', 
		'\x128C', '\x128F', '\x1292', '\x12B2', '\x12B4', '\x12B7', '\x12BA', 
		'\x12C0', '\x12C2', '\x12C2', '\x12C4', '\x12C7', '\x12CA', '\x12D8', 
		'\x12DA', '\x1312', '\x1314', '\x1317', '\x131A', '\x135C', '\x1382', 
		'\x1391', '\x13A2', '\x13F6', '\x1403', '\x166E', '\x1671', '\x1678', 
		'\x1683', '\x169C', '\x16A2', '\x16EC', '\x16F0', '\x16F2', '\x1702', 
		'\x170E', '\x1710', '\x1713', '\x1722', '\x1733', '\x1742', '\x1753', 
		'\x1762', '\x176E', '\x1770', '\x1772', '\x1782', '\x17B5', '\x17D9', 
		'\x17D9', '\x17DE', '\x17DE', '\x1822', '\x1879', '\x1882', '\x18AA', 
		'\x1902', '\x191E', '\x1952', '\x196F', '\x1972', '\x1976', '\x1982', 
		'\x19AB', '\x19C3', '\x19C9', '\x1A02', '\x1A18', '\x1D02', '\x1DC1', 
		'\x1E02', '\x1E9D', '\x1EA2', '\x1EFB', '\x1F02', '\x1F17', '\x1F1A', 
		'\x1F1F', '\x1F22', '\x1F47', '\x1F4A', '\x1F4F', '\x1F52', '\x1F59', 
		'\x1F5B', '\x1F5B', '\x1F5D', '\x1F5D', '\x1F5F', '\x1F5F', '\x1F61', 
		'\x1F7F', '\x1F82', '\x1FB6', '\x1FB8', '\x1FBE', '\x1FC0', '\x1FC0', 
		'\x1FC4', '\x1FC6', '\x1FC8', '\x1FCE', '\x1FD2', '\x1FD5', '\x1FD8', 
		'\x1FDD', '\x1FE2', '\x1FEE', '\x1FF4', '\x1FF6', '\x1FF8', '\x1FFE', 
		'\x2073', '\x2073', '\x2081', '\x2081', '\x2092', '\x2096', '\x2104', 
		'\x2104', '\x2109', '\x2109', '\x210C', '\x2115', '\x2117', '\x2117', 
		'\x211A', '\x211F', '\x2126', '\x2126', '\x2128', '\x2128', '\x212A', 
		'\x212A', '\x212C', '\x2133', '\x2135', '\x213B', '\x213E', '\x2141', 
		'\x2147', '\x214B', '\x2162', '\x2185', '\x2C02', '\x2C30', '\x2C32', 
		'\x2C60', '\x2C82', '\x2CE6', '\x2D02', '\x2D27', '\x2D32', '\x2D67', 
		'\x2D71', '\x2D71', '\x2D82', '\x2D98', '\x2DA2', '\x2DA8', '\x2DAA', 
		'\x2DB0', '\x2DB2', '\x2DB8', '\x2DBA', '\x2DC0', '\x2DC2', '\x2DC8', 
		'\x2DCA', '\x2DD0', '\x2DD2', '\x2DD8', '\x2DDA', '\x2DE0', '\x3007', 
		'\x3009', '\x3023', '\x302B', '\x3033', '\x3037', '\x303A', '\x303E', 
		'\x3043', '\x3098', '\x309D', '\x30A1', '\x30A3', '\x30FC', '\x30FE', 
		'\x3101', '\x3107', '\x312E', '\x3133', '\x3190', '\x31A2', '\x31B9', 
		'\x31F2', '\x3201', '\x3402', '\x4DB7', '\x4E02', '\x9FBD', '\xA002', 
		'\xA48E', '\xA802', '\xA803', '\xA805', '\xA807', '\xA809', '\xA80C', 
		'\xA80E', '\xA824', '\xAC02', '\xD7A5', '\xF902', '\xFA2F', '\xFA32', 
		'\xFA6C', '\xFA72', '\xFADB', '\xFB02', '\xFB08', '\xFB15', '\xFB19', 
		'\xFB1F', '\xFB1F', '\xFB21', '\xFB2A', '\xFB2C', '\xFB38', '\xFB3A', 
		'\xFB3E', '\xFB40', '\xFB40', '\xFB42', '\xFB43', '\xFB45', '\xFB46', 
		'\xFB48', '\xFBB3', '\xFBD5', '\xFD3F', '\xFD52', '\xFD91', '\xFD94', 
		'\xFDC9', '\xFDF2', '\xFDFD', '\xFE72', '\xFE76', '\xFE78', '\xFEFE', 
		'\xFF23', '\xFF3C', '\xFF43', '\xFF5C', '\xFF68', '\xFFC0', '\xFFC4', 
		'\xFFC9', '\xFFCC', '\xFFD1', '\xFFD4', '\xFFD9', '\xFFDC', '\xFFDE', 
		'\x96', '\x2', '\x32', ';', '\x302', '\x371', '\x485', '\x488', '\x593', 
		'\x5BB', '\x5BD', '\x5BF', '\x5C1', '\x5C1', '\x5C3', '\x5C4', '\x5C6', 
		'\x5C7', '\x5C9', '\x5C9', '\x612', '\x617', '\x64D', '\x660', '\x662', 
		'\x66B', '\x672', '\x672', '\x6D8', '\x6DE', '\x6E1', '\x6E6', '\x6E9', 
		'\x6EA', '\x6EC', '\x6EF', '\x6F2', '\x6FB', '\x713', '\x713', '\x732', 
		'\x74C', '\x7A8', '\x7B2', '\x903', '\x905', '\x93E', '\x93E', '\x940', 
		'\x94F', '\x953', '\x956', '\x964', '\x965', '\x968', '\x971', '\x983', 
		'\x985', '\x9BE', '\x9BE', '\x9C0', '\x9C6', '\x9C9', '\x9CA', '\x9CD', 
		'\x9CF', '\x9D9', '\x9D9', '\x9E4', '\x9E5', '\x9E8', '\x9F1', '\xA03', 
		'\xA05', '\xA3E', '\xA3E', '\xA40', '\xA44', '\xA49', '\xA4A', '\xA4D', 
		'\xA4F', '\xA68', '\xA73', '\xA83', '\xA85', '\xABE', '\xABE', '\xAC0', 
		'\xAC7', '\xAC9', '\xACB', '\xACD', '\xACF', '\xAE4', '\xAE5', '\xAE8', 
		'\xAF1', '\xB03', '\xB05', '\xB3E', '\xB3E', '\xB40', '\xB45', '\xB49', 
		'\xB4A', '\xB4D', '\xB4F', '\xB58', '\xB59', '\xB68', '\xB71', '\xB84', 
		'\xB84', '\xBC0', '\xBC4', '\xBC8', '\xBCA', '\xBCC', '\xBCF', '\xBD9', 
		'\xBD9', '\xBE8', '\xBF1', '\xC03', '\xC05', '\xC40', '\xC46', '\xC48', 
		'\xC4A', '\xC4C', '\xC4F', '\xC57', '\xC58', '\xC68', '\xC71', '\xC84', 
		'\xC85', '\xCBE', '\xCBE', '\xCC0', '\xCC6', '\xCC8', '\xCCA', '\xCCC', 
		'\xCCF', '\xCD7', '\xCD8', '\xCE8', '\xCF1', '\xD04', '\xD05', '\xD40', 
		'\xD45', '\xD48', '\xD4A', '\xD4C', '\xD4F', '\xD59', '\xD59', '\xD68', 
		'\xD71', '\xD84', '\xD85', '\xDCC', '\xDCC', '\xDD1', '\xDD6', '\xDD8', 
		'\xDD8', '\xDDA', '\xDE1', '\xDF4', '\xDF5', '\xE33', '\xE33', '\xE36', 
		'\xE3C', '\xE49', '\xE50', '\xE52', '\xE5B', '\xEB3', '\xEB3', '\xEB6', 
		'\xEBB', '\xEBD', '\xEBE', '\xECA', '\xECF', '\xED2', '\xEDB', '\xF1A', 
		'\xF1B', '\xF22', '\xF2B', '\xF37', '\xF37', '\xF39', '\xF39', '\xF3B', 
		'\xF3B', '\xF40', '\xF41', '\xF73', '\xF86', '\xF88', '\xF89', '\xF92', 
		'\xF99', '\xF9B', '\xFBE', '\xFC8', '\xFC8', '\x102E', '\x1034', '\x1038', 
		'\x103B', '\x1042', '\x104B', '\x1058', '\x105B', '\x1361', '\x1361', 
		'\x136B', '\x1373', '\x1714', '\x1716', '\x1734', '\x1736', '\x1754', 
		'\x1755', '\x1774', '\x1775', '\x17B8', '\x17D5', '\x17DF', '\x17DF', 
		'\x17E2', '\x17EB', '\x180D', '\x180F', '\x1812', '\x181B', '\x18AB', 
		'\x18AB', '\x1922', '\x192D', '\x1932', '\x193D', '\x1948', '\x1951', 
		'\x19B2', '\x19C2', '\x19CA', '\x19CB', '\x19D2', '\x19DB', '\x1A19', 
		'\x1A1D', '\x1DC2', '\x1DC5', '\x2041', '\x2042', '\x2056', '\x2056', 
		'\x20D2', '\x20DE', '\x20E3', '\x20E3', '\x20E7', '\x20ED', '\x302C', 
		'\x3031', '\x309B', '\x309C', '\xA804', '\xA804', '\xA808', '\xA808', 
		'\xA80D', '\xA80D', '\xA825', '\xA829', '\xFB20', '\xFB20', '\xFE02', 
		'\xFE11', '\xFE22', '\xFE25', '\xFE35', '\xFE36', '\xFE4F', '\xFE51', 
		'\xFF12', '\xFF1B', '\xFF41', '\xFF41', '\x6', '\x2', ',', ',', '\x2613', 
		'\x2613', '\x2735', '\x2735', '\x2B08', '\x2B08', '\x3', '\x93', '\x2', 
		'%', '\x2', '%', '\x2', ',', '\x2', ',', '\x2', '\x32', '\x2', ';', '\x2', 
		'\xAB', '\x2', '\xAB', '\x2', '\xB0', '\x2', '\xB0', '\x2', '\x203E', 
		'\x2', '\x203E', '\x2', '\x204B', '\x2', '\x204B', '\x2', '\x2124', '\x2', 
		'\x2124', '\x2', '\x213B', '\x2', '\x213B', '\x2', '\x2196', '\x2', '\x219B', 
		'\x2', '\x21AB', '\x2', '\x21AC', '\x2', '\x231C', '\x2', '\x231D', '\x2', 
		'\x232A', '\x2', '\x232A', '\x2', '\x23D1', '\x2', '\x23D1', '\x2', '\x23EB', 
		'\x2', '\x23F5', '\x2', '\x23FA', '\x2', '\x23FC', '\x2', '\x24C4', '\x2', 
		'\x24C4', '\x2', '\x25AC', '\x2', '\x25AD', '\x2', '\x25B8', '\x2', '\x25B8', 
		'\x2', '\x25C2', '\x2', '\x25C2', '\x2', '\x25FD', '\x2', '\x2600', '\x2', 
		'\x2602', '\x2', '\x2606', '\x2', '\x2610', '\x2', '\x2610', '\x2', '\x2613', 
		'\x2', '\x2613', '\x2', '\x2616', '\x2', '\x2617', '\x2', '\x261A', '\x2', 
		'\x261A', '\x2', '\x261F', '\x2', '\x261F', '\x2', '\x2622', '\x2', '\x2622', 
		'\x2', '\x2624', '\x2', '\x2625', '\x2', '\x2628', '\x2', '\x2628', '\x2', 
		'\x262C', '\x2', '\x262C', '\x2', '\x2630', '\x2', '\x2631', '\x2', '\x263A', 
		'\x2', '\x263C', '\x2', '\x2642', '\x2', '\x2642', '\x2', '\x2644', '\x2', 
		'\x2644', '\x2', '\x264A', '\x2', '\x2655', '\x2', '\x2662', '\x2', '\x2662', 
		'\x2', '\x2665', '\x2', '\x2665', '\x2', '\x2667', '\x2', '\x2668', '\x2', 
		'\x266A', '\x2', '\x266A', '\x2', '\x267D', '\x2', '\x267D', '\x2', '\x2681', 
		'\x2', '\x2681', '\x2', '\x2694', '\x2', '\x2699', '\x2', '\x269B', '\x2', 
		'\x269B', '\x2', '\x269D', '\x2', '\x269E', '\x2', '\x26A2', '\x2', '\x26A3', 
		'\x2', '\x26AC', '\x2', '\x26AD', '\x2', '\x26B2', '\x2', '\x26B3', '\x2', 
		'\x26BF', '\x2', '\x26C0', '\x2', '\x26C6', '\x2', '\x26C7', '\x2', '\x26CA', 
		'\x2', '\x26CA', '\x2', '\x26D0', '\x2', '\x26D1', '\x2', '\x26D3', '\x2', 
		'\x26D3', '\x2', '\x26D5', '\x2', '\x26D6', '\x2', '\x26EB', '\x2', '\x26EC', 
		'\x2', '\x26F2', '\x2', '\x26F7', '\x2', '\x26F9', '\x2', '\x26FC', '\x2', 
		'\x26FF', '\x2', '\x26FF', '\x2', '\x2704', '\x2', '\x2704', '\x2', '\x2707', 
		'\x2', '\x2707', '\x2', '\x270A', '\x2', '\x270F', '\x2', '\x2711', '\x2', 
		'\x2711', '\x2', '\x2714', '\x2', '\x2714', '\x2', '\x2716', '\x2', '\x2716', 
		'\x2', '\x2718', '\x2', '\x2718', '\x2', '\x271F', '\x2', '\x271F', '\x2', 
		'\x2723', '\x2', '\x2723', '\x2', '\x272A', '\x2', '\x272A', '\x2', '\x2735', 
		'\x2', '\x2736', '\x2', '\x2746', '\x2', '\x2746', '\x2', '\x2749', '\x2', 
		'\x2749', '\x2', '\x274E', '\x2', '\x274E', '\x2', '\x2750', '\x2', '\x2750', 
		'\x2', '\x2755', '\x2', '\x2757', '\x2', '\x2759', '\x2', '\x2759', '\x2', 
		'\x2765', '\x2', '\x2766', '\x2', '\x2797', '\x2', '\x2799', '\x2', '\x27A3', 
		'\x2', '\x27A3', '\x2', '\x27B2', '\x2', '\x27B2', '\x2', '\x27C1', '\x2', 
		'\x27C1', '\x2', '\x2936', '\x2', '\x2937', '\x2', '\x2B07', '\x2', '\x2B09', 
		'\x2', '\x2B1D', '\x2', '\x2B1E', '\x2', '\x2B52', '\x2', '\x2B52', '\x2', 
		'\x2B57', '\x2', '\x2B57', '\x2', '\x3032', '\x2', '\x3032', '\x2', '\x303F', 
		'\x2', '\x303F', '\x2', '\x3299', '\x2', '\x3299', '\x2', '\x329B', '\x2', 
		'\x329B', '\x2', '\xF006', '\x3', '\xF006', '\x3', '\xF0D1', '\x3', '\xF0D1', 
		'\x3', '\xF172', '\x3', '\xF173', '\x3', '\xF180', '\x3', '\xF181', '\x3', 
		'\xF190', '\x3', '\xF190', '\x3', '\xF193', '\x3', '\xF19C', '\x3', '\xF1E8', 
		'\x3', '\xF201', '\x3', '\xF203', '\x3', '\xF204', '\x3', '\xF21C', '\x3', 
		'\xF21C', '\x3', '\xF231', '\x3', '\xF231', '\x3', '\xF234', '\x3', '\xF23C', 
		'\x3', '\xF252', '\x3', '\xF253', '\x3', '\xF302', '\x3', '\xF323', '\x3', 
		'\xF326', '\x3', '\xF395', '\x3', '\xF398', '\x3', '\xF399', '\x3', '\xF39B', 
		'\x3', '\xF39D', '\x3', '\xF3A0', '\x3', '\xF3F2', '\x3', '\xF3F5', '\x3', 
		'\xF3F7', '\x3', '\xF3F9', '\x3', '\xF4FF', '\x3', '\xF501', '\x3', '\xF53F', 
		'\x3', '\xF54B', '\x3', '\xF550', '\x3', '\xF552', '\x3', '\xF569', '\x3', 
		'\xF571', '\x3', '\xF572', '\x3', '\xF575', '\x3', '\xF57C', '\x3', '\xF589', 
		'\x3', '\xF589', '\x3', '\xF58C', '\x3', '\xF58F', '\x3', '\xF592', '\x3', 
		'\xF592', '\x3', '\xF597', '\x3', '\xF598', '\x3', '\xF5A6', '\x3', '\xF5A7', 
		'\x3', '\xF5AA', '\x3', '\xF5AA', '\x3', '\xF5B3', '\x3', '\xF5B4', '\x3', 
		'\xF5BE', '\x3', '\xF5BE', '\x3', '\xF5C4', '\x3', '\xF5C6', '\x3', '\xF5D3', 
		'\x3', '\xF5D5', '\x3', '\xF5DE', '\x3', '\xF5E0', '\x3', '\xF5E3', '\x3', 
		'\xF5E3', '\x3', '\xF5E5', '\x3', '\xF5E5', '\x3', '\xF5EA', '\x3', '\xF5EA', 
		'\x3', '\xF5F1', '\x3', '\xF5F1', '\x3', '\xF5F5', '\x3', '\xF5F5', '\x3', 
		'\xF5FC', '\x3', '\xF651', '\x3', '\xF682', '\x3', '\xF6C7', '\x3', '\xF6CD', 
		'\x3', '\xF6D4', '\x3', '\xF6E2', '\x3', '\xF6E7', '\x3', '\xF6EB', '\x3', 
		'\xF6EB', '\x3', '\xF6ED', '\x3', '\xF6EE', '\x3', '\xF6F2', '\x3', '\xF6F2', 
		'\x3', '\xF6F5', '\x3', '\xF6FA', '\x3', '\xF912', '\x3', '\xF93C', '\x3', 
		'\xF93E', '\x3', '\xF940', '\x3', '\xF942', '\x3', '\xF947', '\x3', '\xF949', 
		'\x3', '\xF94E', '\x3', '\xF952', '\x3', '\xF96D', '\x3', '\xF982', '\x3', 
		'\xF999', '\x3', '\xF9C2', '\x3', '\xF9C2', '\x3', '\xF9D2', '\x3', '\xF9E8', 
		'\x3', '\x90', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x3', '\'', '\x3', '\x2', '\x2', '\x2', '\x5', '+', '\x3', '\x2', 
		'\x2', '\x2', '\a', '.', '\x3', '\x2', '\x2', '\x2', '\t', '\x32', '\x3', 
		'\x2', '\x2', '\x2', '\v', '\x36', '\x3', '\x2', '\x2', '\x2', '\r', '\x39', 
		'\x3', '\x2', '\x2', '\x2', '\xF', ';', '\x3', '\x2', '\x2', '\x2', '\x11', 
		'>', '\x3', '\x2', '\x2', '\x2', '\x13', '\x44', '\x3', '\x2', '\x2', 
		'\x2', '\x15', 'R', '\x3', '\x2', '\x2', '\x2', '\x17', '\x63', '\x3', 
		'\x2', '\x2', '\x2', '\x19', 't', '\x3', '\x2', '\x2', '\x2', '\x1B', 
		'v', '\x3', '\x2', '\x2', '\x2', '\x1D', 'x', '\x3', '\x2', '\x2', '\x2', 
		'\x1F', '}', '\x3', '\x2', '\x2', '\x2', '!', '\x82', '\x3', '\x2', '\x2', 
		'\x2', '#', '\x84', '\x3', '\x2', '\x2', '\x2', '%', '\x86', '\x3', '\x2', 
		'\x2', '\x2', '\'', '(', '\x5', '\x17', '\f', '\x2', '(', ')', '\a', '\x7A30', 
		'\x2', '\x2', ')', '*', '\a', '\x9860', '\x2', '\x2', '*', '\x4', '\x3', 
		'\x2', '\x2', '\x2', '+', ',', '\x5', '\x17', '\f', '\x2', ',', '-', '\a', 
		'\x500D', '\x2', '\x2', '-', '\x6', '\x3', '\x2', '\x2', '\x2', '.', '/', 
		'\a', '\x5406', '\x2', '\x2', '/', '\x30', '\x5', '\x17', '\f', '\x2', 
		'\x30', '\x31', '\a', '\x500D', '\x2', '\x2', '\x31', '\b', '\x3', '\x2', 
		'\x2', '\x2', '\x32', '\x33', '\a', '\x8A0A', '\x2', '\x2', '\x33', '\x34', 
		'\x5', '\x17', '\f', '\x2', '\x34', '\x35', '\a', '\x500D', '\x2', '\x2', 
		'\x35', '\n', '\x3', '\x2', '\x2', '\x2', '\x36', '\x37', '\x5', '\x17', 
		'\f', '\x2', '\x37', '\x38', '\a', '\x5188', '\x2', '\x2', '\x38', '\f', 
		'\x3', '\x2', '\x2', '\x2', '\x39', ':', '\t', '\x2', '\x2', '\x2', ':', 
		'\xE', '\x3', '\x2', '\x2', '\x2', ';', '<', '\t', '\x3', '\x2', '\x2', 
		'<', '\x10', '\x3', '\x2', '\x2', '\x2', '=', '?', '\t', '\x4', '\x2', 
		'\x2', '>', '=', '\x3', '\x2', '\x2', '\x2', '?', '@', '\x3', '\x2', '\x2', 
		'\x2', '@', '>', '\x3', '\x2', '\x2', '\x2', '@', '\x41', '\x3', '\x2', 
		'\x2', '\x2', '\x41', '\x42', '\x3', '\x2', '\x2', '\x2', '\x42', '\x43', 
		'\b', '\t', '\x2', '\x2', '\x43', '\x12', '\x3', '\x2', '\x2', '\x2', 
		'\x44', 'H', '\x5', '%', '\x13', '\x2', '\x45', 'G', '\n', '\x5', '\x2', 
		'\x2', '\x46', '\x45', '\x3', '\x2', '\x2', '\x2', 'G', 'J', '\x3', '\x2', 
		'\x2', '\x2', 'H', '\x46', '\x3', '\x2', '\x2', '\x2', 'H', 'I', '\x3', 
		'\x2', '\x2', '\x2', 'I', 'K', '\x3', '\x2', '\x2', '\x2', 'J', 'H', '\x3', 
		'\x2', '\x2', '\x2', 'K', 'L', '\b', '\n', '\x2', '\x2', 'L', '\x14', 
		'\x3', '\x2', '\x2', '\x2', 'M', 'O', '\a', '\xF', '\x2', '\x2', 'N', 
		'M', '\x3', '\x2', '\x2', '\x2', 'N', 'O', '\x3', '\x2', '\x2', '\x2', 
		'O', 'P', '\x3', '\x2', '\x2', '\x2', 'P', 'S', '\a', '\f', '\x2', '\x2', 
		'Q', 'S', '\x4', '\xE', '\xF', '\x2', 'R', 'N', '\x3', '\x2', '\x2', '\x2', 
		'R', 'Q', '\x3', '\x2', '\x2', '\x2', 'S', 'U', '\x3', '\x2', '\x2', '\x2', 
		'T', 'V', '\x5', '\x11', '\t', '\x2', 'U', 'T', '\x3', '\x2', '\x2', '\x2', 
		'U', 'V', '\x3', '\x2', '\x2', '\x2', 'V', '\x16', '\x3', '\x2', '\x2', 
		'\x2', 'W', '[', '\x5', '\x1B', '\xE', '\x2', 'X', 'Z', '\x5', '\x1D', 
		'\xF', '\x2', 'Y', 'X', '\x3', '\x2', '\x2', '\x2', 'Z', ']', '\x3', '\x2', 
		'\x2', '\x2', '[', 'Y', '\x3', '\x2', '\x2', '\x2', '[', '\\', '\x3', 
		'\x2', '\x2', '\x2', '\\', '\x64', '\x3', '\x2', '\x2', '\x2', ']', '[', 
		'\x3', '\x2', '\x2', '\x2', '^', '`', '\a', '\x32', '\x2', '\x2', '_', 
		'^', '\x3', '\x2', '\x2', '\x2', '`', '\x61', '\x3', '\x2', '\x2', '\x2', 
		'\x61', '_', '\x3', '\x2', '\x2', '\x2', '\x61', '\x62', '\x3', '\x2', 
		'\x2', '\x2', '\x62', '\x64', '\x3', '\x2', '\x2', '\x2', '\x63', 'W', 
		'\x3', '\x2', '\x2', '\x2', '\x63', '_', '\x3', '\x2', '\x2', '\x2', '\x64', 
		'\x18', '\x3', '\x2', '\x2', '\x2', '\x65', 'i', '\x5', '\x1F', '\x10', 
		'\x2', '\x66', 'h', '\x5', '!', '\x11', '\x2', 'g', '\x66', '\x3', '\x2', 
		'\x2', '\x2', 'h', 'k', '\x3', '\x2', '\x2', '\x2', 'i', 'g', '\x3', '\x2', 
		'\x2', '\x2', 'i', 'j', '\x3', '\x2', '\x2', '\x2', 'j', 'u', '\x3', '\x2', 
		'\x2', '\x2', 'k', 'i', '\x3', '\x2', '\x2', '\x2', 'l', 'n', '\a', '*', 
		'\x2', '\x2', 'm', 'o', '\x5', '!', '\x11', '\x2', 'n', 'm', '\x3', '\x2', 
		'\x2', '\x2', 'o', 'p', '\x3', '\x2', '\x2', '\x2', 'p', 'n', '\x3', '\x2', 
		'\x2', '\x2', 'p', 'q', '\x3', '\x2', '\x2', '\x2', 'q', 'r', '\x3', '\x2', 
		'\x2', '\x2', 'r', 's', '\a', '+', '\x2', '\x2', 's', 'u', '\x3', '\x2', 
		'\x2', '\x2', 't', '\x65', '\x3', '\x2', '\x2', '\x2', 't', 'l', '\x3', 
		'\x2', '\x2', '\x2', 'u', '\x1A', '\x3', '\x2', '\x2', '\x2', 'v', 'w', 
		'\t', '\x6', '\x2', '\x2', 'w', '\x1C', '\x3', '\x2', '\x2', '\x2', 'x', 
		'y', '\t', '\a', '\x2', '\x2', 'y', '\x1E', '\x3', '\x2', '\x2', '\x2', 
		'z', '~', '\t', '\b', '\x2', '\x2', '{', '~', '\x5', '#', '\x12', '\x2', 
		'|', '~', '\t', '\t', '\x2', '\x2', '}', 'z', '\x3', '\x2', '\x2', '\x2', 
		'}', '{', '\x3', '\x2', '\x2', '\x2', '}', '|', '\x3', '\x2', '\x2', '\x2', 
		'~', ' ', '\x3', '\x2', '\x2', '\x2', '\x7F', '\x83', '\x5', '\x1F', '\x10', 
		'\x2', '\x80', '\x83', '\x5', '#', '\x12', '\x2', '\x81', '\x83', '\t', 
		'\n', '\x2', '\x2', '\x82', '\x7F', '\x3', '\x2', '\x2', '\x2', '\x82', 
		'\x80', '\x3', '\x2', '\x2', '\x2', '\x82', '\x81', '\x3', '\x2', '\x2', 
		'\x2', '\x83', '\"', '\x3', '\x2', '\x2', '\x2', '\x84', '\x85', '\t', 
		'\f', '\x2', '\x2', '\x85', '$', '\x3', '\x2', '\x2', '\x2', '\x86', '\x87', 
		'\t', '\v', '\x2', '\x2', '\x87', '&', '\x3', '\x2', '\x2', '\x2', '\x10', 
		'\x2', '@', 'H', 'N', 'R', 'U', '[', '\x61', '\x63', 'i', 'p', 't', '}', 
		'\x82', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
