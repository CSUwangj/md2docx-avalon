using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MD2DocxAvalon.Views {
  public partial class MainWindow : Window {
#pragma warning disable CA2211 // 非常量字段应当不可见
    public static MainWindow? Instance;
#pragma warning restore CA2211 // 非常量字段应当不可见
    public MainWindow() {
      Instance = this;
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
