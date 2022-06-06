using Avalonia;
using MD2DocxAvalon.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MD2DocxAvalon.ViewModels {
  public class OtherPageViewModel : ViewModelBase {
    public BibliographyGenerator bibliographyGenerator { get; set; } = new();
    public ReactiveCommand<Unit, Unit> Gen { get; }
    public ReactiveCommand<Unit, Unit> GenAndCopy { get; }

    public OtherPageViewModel() {
      Gen = ReactiveCommand.Create(() => {
        bibliographyGenerator.Generate();
      });
      GenAndCopy = ReactiveCommand.Create(() => {
        bibliographyGenerator.Generate();
        Application.Current?.Clipboard?.SetTextAsync(bibliographyGenerator.Result).Wait();
      });
    }
  }
}
