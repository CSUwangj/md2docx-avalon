using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MD2DocxAvalon.Views {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
#if DEBUG
      this.AttachDevTools();
#endif
    }

    private void InitializeComponent() {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
