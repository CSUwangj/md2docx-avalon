using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ReactiveUI;
using System.Threading.Tasks;

namespace MD2DocxAvalon.Services {
  public enum BibliographyType {
    图书,
    会议,
    期刊,
    学位论文,
    专利,
    报告,
    数据库,
    网页,
    计算机程序,
  }
  public class BibliographyGenerator: ReactiveObject {
    private BibliographyType type = BibliographyType.图书;
    public BibliographyType Type {
      get => type;
      set {
        type = value;
        if(locationMap.ContainsKey(value)) {
          LocationText = locationMap[value];
          LocationEnabled = true;
        } else {
          LocationEnabled = false;
        }
        SourceText = sourceMap[Type] ?? "";
      }
    }
    private string sourceText = sourceMap[BibliographyType.图书];
    private string locationText = locationMap[BibliographyType.图书];
    private bool locationEnabled = true;
    public string SourceText { 
      get => sourceText; 
      set => this.RaiseAndSetIfChanged(ref sourceText, value); 
    }
    public string LocationText { 
      get => locationText; 
      set => this.RaiseAndSetIfChanged(ref locationText, value); 
    } 
    public bool LocationEnabled {
      get => locationEnabled;
      set => this.RaiseAndSetIfChanged(ref locationEnabled, value);
    }

    public string Author { get; set; } = "";
    public string Title { get; set; } = "";
    public string Location { get; set; } = "";
    public string Source { get; set; } = "";
    public string Year { get; set; } = "";
    public bool IsOnline { get; set; } = false;
    private string result = "";
    public string Result {
      get => result;
      set => this.RaiseAndSetIfChanged(ref result, value); 
    }

    public void Generate() {
      switch (Type) {
        case BibliographyType.图书:
        case BibliographyType.学位论文:
          Result = $"{Author}.{Title}[{codeMap[Type]}{(IsOnline ? "/OL" : "")}].{Location}:{Source}.{Year}.";
          break;
        case BibliographyType.会议:
          Result = $"{Author}.{Title}:{Source}[{codeMap[Type]}{(IsOnline ? "/OL" : "")}].{Location}.{Year}.";
          break;
        case BibliographyType.期刊:
          Result = $"{Author}.{Title}[{codeMap[Type]}{(IsOnline ? "/OL" : "")}].{Source}.{Year}.";
          break;
        case BibliographyType.专利:
          Result = $"{Author}.{Title}:{Source}[{codeMap[Type]}{(IsOnline ? "/OL" : "")}].{Year}.";
          break;
        case BibliographyType.报告:
        case BibliographyType.数据库:
        case BibliographyType.网页:
        case BibliographyType.计算机程序:
          Result = $"{Author}.{Title}[{codeMap[Type]}{(IsOnline ? "/OL" : "")}].{Year}.{Source}";
          break;
        default:
          throw new ArgumentException();
      }
    }

    static private readonly Dictionary<BibliographyType, string> sourceMap = new() {
      { BibliographyType.图书, "出版社：" },
      { BibliographyType.会议, "会议：" },
      { BibliographyType.期刊, "期刊：" },
      { BibliographyType.学位论文, "机构：" },
      { BibliographyType.专利, "专利号：" },
      { BibliographyType.报告, "来源：" },
      { BibliographyType.数据库, "来源：" },
      { BibliographyType.网页, "来源：" },
      { BibliographyType.计算机程序, "来源：" }
    };
    static private readonly Dictionary<BibliographyType, string> locationMap = new() {
      { BibliographyType.图书, "出版社地点：" },
      { BibliographyType.会议, "会议地点：" },
      { BibliographyType.学位论文, "学位论文地点：" },
    };

    static private readonly Dictionary<BibliographyType, string> codeMap = new() {
      { BibliographyType.图书, "M" },
      { BibliographyType.会议, "C" },
      { BibliographyType.期刊, "J" },
      { BibliographyType.学位论文, "D" },
      { BibliographyType.专利, "P" },
      { BibliographyType.报告, "R" },
      { BibliographyType.数据库, "DB" },
      { BibliographyType.网页, "EB" },
      { BibliographyType.计算机程序, "CP" }
    };
  }

  public class ComparisonConverter : IValueConverter {
#pragma warning disable CS8767 // 参数类型中引用类型的为 Null 性与隐式实现的成员不匹配(可能是由于为 Null 性特性)。
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
#pragma warning restore CS8767 // 参数类型中引用类型的为 Null 性与隐式实现的成员不匹配(可能是由于为 Null 性特性)。
      if (value == null) {
        return false;
      }
      return value.Equals(parameter);
    }

#pragma warning disable CS8767 // 参数类型中引用类型的为 Null 性与隐式实现的成员不匹配(可能是由于为 Null 性特性)。
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
#pragma warning restore CS8767 // 参数类型中引用类型的为 Null 性与隐式实现的成员不匹配(可能是由于为 Null 性特性)。
      if (value != null) {
        return (bool)value ? parameter : BindingOperations.DoNothing;
      }
      return BindingOperations.DoNothing;
    }
  }
}
