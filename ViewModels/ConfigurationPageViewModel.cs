using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using ReactiveUI;

namespace MD2DocxAvalon.ViewModels {
  class ConfigurationPageViewModel : ViewModelBase {
    int index = 0;
    public ConfigurationPageViewModel() {
      styles = new ObservableCollection<StyleListItemViewModel>();
      AddStyle = ReactiveCommand.Create(() => Styles.Add(new StyleListItemViewModel(index++)));
      DuplicateStyle = ReactiveCommand.Create<int>((id) => {
        System.Console.WriteLine(id);
        var style = Styles.First(s => s.ID == id).Clone();
        style.ID = index++;
        Styles.Add(style);
      });
      DeleteStyle = ReactiveCommand.Create<int>((id) => {
        Styles.Remove(Styles.First(s => s.ID == id));
      });
      // @TODO
      LoadConfig = ReactiveCommand.Create(() => { });
    }

    // public ConfigurationPageViewModel(IEnumerable<StyleListItemViewModel> items) {
    //   styles = new ObservableCollection<StyleListItemViewModel>(items);
    //   AddStyle = ReactiveCommand.Create(() => Styles.Add(new StyleListItemViewModel(index++)));
    //   // @TODO
    //   LoadConfig = ReactiveCommand.Create(() => { });
    // }

    ObservableCollection<StyleListItemViewModel> styles;

    public ObservableCollection<StyleListItemViewModel> Styles { 
      get => styles;
      set => this.RaiseAndSetIfChanged(ref styles, value);
    }

    public ReactiveCommand<Unit, Unit> AddStyle { get; }
    public ReactiveCommand<Unit, Unit> LoadConfig { get; }
    public ReactiveCommand<int, Unit> DuplicateStyle { get; }
    public ReactiveCommand<int, Unit> DeleteStyle { get; }
  }
}
