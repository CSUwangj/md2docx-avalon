using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;

namespace MD2DocxAvalon.ViewModels {
  class ConfigurationPageViewModel : ViewModelBase {

    public ConfigurationPageViewModel() {
      styles = new ObservableCollection<StyleListItemViewModel>();
      AddStyle = ReactiveCommand.Create(() => Styles.Add(new StyleListItemViewModel()));
      // @TODO
      LoadConfig = ReactiveCommand.Create(() => { });
    }

    public ConfigurationPageViewModel(IEnumerable<StyleListItemViewModel> items) {
      styles = new ObservableCollection<StyleListItemViewModel>(items);
      AddStyle = ReactiveCommand.Create(() => Styles.Add(new StyleListItemViewModel()));
      // @TODO
      LoadConfig = ReactiveCommand.Create(() => { });
    }

    ObservableCollection<StyleListItemViewModel> styles;

    public ObservableCollection<StyleListItemViewModel> Styles { 
      get => styles;
      set => this.RaiseAndSetIfChanged(ref styles, value);
    }

    public ReactiveCommand<Unit, Unit> AddStyle { get; }
    public ReactiveCommand<Unit, Unit> LoadConfig { get; }
  }
}
