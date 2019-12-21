using Antlr4.Runtime;
using Antlr4CodeCompletion.Core.CodeCompletion;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            {
                var input = @"grammar Expr;

expression: assignment | simpleExpression;

assignment
    : (VAR | LET) ID EQUAL simpleExpression
;

simpleExpression
    : simpleExpression (PLUS | MINUS) simpleExpression
    | simpleExpression (MULTIPLY | DIVIDE) simpleExpression
    | variableRef
    | functionRef
;

variableRef
    : ID
;

functionRef
    : ID OPEN_PAR CLOSE_PAR
;

VAR: [vV] [aA] [rR];
LET: [lL] [eE] [tT];

PLUS: '+';
MINUS: '-';
MULTIPLY: '*';
DIVIDE: '/';
EQUAL: '=';
OPEN_PAR: '(';
CLOSE_PAR: ')';
ID: [a-zA-Z] [a-zA-Z0-9_]*;
WS: [ \n\r\t] -> channel(HIDDEN);
";

                var inputStream = new AntlrInputStream(input);
                var lexer = new ANTLRv4Lexer(inputStream);
                var tokenStream = new CommonTokenStream(lexer);
                var parser = new ANTLRv4Parser(tokenStream);

                lexer.RemoveErrorListeners();
                parser.RemoveErrorListeners();

                var errorListener = new CountingErrorListener();
                parser.AddErrorListener(errorListener);
                var tree = parser.grammarSpec();
                Assert.True(errorListener.ErrorCount == 0);
                var core = new CodeCompletionCore(parser, null, null);

                {
                    var candidates = core.CollectCandidates(0, null);
                    var t1 = candidates.Tokens.Count == 4;
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.DOC_COMMENT));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.GRAMMAR));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.PARSER));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.LEXER));
                }

                {
                    int index = 0;
                    foreach (var t in tokenStream.GetTokens())
                    {
                        if (t.Text == "assignment") // Stop on first "assignment"
                        {
                            index = t.TokenIndex;
                            break;
                        }
                    }
                    var candidates = core.CollectCandidates(index, null);
                    Assert.True(index == 8);
                    Assert.True(candidates.Tokens.Count == 9);
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.TOKEN_REF));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.RULE_REF));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.STRING_LITERAL));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.BEGIN_ACTION));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.LPAREN));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.LT));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.DOT));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.NOT));
                    Assert.True(candidates.Tokens.ContainsKey(-2));
                }

                {
                    int index = 0;
                    foreach (var t in tokenStream.GetTokens())
                    {
                        if (t.Text == ":") // Stop on first ":"
                        {
                            index = t.TokenIndex;
                            break;
                        }
                    }
                    var candidates = core.CollectCandidates(index, null);
                    Assert.True(index == 6);
                    Assert.True(candidates.Tokens.Count == 7);
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.BEGIN_ARGUMENT));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.OPTIONS));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.RETURNS));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.LOCALS));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.THROWS));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.COLON));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.AT));
                }
            }

            {
                var input = @"grammar Expr;

expression: assignment | simpleExpression;

assignment
    : (VAR | LET) ID EQUAL simpleExpression
;


";

                var inputStream = new AntlrInputStream(input);
                var lexer = new ANTLRv4Lexer(inputStream);
                var tokenStream = new CommonTokenStream(lexer);
                var parser = new ANTLRv4Parser(tokenStream);

                lexer.RemoveErrorListeners();
                parser.RemoveErrorListeners();

                var errorListener = new CountingErrorListener();
                parser.AddErrorListener(errorListener);
                var tree = parser.grammarSpec();
                Assert.True(errorListener.ErrorCount == 0);
                var core = new CodeCompletionCore(parser, null, null);

                {
                    var candidates = core.CollectCandidates(0, null);
                    var t1 = candidates.Tokens.Count == 4;
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.DOC_COMMENT));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.GRAMMAR));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.PARSER));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.LEXER));
                }

                {
                    int index = 0;
                    foreach (var t in tokenStream.GetTokens())
                    {
                        if (t.Text == "assignment") // Stop on first "assignment"
                        {
                            index = t.TokenIndex;
                            break;
                        }
                    }
                    var candidates = core.CollectCandidates(index, null);
                    Assert.True(index == 8);
                    Assert.True(candidates.Tokens.Count == 9);
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.TOKEN_REF));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.RULE_REF));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.STRING_LITERAL));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.BEGIN_ACTION));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.LPAREN));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.LT));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.DOT));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.NOT));
                    Assert.True(candidates.Tokens.ContainsKey(-2));
                }

                {
                    int index = 0;
                    foreach (var t in tokenStream.GetTokens())
                    {
                        if (t.Text == ":") // Stop on first ":"
                        {
                            index = t.TokenIndex;
                            break;
                        }
                    }
                    var candidates = core.CollectCandidates(index, null);
                    Assert.True(index == 6);
                    Assert.True(candidates.Tokens.Count == 7);
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.BEGIN_ARGUMENT));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.OPTIONS));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.RETURNS));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.LOCALS));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.THROWS));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.COLON));
                    Assert.True(candidates.Tokens.ContainsKey(ANTLRv4Parser.AT));
                }

                {
                    int index = 0;
                    int times = 0;
                    foreach (var t in tokenStream.GetTokens())
                    {
                        if (t.Text == ";") // Stop on ";"
                        {
                            if (++times == 3)
                            {
                                index = t.TokenIndex + 1;
                                break;
                            }
                        }
                    }
                    var candidates = core.CollectCandidates(index, null);
                    // candidates includes CATCH, FINALLY, -2. Why? Why not include
                    // DOC_COMMENT, RULE_REF, ...?
                }
            }
        }
    }
}
