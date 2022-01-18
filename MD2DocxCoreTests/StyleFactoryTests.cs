using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using MD2DocxCore;
using DocxStyle = DocumentFormat.OpenXml.Wordprocessing.Style;
using Style = MD2DocxCore.Style;
using System.Collections;

namespace MD2DocxCoreTest {

  public class StyleFactoryTests {
    private readonly ITestOutputHelper output;

    public StyleFactoryTests(ITestOutputHelper output) {
      this.output = output;
    }

    [Theory]
    [ClassData(typeof(CSUStyleTestData))]
    public void CSUStyleTests(Style style, DocxStyle expected) {
      DocxStyle result = StyleFactory.GenerateStyle(style);

      output.WriteLine(expected.OuterXml);
      output.WriteLine(result.OuterXml);

      Assert.Equal(result.OuterXml, expected.OuterXml);
    }
  }

  public class CSUStyleTestData : IEnumerable<object[]> {
    private readonly List<object[]> _data = new() {
      new object[] {
          new Style {
            Mapping = "一级标题",
            CnFont = "黑体",
            EnFont = "Times New Roman",
            FontSize = "32",
            Justification = "居中",
            Outline = true,
            OutlineLevel = 0,
            Bold = false,
            Italic = false,
            Underline = false,
            Strike = false,
            Indentation = 0,
            PageBreakBefore = true,
            LineBeforeAndAfter = 1,
            SpacingBetweenLines = 0
          },
          new DocxStyle {
            Type = StyleValues.Paragraph,
              StyleId = "heading 1",
              StyleName = new StyleName {
                Val = "heading 1"
              },
              StyleParagraphProperties = new StyleParagraphProperties {
                PageBreakBefore = new PageBreakBefore(),
                  SpacingBetweenLines = new SpacingBetweenLines() {
                    BeforeLines = 100, AfterLines = 100
                  },
                  Justification = new Justification() {
                    Val = JustificationValues.Center
                  },
                  OutlineLevel = new OutlineLevel() {
                    Val = 0
                  }
              },
              StyleRunProperties = new StyleRunProperties {
                RunFonts = new RunFonts() {
                    Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "黑体", ComplexScript = "Times NewRoman"
                  },
                  FontSize = new FontSize {
                    Val = "32"
                  },
                  FontSizeComplexScript = new FontSizeComplexScript {
                    Val = "32"
                  }
              }
          }
        },
      new object[] {
          new Style {
            Mapping = "二级标题",
              CnFont = "黑体",
              EnFont = "Times New Roman",
              FontSize = "24",
              Justification = "左对齐",
              Outline = true,
              OutlineLevel = 1,
              Bold = false,
              Italic = false,
              Underline = false,
              Strike = false,
              Indentation = 2,
              PageBreakBefore = false,
              LineBeforeAndAfter = 0,
              SpacingBetweenLines = 0
          },
          new DocxStyle {
            Type = StyleValues.Paragraph,
              StyleId = "heading 2",
              StyleName = new StyleName {
                Val = "heading 2"
              },
              StyleParagraphProperties = new StyleParagraphProperties {
                Justification = new Justification() {
                    Val = JustificationValues.Left
                  },
                  OutlineLevel = new OutlineLevel() {
                    Val = 1
                  },
                  Indentation = new Indentation() {
                    FirstLineChars = 200
                  },
              },
              StyleRunProperties = new StyleRunProperties {
                RunFonts = new RunFonts() {
                    Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "黑体", ComplexScript = "Times New Roman"
                  },
                  FontSize = new FontSize {
                    Val = "24"
                  },
                  FontSizeComplexScript = new FontSizeComplexScript {
                    Val = "24"
                  }
              }
          }
        },
      new object[] {
          new Style {
            Mapping = "三级标题",
              CnFont = "楷体",
              EnFont = "Times New Roman",
              FontSize = "24",
              Justification = "左对齐",
              Outline = true,
              OutlineLevel = 2,
              Bold = false,
              Italic = false,
              Underline = false,
              Strike = false,
              Indentation = 2,
              PageBreakBefore = false,
              LineBeforeAndAfter = 0,
              SpacingBetweenLines = 0
          },
          new DocxStyle {
            Type = StyleValues.Paragraph,
              StyleId = "heading 3",
              StyleName = new StyleName {
                Val = "heading 3"
              },
              StyleParagraphProperties = new StyleParagraphProperties {
                Justification = new Justification() {
                    Val = JustificationValues.Left
                  },
                  OutlineLevel = new OutlineLevel() {
                    Val = 2
                  },
                  Indentation = new Indentation() {
                    FirstLineChars = 200
                  }
              },
              StyleRunProperties = new StyleRunProperties {
                RunFonts = new RunFonts() {
                    Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "楷体", ComplexScript = "Times New Roman"
                  },
                  FontSize = new FontSize {
                    Val = "24"
                  },
                  FontSizeComplexScript = new FontSizeComplexScript {
                    Val = "24"
                  }
              }
          }
        },
      new object[] {
          new Style {
            Mapping = "正文",
              CnFont = "宋体",
              EnFont = "Times New Roman",
              FontSize = "24",
              Justification = "左对齐",
              Outline = false,
              OutlineLevel = 9,
              Bold = false,
              Italic = false,
              Underline = false,
              Strike = false,
              Indentation = 2,
              PageBreakBefore = false,
              LineBeforeAndAfter = 0,
              SpacingBetweenLines = 1.5
          },
          new DocxStyle {
            Type = StyleValues.Paragraph,
              StyleId = "bodytext",
              StyleName = new StyleName {
                Val = "bodytext"
              },
              StyleParagraphProperties = new StyleParagraphProperties {
                Justification = new Justification() {
                    Val = JustificationValues.Left
                  },
                  Indentation = new Indentation() {
                    FirstLineChars = 200
                  },
                  SpacingBetweenLines = new SpacingBetweenLines {
                    Line = "360", LineRule = LineSpacingRuleValues.Auto
                  }
              },
              StyleRunProperties = new StyleRunProperties {
                RunFonts = new RunFonts() {
                    Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "宋体", ComplexScript = "Times New Roman"
                  },
                  FontSize = new FontSize {
                    Val = "24"
                  },
                  FontSizeComplexScript = new FontSizeComplexScript {
                    Val = "24"
                  }
              }
          }
        },
      new object[] {
          new Style {
            Mapping = "代码段",
              CnFont = "黑体",
              EnFont = "Consolas",
              FontSize = "24",
              Justification = "左对齐",
              Outline = false,
              OutlineLevel = 2,
              Bold = false,
              Italic = false,
              Underline = false,
              Strike = false,
              Indentation = 0,
              PageBreakBefore = false,
              LineBeforeAndAfter = 0,
              SpacingBetweenLines = 0
          },
          new DocxStyle {
            Type = StyleValues.Paragraph,
              StyleId = "code",
              StyleName = new StyleName {
                Val = "code"
              },
              StyleParagraphProperties = new StyleParagraphProperties {
                Justification = new Justification() {
                  Val = JustificationValues.Left
                },
              },
              StyleRunProperties = new StyleRunProperties {
                RunFonts = new RunFonts() {
                    Ascii = "Consolas", HighAnsi = "Consolas", EastAsia = "黑体", ComplexScript = "Consolas"
                  },
                  FontSize = new FontSize {
                    Val = "24"
                  },
                  FontSizeComplexScript = new FontSizeComplexScript {
                    Val = "24"
                  }
              }
          }
        },
      new object[] {
          new Style {
            Mapping = "参考文献",
              CnFont = "黑体",
              EnFont = "Times New Roman",
              FontSize = "21",
              Justification = "左对齐",
              Outline = false,
              OutlineLevel = 1,
              Bold = false,
              Italic = false,
              Underline = false,
              Strike = false,
              Indentation = 0,
              PageBreakBefore = false,
              LineBeforeAndAfter = 0,
              SpacingBetweenLines = 1.5
          },
          new DocxStyle {
            Type = StyleValues.Paragraph,
              StyleId = "reference",
              StyleName = new StyleName {
                Val = "reference"
              },
              StyleParagraphProperties = new StyleParagraphProperties {
                Justification = new Justification() {
                    Val = JustificationValues.Left
                  },
                  SpacingBetweenLines = new SpacingBetweenLines {
                    Line = "360", LineRule = LineSpacingRuleValues.Auto
                  }
              },
              StyleRunProperties = new StyleRunProperties {
                RunFonts = new RunFonts() {
                    Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "黑体", ComplexScript = "Times New Roman"
                  },
                  FontSize = new FontSize {
                    Val = "21"
                  },
                  FontSizeComplexScript = new FontSizeComplexScript {
                    Val = "21"
                  }
              }
          }
        }
    };

    public IEnumerator<object[]> GetEnumerator() {
      return _data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return GetEnumerator();
    }
  }
}