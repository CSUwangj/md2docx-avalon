using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MD2DocxAvalon.Views {
  public partial class MainView : UserControl {
    public MainView() {
      InitializeComponent();
    }

    private void InitializeComponent() {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
