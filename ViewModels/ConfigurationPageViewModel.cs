using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using MD2DocxAvalon.Models;

namespace MD2DocxAvalon.ViewModels {
  class ConfigurationPageViewModel : ViewModelBase {
    public bool Cover { get; set; }
    public bool Abstract { get; set; }
    public bool TOC { get; set; }
    public bool Header { get; set; }
    public bool Footer { get; set; }
    public bool LatentStyle { get; set; }
    private ObservableCollection<Style> styles;
    private int index = 0;
    public ObservableCollection<Style> Styles { 
      get => styles;
      set => this.RaiseAndSetIfChanged(ref styles, value);
    }

    public ConfigurationPageViewModel() : this(new ConstructorParameters()) {
    }

    public ConfigurationPageViewModel(Configuration Config) {
      Cover = Config.Cover;
      Abstract = Config.Abstract;
      TOC = Config.TOC;
      Header = Config.Header;
      Footer = Config.Footer;
      LatentStyle = Config.LatentStyle;
      styles = new ObservableCollection<Style>(Config.Styles);
      AddStyle = ReactiveCommand.Create(() => Styles.Add(new Style(index++)));
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
      SaveConfig = ReactiveCommand.Create(() => { });
    }
    private ConfigurationPageViewModel(ConstructorParameters paras) : this(paras.Config) { }


    public ReactiveCommand<Unit, Unit> AddStyle { get; }
    public ReactiveCommand<Unit, Unit> LoadConfig { get; }
    public ReactiveCommand<Unit, Unit> SaveConfig { get; }
    public ReactiveCommand<int, Unit> DuplicateStyle { get; }
    public ReactiveCommand<int, Unit> DeleteStyle { get; }

    private class ConstructorParameters {
      public Configuration Config;

      public ConstructorParameters() {
        Config = new Configuration {
          Styles = new List<Style>()
        };
      }

      public ConstructorParameters(Configuration config) {
        Config = config;
      }
    }
  }
}
