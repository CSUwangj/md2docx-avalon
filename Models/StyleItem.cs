using MD2DocxCore;

namespace MD2DocxAvalon.Models {
  public class StyleItem {
    public StyleItem Clone() {
      return (StyleItem)MemberwiseClone();
    }
    // Models don't need id for copy, but stupid c# doesn't allow multiple inheritance
    public int ID { get; set; }
    public Style Style { get; set; }


    public StyleItem(int id) {
      ID = id;
      Style = new Style();
    }
  }

}
