using System;
using System.Text;

namespace Core.Utility.Common
{
    public class URLDetails
    {
        //public static string GetScheme()
        //{
        //    if (HttpContext.Current.Request.IsSecureConnection)
        //        return "https://";
        //    else
        //        return "http://";
        //}

        public static string GetSiteRootUrl()
        {
            try
            {
                string protocol;

                try
                {
                    //if (HttpContext.Current.Request.IsSecureConnection)
                    //    protocol = "https";
                    //else
                    protocol = "http";
                }
                catch (Exception ex)
                {
                    protocol = "https";
                }


                StringBuilder uri = new StringBuilder(protocol + "://");

                //try
                //{
                //    string hostname = HttpContext.Current.Request.Url.Host;

                //    uri.Append(hostname);

                //    int port = HttpContext.Current.Request.Url.Port;

                //    if (port != 80 && port != 443)
                //    {
                //        uri.Append(":");
                //        uri.Append(port.ToString());
                //    }
                //}
                //catch (Exception ex)
                //{
                //}

                return (uri + "/").ToString();
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}
