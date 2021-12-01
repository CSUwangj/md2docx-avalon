using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MD2DocxAvalon.ViewModels;

namespace MD2DocxAvalon.Pages {
  public partial class IO : UserControl {
    public IO() {
      InitializeComponent();

      DataContext = new IOViewModel();
    }

    private void InitializeComponent() {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
