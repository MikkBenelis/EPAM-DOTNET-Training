using System;
using System.IO;
using System.Xml.Linq;
using Logic;

namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*var urlChecker = new URLChecker
            {
                ShemeRegex = @"",
                HostRegex = @"",
                PathRegex = @"",
                ParametersRegex = @""
            };*/

            using (var fs = new FileStream("../../url_list.txt", FileMode.Open, FileAccess.Read))
            {
                XDocument document = URLParser.BuildXDocument(fs, Console.Out);
                document.Save("../../url_result.xml");
            }
        }
    }
}
