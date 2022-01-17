using System.Collections.Generic;

namespace MD2DocxCore {
  public class Style {
    private string fontSizeString = "四号";
    public string FontSize { get; set; } = "28";
    public string Justification { get; set; } = "两端对齐";
    public string CnFont { get; set; } = "宋体";
    public string EnFont { get; set; } = "Times New Roman";
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
    public string Mapping { get; set; }
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
