using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using DocxStyle = DocumentFormat.OpenXml.Wordprocessing.Style;

namespace MD2DocxCore {
  public class StyleFactory {
    public static DocxStyle GenerateStyle(Style style) {
      StyleParagraphProperties paragraphProperties = new() {
        Justification = new() { Val = justmap[style.Justification] }
      };
      if (style.Outline) {
        paragraphProperties.OutlineLevel = new() { Val = style.OutlineLevel };
      }
      if (style.PageBreakBefore) {
        paragraphProperties.PageBreakBefore = new();
      }
      if (style.Indentation != 0) {
        paragraphProperties.Indentation = new() {
          FirstLineChars = (int)(style.Indentation * 100)
        };
      }
      if (style.LineBeforeAndAfter != 0) {
        paragraphProperties.SpacingBetweenLines = new() {
          BeforeLines = (int)(style.LineBeforeAndAfter * 100),
          AfterLines = (int)(style.LineBeforeAndAfter * 100),
        };
      }
      if (style.SpacingBetweenLines != 0) {
        if (paragraphProperties.SpacingBetweenLines == null) paragraphProperties.SpacingBetweenLines = new();
        paragraphProperties.SpacingBetweenLines.Line = (style.SpacingBetweenLines * 240).ToString();
        paragraphProperties.SpacingBetweenLines.LineRule = LineSpacingRuleValues.Auto;
      }
      StyleRunProperties runProperties = new() {
        RunFonts = new() {
          Ascii = style.EnFont,
          HighAnsi = style.EnFont,
          ComplexScript = style.EnFont,
          EastAsia = style.CnFont
        },
        FontSize = new() { Val = style.FontSize },
        FontSizeComplexScript = new() { Val = style.FontSize },
      };
      if (style.Bold) {
        runProperties.Bold = new();
        runProperties.BoldComplexScript = new();
      }
      if (style.Italic) {
        runProperties.Italic = new();
        runProperties.ItalicComplexScript = new();
      }
      if (style.Strike) {
        runProperties.Strike = new();
      }
      if (style.Underline) {
        runProperties.Underline = new();
      }
      DocxStyle result = new() {
        Type = StyleValues.Paragraph,
        StyleId = style.Mapping,
        StyleName = new() { Val = style.Mapping },
        StyleParagraphProperties = paragraphProperties,
        StyleRunProperties = runProperties
      };
      return result;
    }

    #region justification mapping
    private static readonly Dictionary<string, JustificationValues> justmap = new() {
      { "左对齐", JustificationValues.Left },
      { "居中", JustificationValues.Center },
      { "右对齐", JustificationValues.Right },
      { "两端对齐", JustificationValues.Both },
      { "分散对齐", JustificationValues.Distribute }
    };
    #endregion
  }
}
