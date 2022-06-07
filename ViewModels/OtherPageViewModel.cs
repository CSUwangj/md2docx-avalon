using Avalonia;
using MD2DocxAvalon.Services;
using ReactiveUI;
using System.Reactive;

namespace MD2DocxAvalon.ViewModels {
  public class OtherPageViewModel : ViewModelBase {
    public BibliographyGenerator BibliographyGenerator { get; set; } = new();
    public ReactiveCommand<Unit, Unit> Gen { get; }
    public ReactiveCommand<Unit, Unit> GenAndCopy { get; }

    public OtherPageViewModel() {
      Gen = ReactiveCommand.Create(() => {
        BibliographyGenerator.Generate();
      });
      GenAndCopy = ReactiveCommand.Create(() => {
        BibliographyGenerator.Generate();
        Application.Current?.Clipboard?.SetTextAsync(BibliographyGenerator.Result).Wait();
      });
    }
  }
}
