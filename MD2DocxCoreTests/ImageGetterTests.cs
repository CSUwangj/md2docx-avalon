using MD2DocxCore;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace MD2DocxCoreTests {
  public class ImageGetterTests {
    private readonly ITestOutputHelper output;

    public ImageGetterTests(ITestOutputHelper output) {
      this.output = output;
    }

    [Theory]
    [InlineData("Fail.jpg")]
    public void DiskFileNotFound(string name) {
      ImageGetter imageGetter = new();
      output.WriteLine(Directory.GetCurrentDirectory());
      DirectoryInfo sourceDir = new("../../../TestFiles/");
      string expectedPath = Path.Combine(sourceDir.FullName, name);
      output.WriteLine(expectedPath);
      byte[] expected = File.ReadAllBytes(expectedPath);

      string pathNotExist = "/this/path/should/not/be/found/unless/!@#$%^&*()";
      bool result = ImageGetter.Load(pathNotExist, out byte[] actual, out _, out _);
      output.WriteLine(pathNotExist);

      Assert.False(result);
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Fail.jpg")]
    public void NetFileNotFound(string name) {
      ImageGetter imageGetter = new();
      DirectoryInfo sourceDir = new("../../../TestFiles/");
      string expectedPath = Path.Combine(sourceDir.FullName, name);
      byte[] expected = File.ReadAllBytes(expectedPath);

      string pathNotExist = "http://Idontcarewhatthiswebsiteis/but/it/should/not/exist!.jpg";
      bool result = ImageGetter.Load(pathNotExist, out byte[] actual, out _, out _);

      Assert.False(result);
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("yaml.jpg", "yaml.jpg")]
    public void FileInDisk(string name, string data) {
      ImageGetter imageGetter = new();
      DirectoryInfo sourceDir = new("../../../TestFiles/");
      string expectedPath = Path.Combine(sourceDir.FullName, name);
      byte[] expected = File.ReadAllBytes(expectedPath);

      string actualPath = Path.Combine(sourceDir.FullName, data);
      bool result = ImageGetter.Load(actualPath, out byte[] actual, out _, out _);

      Assert.True(result);
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("https://raw.githubusercontent.com/CSUwangj/md2docx-avalon/master/MD2DocxCoreTests/TestFiles/yaml.jpg", "yaml.jpg")]
    public void FileInNetwork(string url, string data) {
      ImageGetter imageGetter = new();
      DirectoryInfo sourceDir = new("../../../TestFiles/");
      string expectedPath = Path.Combine(sourceDir.FullName, data);
      byte[] expected = File.ReadAllBytes(expectedPath);

      bool result = ImageGetter.Load(url, out byte[] actual, out _, out _);

      Assert.True(result);
      Assert.Equal(expected, actual);
    }
  }
}
