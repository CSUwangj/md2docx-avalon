using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;

namespace MD2DocxAvalon.ViewModels {
  class ConfigurationPageViewModel : ViewModelBase {

    public ConfigurationPageViewModel() {
      Styles = new List<StyleListItemViewModel>();
      AddStyle = ReactiveCommand.Create(() => Styles.Add(new StyleListItemViewModel()));
      // @TODO
      LoadConfig = ReactiveCommand.Create(() => { });
    }

    public ConfigurationPageViewModel(IEnumerable<StyleListItemViewModel> items) {
      Styles = new List<StyleListItemViewModel>(items);
      AddStyle = ReactiveCommand.Create(() => Styles.Add(new StyleListItemViewModel()));
      // @TODO
      LoadConfig = ReactiveCommand.Create(() => { });
    }

    List<StyleListItemViewModel> styles;

    public List<StyleListItemViewModel> Styles { 
      get => styles;
      set => this.RaiseAndSetIfChanged(ref styles, value);
    }

    public ReactiveCommand<Unit, Unit> AddStyle { get; }
    public ReactiveCommand<Unit, Unit> LoadConfig { get; }
  }
}
