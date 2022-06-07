using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MD2DocxAvalon.ViewModels;

namespace MD2DocxAvalon.Pages {
  public partial class Other : UserControl {
    public Other() {
      InitializeComponent();
      DataContext = new OtherPageViewModel();
    }

    private void InitializeComponent() {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
