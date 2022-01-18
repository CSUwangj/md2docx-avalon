using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocxStyle = DocumentFormat.OpenXml.Wordprocessing.Style;

namespace MD2DocxCore {
  public class StyleFactory {
    public static DocxStyle GenerateStyle(Style style) {
      return new();
    }
  }
}
