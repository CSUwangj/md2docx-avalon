using System.Reactive;
using ReactiveUI;
using Avalonia.Controls;
using MD2DocxAvalon.Views;
using MD2DocxCore;
using System.Collections.Generic;
using System;
using MessageBox.Avalonia;

namespace MD2DocxAvalon.ViewModels {
  public class IOViewModel : ViewModelBase {
    private static readonly IOViewModel instance = new();
    public static IOViewModel Instance { get => instance; }
    private string input = "";
    private string output = "";
    public string Input {
      get => input;
      set => this.RaiseAndSetIfChanged(ref input, value);
    }

    public string Output {
      get => output;
      set => this.RaiseAndSetIfChanged(ref output, value);
    }


    public IOViewModel() {
      SetInput = ReactiveCommand.Create(() => {
        OpenFileDialog dialog = new();
        dialog.Title = "Open Markdown";
        dialog.Filters.Add(new FileDialogFilter() { Name = "Markdown", Extensions = { "md", "MD" } });
        dialog.AllowMultiple = false;
        if (MainWindow.Instance == null) return;
        dialog.ShowAsync(MainWindow.Instance).ContinueWith((result) => {
          if (result?.Result?[0] != null) {
            Input = result.Result[0];
          }
        });
      });
      SetOutput = ReactiveCommand.Create(() => {
        SaveFileDialog dialog = new();
        dialog.Title = "Save Document As...";
        dialog.Filters.Add(new FileDialogFilter() { Name = "Word Document", Extensions = { "docx" } });
        dialog.DefaultExtension = "docx";
        if (MainWindow.Instance == null) return;
        dialog.ShowAsync(MainWindow.Instance).ContinueWith((result) => {
          if (result.Result != null) {
            Output = result.Result;
          }
        });
      });
      Run = ReactiveCommand.Create(() => {
        var styles = new List<Style>();
        foreach (var style in ConfigurationPageViewModel.Instance.Styles) {
          styles.Add(style.Style);
        }
        try {
          MD2Docx.Run(Input, Output, ConfigurationPageViewModel.Instance.ExtraConfig, styles, out List<string> faileElement);
          var info = faileElement.Count == 0 ? "Check your file, sir!" : "There are something failed to get/convert in your document.\n" + String.Join('\n', faileElement);
          var messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Success", info);
          messageBoxStandardWindow.Show();
        } catch (Exception e) {
          var messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Error", $"{e.ToString()}\nFire a issue at https://github.com/CSUwangj/md2docx-avalon/issues.");
          messageBoxStandardWindow.Show();
        }
      });
    }

    public ReactiveCommand<Unit, Unit> SetInput { get; }
    public ReactiveCommand<Unit, Unit> SetOutput { get; }
    public ReactiveCommand<Unit, Unit> Run { get; }
  }
}
