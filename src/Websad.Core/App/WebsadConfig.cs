namespace Websad.Core.App
{
    public class WebsadConfig
    {
        public AppDbType DbType { get; set; }
        public WebsiteMeta WebsiteMeta { get; set; }
        public AppConnectionString ConnectionStrings { get; set; }
        public AppWebConfig WebConfig { get; set; }
    }
}
