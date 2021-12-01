using System.Reactive;
using ReactiveUI;
using Avalonia.Controls;
using MD2DocxAvalon.Views;

namespace MD2DocxAvalon.ViewModels {
  public class IOViewModel : ViewModelBase {
    string input = "";
    string output = "";

    public IOViewModel() {
      SetInput = ReactiveCommand.Create(() => {
        OpenFileDialog dialog = new();
        dialog.Title = "Open Markdown";
        dialog.Filters.Add(new FileDialogFilter() { Name = "Markdown", Extensions = { "md", "MD" } });
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
    }

    public string Input {
      get => input;
      set => this.RaiseAndSetIfChanged(ref input, value);
    }

    public string Output {
      get => output;
      set => this.RaiseAndSetIfChanged(ref output, value);
    }

    public ReactiveCommand<Unit, Unit> SetInput { get; }
    public ReactiveCommand<Unit, Unit> SetOutput { get; }
  }
}
