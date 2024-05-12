using System;
using System.Globalization;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;

/// <summary>
/// Summary description for ErrorHandler
/// </summary>
/// 

namespace Core.Utility.Common
{
    public class ErrorHandler
    {
        public ErrorHandler()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static void WriteError(string errorMessage, string ErrorPath)
        {
            try
            {
                string path = ErrorPath + "\\" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                using (StreamWriter w = File.AppendText(path))
                {
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    string errfile = "Error in: ";// + System.Web.HttpContext.Current.Request.Url.ToString();
                    w.WriteLine(errfile);
                    string err_message = "Error Message: " + errorMessage;
                    w.WriteLine(err_message);
                    w.WriteLine("-----------------------------------------------------------");
                    w.Flush();
                    w.Close();

                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ErrorPath);
            }

        }

        public static void WriteProcessError(string errorCode, string ErrorPath, string pubFolderName, string pdfPostion)
        {
            try
            {
                string errorMessage = "";
                string xmlFilePath = ErrorPath + "Error\\ErrorCodes.xml";
                //string path = pubFolderName + "\\" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                string path = pubFolderName + "\\FailLog.txt";
                XmlDocument errorDoc = new XmlDocument();
                errorDoc.Load(xmlFilePath);

                foreach (XmlNode xn in errorDoc.SelectNodes("//ErrorCode[@id='" + errorCode + "']"))
                {
                    foreach (XmlAttribute xImgAtt in xn.Attributes)
                    {
                        if (xImgAtt.Name == "ErrorMessage")
                        {
                            errorMessage = xImgAtt.Value;
                        }
                    }
                }
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                using (StreamWriter w = File.AppendText(path))
                {
                    //w.WriteLine("\r\nLog Entry : ");
                    //w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    //string errfile = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString();
                    //w.WriteLine(errfile);
                    w.WriteLine("------------------------------------------------------------------------------------------------");
                    string err_message = "Error Message: " + errorMessage + " for PDF File Number " + pdfPostion + " in Excel File.";
                    w.WriteLine(err_message);
                    // w.WriteLine("-----------------------------------------------------------");
                    w.Flush();
                    w.Close();

                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ErrorPath);
            }

        }

        public static void WriteConversionLog(string bookID, string ErrorPath, string pubFolderName, string pdfPostion, string bookURL)
        {
            try
            {
                // string errorMessage = "";
                string path = pubFolderName + "\\conversionLog.txt";
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                using (StreamWriter w = File.AppendText(path))
                {
                    string bookLink = bookURL + "/vBook.aspx?id=" + bookID;
                    string err_message = "Pdf File Conversion Successful for " + pdfPostion + ".";
                    // string linkMessage = "Here is the link For the book";
                    w.WriteLine("\r\n");
                    w.WriteLine(err_message);
                    //w.WriteLine(linkMessage);
                    //w.WriteLine("-----------------------------------------------------------");
                    w.WriteLine(bookLink);
                    // w.WriteLine("-----------------------------------------------------------");
                    w.Flush();
                    w.Close();

                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ErrorPath);
            }

        }


    }
}