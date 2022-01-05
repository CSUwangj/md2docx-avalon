using System.Collections.Generic;

namespace MD2DocxCore {
  public class Style {
    public Style() {
      fontSizeString = "四号";
      FontSize = "28";
      Name = "正文";
      Justification = "两端对齐";
      CnFont = "宋体";
      EnFont = "Times New Roman";
      Outline = false;
      OutlineLevel = 1;
      Bold = false;
      Italic = false;
      Underline = false;
      Strike = false;
      LineBeforeAndAfter = false;
      Indentation = 2;
      SpacingBetweenLines = 1.5;
      PageBreakBefore = false;
    }

    private string fontSizeString;
    public string FontSize { get; set; }
    public string Name { get; set; }
    public string Justification { get; set; } 
    public string CnFont { get; set; }
    public string EnFont { get; set; }
    public bool Outline { get; set; }
    public int OutlineLevel { get; set; }
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public bool Underline { get; set; }
    public bool Strike { get; set; }
    public bool PageBreakBefore { get; set; }
    public bool LineBeforeAndAfter { get; set; }
    public double Indentation { get; set; }
    public double SpacingBetweenLines { get; set; }
    public string FontSizeString {
      get => fontSizeString;
      set {
        if (double.TryParse(value, out double _)) {
          FontSize = value;
        } else if (fontmap.ContainsKey(value)) {
          FontSize = fontmap[value];
        }
        fontSizeString = value;
      }
    }

    #region Chinese font mapping
    static private readonly Dictionary<string, string> fontmap = new() {
      { "初号", "84" },
      { "小初", "72" },
      { "一号", "52" },
      { "小一", "48" },
      { "二号", "44" },
      { "小二", "36" },
      { "三号", "32" },
      { "小三", "30" },
      { "四号", "28" },
      { "小四", "24" },
      { "五号", "21" },
      { "小五", "18" },
      { "六号", "15" },
      { "小六", "13" },
      { "七号", "11" },
      { "八号", "10" }
    };
    #endregion
  }
}
