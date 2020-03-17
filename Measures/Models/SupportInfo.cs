namespace Measures.Models
{
    public class SupportInfo
    {
        // 第三方支持信息
        public SupportInfo(string icon, string url, string name)
        {
            this.Logo = icon;
            this.Url = url;
            this.Name = name;
        }
        public string Logo { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
