using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;

namespace MD2DocxAvalon.ViewModels {
  class StyleListItemViewModel : ViewModelBase {
    string name;
    string justification;
    string cnFont;
    string enFont;
    string fontSizeString;
    string fontSize;
    bool outline;
    int outlineLevel = 1;
    bool bold;
    bool italic;
    bool underline;
    bool strike;
    bool pageBreakBefore;
    bool lineBeforeAndAfter;
    double indentation;
    double spacingBetweenLines;
    public StyleListItemViewModel() {
      name = "正文";
      justification = "两端对齐";
      cnFont = "宋体";
      enFont = "Times New Roman";
      fontSizeString = "四号";
      fontSize = "28";
    }

    public string Name {
      get => name;
      set => this.RaiseAndSetIfChanged(ref name, value);
    }
    public string Justification {
      get => name;
      set => this.RaiseAndSetIfChanged(ref justification, value);
    }
    public string CnFont {
      get => cnFont;
      set => this.RaiseAndSetIfChanged(ref cnFont, value);
    }
    public string EnFont {
      get => enFont;
      set => this.RaiseAndSetIfChanged(ref enFont, value);
    }
    public string FontSizeString {
      get => fontSizeString;
      set {
        if (int.TryParse(value, out int _)) {
          fontSize = value;
        } else if (fontmap.ContainsKey(value)) {
          fontSize = fontmap[value];
        } else {
          throw new System.Exception("非法的字体大小");
        }
        this.RaiseAndSetIfChanged(ref fontSizeString, value);
      }
    }
    public bool Outline {
      get => outline;
      set => this.RaiseAndSetIfChanged(ref outline, value);
    }
    public int OutlineLevel {
      get => outlineLevel;
      set => this.RaiseAndSetIfChanged(ref outlineLevel, value);
    }
    public bool Bold {
      get => bold;
      set => this.RaiseAndSetIfChanged(ref bold, value);
    }
    public bool Italic {
      get => italic;
      set => this.RaiseAndSetIfChanged(ref italic, value);
    }
    public bool Underline {
      get => underline;
      set => this.RaiseAndSetIfChanged(ref underline, value);
    }
    public bool Strike {
      get => strike;
      set => this.RaiseAndSetIfChanged(ref strike, value);
    }
    public bool PageBreakBefore {
      get => pageBreakBefore;
      set => this.RaiseAndSetIfChanged(ref pageBreakBefore, value);
    }
    public bool LineBeforeAndAfter {
      get => lineBeforeAndAfter;
      set => this.RaiseAndSetIfChanged(ref lineBeforeAndAfter, value);
    }
    public double Indentation {
      get => indentation;
      set => this.RaiseAndSetIfChanged(ref indentation, value);
    }
    public double SpacingBetweenLines {
      get => spacingBetweenLines;
      set => this.RaiseAndSetIfChanged(ref spacingBetweenLines, value);
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
