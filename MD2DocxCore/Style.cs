using System.Collections.Generic;

namespace MD2DocxCore {
  public class Style {
    private static readonly List<string> justifications = new() {
      "左对齐",
      "居中",
      "右对齐",
      "两端对齐",
      "分散对齐"
    };
    public static List<string> Justifications { get => justifications; }
    private static readonly List<string> mappings = new() {
      "正 文",
      "一级标题",
      "二级标题",
      "三级标题",
      "四级标题",
      "五级标题",
      "六级标题",
      "七级标题",
      "八级标题",
      "九级标题",
      "代码段",
      "引用段落",
      "摘要标题",
      "摘要副标题",
      "参考文献标题",
      "参考文献",
      "图题图序",
      "表题表序"
    };
    public static List<string> Mappings { get => mappings; }

    public Style Clone() {
      Style newStyle = (Style)MemberwiseClone();
      // stupid c#
      newStyle.FontSizeString = new string(fontSizeString.ToCharArray());
      newStyle.Justification = new string(Justification.ToCharArray());
      newStyle.CnFont = new string(CnFont.ToCharArray());
      newStyle.EnFont = new string(EnFont.ToCharArray());
      newStyle.Mapping = new string(Mapping.ToCharArray());
      newStyle.fontSizeString = new string(fontSizeString.ToCharArray()); 
      return newStyle;
    }

    private string fontSizeString = "四号";
    public string FontSize { get; set; } = "28";
    public string Justification { get; set; } = "两端对齐";
    public string CnFont { get; set; } = "宋体";
    public string EnFont { get; set; } = "Times New Roman";
    public bool Outline { get; set; }
    public int OutlineLevel { get; set; } = 1;
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public bool Underline { get; set; }
    public bool Strike { get; set; }
    public bool PageBreakBefore { get; set; }
    public double LineBeforeAndAfter { get; set; }
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
