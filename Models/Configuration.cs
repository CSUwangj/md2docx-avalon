using MD2DocxAvalon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD2DocxAvalon.Models {
  class Configuration {
    public bool Cover { get; set; }
    public bool Abstract { get; set; }
    public bool TOC { get; set; }
    public bool Header { get; set; }
    public bool Footer { get; set; }
    public bool LatentStyle { get; set; }
    public IEnumerable<Style> Styles { get; set; } = new List<Style>();
  }
}
