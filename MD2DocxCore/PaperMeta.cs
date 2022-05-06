using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace MD2DocxCore {
  public class PaperMeta {
    [YamlMember(Alias = "name")]
    public string Name { get; set; }
    [YamlMember(Alias = "id")]
    public string Id { get; set; }
    [YamlMember(Alias = "teacher")]
    public string Teacher { get; set; }
    [YamlMember(Alias = "department")]
    public string Department { get; set; }
    [YamlMember(Alias = "main_title")]
    public string MainTitle { get; set; }
    [YamlMember(Alias = "chinese_title")]
    public string CNTitle { get; set; }
    [YamlMember(Alias = "english_title")]
    public string ENTitle { get; set; }
    [YamlMember(Alias = "report_name")]
    public string ReportName { get; set; }
    [YamlMember(Alias = "class")]
    public string Class { get; set; }
    [YamlMember(Alias = "english_abstract")]
    public string ENAbstract { get; set; }
    [YamlMember(Alias = "chinese_abstract")]
    public string CNAbstract { get; set; }
    [YamlMember(Alias = "english_key_words")]
    public string ENKeyWords { get; set; }
    [YamlMember(Alias = "chinese_key_words")]
    public string CNKeyWords { get; set; }
  }
}
