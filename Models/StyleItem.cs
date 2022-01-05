using System;
using System.Collections.Generic;

namespace MD2DocxAvalon.Models {
  public class StyleItem {
    public StyleItem Clone() {
      return (StyleItem)MemberwiseClone();
    }
    // Models don't need id for copy, but stupid c# doesn't allow multiple inheritance
    public int ID { get; set; }
    public MD2DocxCore.Style Style { get; set; }


    public StyleItem(int id) {
      ID = id;
      Style = new MD2DocxCore.Style();
    }
  }

}
