using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MD2DocxAvalon.ViewModels;

namespace MD2DocxAvalon.Pages {
  public partial class Configuration : UserControl {
    public Configuration() {
      InitializeComponent();
      DataContext = new ConfigurationPageViewModel();
    }

    private void InitializeComponent() {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
