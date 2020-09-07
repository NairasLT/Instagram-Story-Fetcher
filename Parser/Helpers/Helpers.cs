using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Helpers
{
    class Helpers
    {
        public static string WinFileNameRestrict(string Input)
        {
            return Input.Replace('*', ' ').Replace('<', ' ').Replace('>', ' ').Replace(':', ' ').Replace('\"', ' ').Replace('\\', ' ').Replace('/', ' ').Replace('|', ' ').Replace('?', ' ').Replace('\n',' ').Replace('\r', ' ');
        }
        public static string ForceHttp(string requestUrl)
        {
            var uri = new UriBuilder(requestUrl);
            var hadDefaultPort = uri.Uri.IsDefaultPort;
            uri.Scheme = Uri.UriSchemeHttp;
            uri.Port = hadDefaultPort ? -1 : uri.Port;
            return uri.ToString();
        }
    }
}
