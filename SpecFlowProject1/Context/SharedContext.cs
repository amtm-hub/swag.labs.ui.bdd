using System.Configuration;

namespace SpecFlowProject1.Context
{
    public sealed class SharedContext
    {
        public string SusieUsername => ConfigurationManager.AppSettings["susieusername"];
        public string SusiePassword => ConfigurationManager.AppSettings["susiepassword"];
    }
}
