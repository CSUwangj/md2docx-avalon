using DocumentFormat.OpenXml.Wordprocessing;
using MD2DocxCore;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using DocxStyle = DocumentFormat.OpenXml.Wordprocessing.Style;
using Style = MD2DocxCore.Style;

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
          StyleId = "一级标题",
          StyleName = new() {
            Val = "一级标题"
          },
          StyleParagraphProperties = new() {
            PageBreakBefore = new(),
            SpacingBetweenLines = new() {
              BeforeLines = 100, AfterLines = 100
            },
            Justification = new() {
              Val = JustificationValues.Center
            },
            OutlineLevel = new() {
              Val = 0
            }
          },
          StyleRunProperties = new() {
            RunFonts = new() {
              Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "黑体", ComplexScript = "Times New Roman"
            },
            FontSize = new() {
              Val = "32"
            },
            FontSizeComplexScript = new() {
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
          StyleId = "二级标题",
          StyleName = new() {
            Val = "二级标题"
          },
          StyleParagraphProperties = new() {
            Justification = new() {
              Val = JustificationValues.Left
            },
            OutlineLevel = new() {
              Val = 1
            },
            Indentation = new() {
              FirstLineChars = 200
            },
          },
          StyleRunProperties = new() {
            RunFonts = new() {
              Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "黑体", ComplexScript = "Times New Roman"
            },
            FontSize = new() {
              Val = "24"
            },
            FontSizeComplexScript = new() {
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
          StyleId = "三级标题",
          StyleName = new() {
            Val = "三级标题"
          },
          StyleParagraphProperties = new() {
            Justification = new() {
              Val = JustificationValues.Left
            },
            OutlineLevel = new() {
              Val = 2
            },
            Indentation = new() {
              FirstLineChars = 200
            }
          },
          StyleRunProperties = new() {
            RunFonts = new() {
              Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "楷体", ComplexScript = "Times New Roman"
            },
            FontSize = new() {
              Val = "24"
            },
            FontSizeComplexScript = new() {
              Val = "24"
            }
          }
        }
      },
      new object[] {
        new Style {
          Mapping = "正 文",
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
          StyleId = "正 文",
          StyleName = new() {
            Val = "正 文"
          },
          StyleParagraphProperties = new() {
            Justification = new() {
              Val = JustificationValues.Left
            },
            Indentation = new() {
              FirstLineChars = 200
            },
            SpacingBetweenLines = new() {
              Line = "360", LineRule = LineSpacingRuleValues.Auto
            }
          },
          StyleRunProperties = new() {
            RunFonts = new() {
              Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "宋体", ComplexScript = "Times New Roman"
            },
            FontSize = new() {
              Val = "24"
            },
            FontSizeComplexScript = new() {
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
          StyleId = "代码段",
          StyleName = new() {
            Val = "代码段"
          },
          StyleParagraphProperties = new() {
            Justification = new() {
              Val = JustificationValues.Left
            },
          },
          StyleRunProperties = new() {
            RunFonts = new() {
              Ascii = "Consolas", HighAnsi = "Consolas", EastAsia = "黑体", ComplexScript = "Consolas"
            },
            FontSize = new() {
              Val = "24"
            },
            FontSizeComplexScript = new() {
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
          Justification = "两端对齐",
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
          StyleId = "参考文献",
          StyleName = new() {
            Val = "参考文献"
          },
          StyleParagraphProperties = new() {
            Justification = new() {
              Val = JustificationValues.Both
            },
            SpacingBetweenLines = new() {
              Line = "360", LineRule = LineSpacingRuleValues.Auto
            }
          },
          StyleRunProperties = new() {
            RunFonts = new() {
              Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "黑体", ComplexScript = "Times New Roman"
            },
            FontSize = new() {
              Val = "21"
            },
            FontSizeComplexScript = new() {
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