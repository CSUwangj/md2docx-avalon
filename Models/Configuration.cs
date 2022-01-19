using MD2DocxCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MD2DocxAvalon.Models {
  [JsonObject]
  public class Configuration {
    public ExtraConfiguration ExtraConfig { get; set; }
    public IEnumerable<StyleItem> Styles { get; set; } = new List<StyleItem>();
    public Configuration() {
      ExtraConfig = new();
    }
  }
}
