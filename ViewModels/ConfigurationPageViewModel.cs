using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using MD2DocxAvalon.Models;
using Avalonia.Controls;
using MD2DocxAvalon.Views;
using System;
using Newtonsoft.Json;
using System.IO;
using MD2DocxCore;

namespace MD2DocxAvalon.ViewModels {
  public class ConfigurationPageViewModel : ViewModelBase {
    private static readonly ConfigurationPageViewModel instance = new();
    public static ConfigurationPageViewModel Instance { get => instance; }
    public static readonly List<string> justifications = new() {
      "左对齐",
      "居中",
      "右对齐",
      "两端对齐",
      "分散对齐"
    };
    public static List<string> Justifications { get => justifications; }

    private int index = 0;
    ExtraConfiguration extraConfig;
    public ExtraConfiguration ExtraConfig { get => extraConfig; set => this.RaiseAndSetIfChanged(ref extraConfig, value); }
    private ObservableCollection<StyleItem> styles;
    public ObservableCollection<StyleItem> Styles {
      get => styles;
      set => this.RaiseAndSetIfChanged(ref styles, value);
    }

    public ConfigurationPageViewModel() : this(new ConstructorParameters()) {
    }

    public ConfigurationPageViewModel(Configuration Config) {
      extraConfig = Config.ExtraConfig;
      styles = new ObservableCollection<StyleItem>(Config.Styles);
      foreach (var (style, index) in Styles.Select((style, i) => (style, i))) {
        style.ID = index;
        this.index = index + 1;
      }

      AddStyle = ReactiveCommand.Create(() => Styles.Add(new StyleItem(index++)));
      DuplicateStyle = ReactiveCommand.Create<int>((id) => {
        var style = Styles.First(s => s.ID == id).Clone();
        style.ID = index++;
        Styles.Add(style);
      });
      DeleteStyle = ReactiveCommand.Create<int>((id) => {
        Styles.Remove(Styles.First(s => s.ID == id));
      });

      LoadConfig = ReactiveCommand.Create(() => {
        OpenFileDialog dialog = new();
        dialog.Title = "Open Configuration json file";
        dialog.Filters.Add(new FileDialogFilter() { Name = "JSON File", Extensions = { "json" } });
        dialog.AllowMultiple = false;
        if (MainWindow.Instance == null) return;
        string path = "";
        dialog.ShowAsync(MainWindow.Instance).ContinueWith((result) => {
          if (result?.Result?[0] == null) {
            throw new Exception("No such file or directory");
          }
          path = result.Result[0];
        }).Wait();
        if (path == "") return;
        string json = File.ReadAllText(path);
        var Config = JsonConvert.DeserializeObject<Configuration>(json);
        if (Config == null) {
          throw new Exception("Wrong json file");
        }
        ExtraConfig = Config.ExtraConfig;
        Styles = new ObservableCollection<StyleItem>(Config.Styles);
        foreach (var (style, index) in Styles.Select((style, i) => (style, i))) {
          style.ID = index;
          this.index = index + 1;
        }
      });
      SaveConfig = ReactiveCommand.Create(() => {
        SaveFileDialog dialog = new();
        dialog.Title = "Save Configuration As...";
        dialog.Filters.Add(new FileDialogFilter() { Name = "JSON File", Extensions = { "json" } });
        dialog.DefaultExtension = "json";
        if (MainWindow.Instance == null) return;
        dialog.ShowAsync(MainWindow.Instance).ContinueWith((result) => {
          if (result.Result == null) {
            throw new Exception("Save Error");
          }
          string json = JsonConvert.SerializeObject(ToModel());
          File.WriteAllText(result.Result, json);
        });
      });
    }
    private ConfigurationPageViewModel(ConstructorParameters paras) : this(paras.Config) { }

    public Configuration ToModel() {
      return new Configuration {
        ExtraConfig = ExtraConfig,
        Styles = Styles
      };
    }


    public ReactiveCommand<Unit, Unit> AddStyle { get; }
    public ReactiveCommand<Unit, Unit> LoadConfig { get; }
    public ReactiveCommand<Unit, Unit> SaveConfig { get; }
    public ReactiveCommand<int, Unit> DuplicateStyle { get; }
    public ReactiveCommand<int, Unit> DeleteStyle { get; }

    private class ConstructorParameters {
      public Configuration Config;

      public ConstructorParameters() {
        Config = new Configuration {
          Styles = new List<StyleItem>()
        };
      }

      public ConstructorParameters(Configuration config) {
        Config = config;
      }
    }
  }
}
