using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MD2DocxAvalon.Pages {
  public partial class Configuration : UserControl {
    public Configuration() {
      InitializeComponent();
    }

    private void InitializeComponent() {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
