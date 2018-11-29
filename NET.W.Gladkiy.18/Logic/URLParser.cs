using System;
using System.IO;
using System.Xml.Linq;

namespace Logic
{
    public static class URLParser
    {
        #region PublicAPI

        /// <summary>Public interface to build XDocument of URLs</summary>
        /// <param name="inputStream">Stream to read URL lines</param>
        /// <param name="urlChecker">Checker of read URL lines</param>
        /// <param name="logger">Wrong URL logger, may be null</param>
        /// <returns>XML document with URL's info</returns>
        public static XDocument BuildXDocument(Stream inputStream, URLChecker urlChecker, TextWriter logger)
        {
            // Check arguments for null
            if (inputStream != null && urlChecker != null)
            {
                // Check stream for readability
                if (inputStream.CanRead)
                {
                    return BuildXDocumentRoutine(inputStream, urlChecker, logger);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>Public interface to build XDocument of URLs with default URLChecker and without logging</summary>
        /// <param name="inputStream">Stream to read URL lines</param>
        /// <returns>XML document with URL's info</returns>
        public static XDocument BuildXDocument(Stream inputStream)
        {
            return BuildXDocument(inputStream, new URLChecker(), null);
        }

        /// <summary>Public interface to build XDocument of URLs without logging</summary>
        /// <param name="inputStream">Stream to read URL lines</param>
        /// <param name="urlChecker">Checker of read URL lines</param>
        /// <returns>XML document with URL's info</returns>
        public static XDocument BuildXDocument(Stream inputStream, URLChecker urlChecker)
        {
            return BuildXDocument(inputStream, urlChecker, null);
        }

        /// <summary>Public interface to build XDocument of URLs with default URLChecker</summary>
        /// <param name="inputStream">Stream to read URL lines</param>
        /// <param name="logger">Wrong URL logger, may be null</param>
        /// <returns>XML document with URL's info</returns>
        public static XDocument BuildXDocument(Stream inputStream, TextWriter logger)
        {
            return BuildXDocument(inputStream, new URLChecker(), logger);
        }

        #endregion PublicAPI

        #region PrivateAPI

        /// <summary>Private routine to build XDocument of URLs</summary>
        /// <param name="inputStream">Stream to read URL lines</param>
        /// <param name="urlChecker">Checker of read URL lines</param>
        /// <param name="logger">Wrong URL logger, may be null</param>
        /// <returns>XML document with URL's info</returns>
        private static XDocument BuildXDocumentRoutine(Stream inputStream, URLChecker urlChecker, TextWriter logger)
        {
            // Create XML document basement
            var declaration = new XDeclaration("1.0", "UTF-8", "yes");
            var document = new XDocument(declaration, new XElement("urlAddresses"));

            // Read urls
            string url;
            var streamReader = new StreamReader(inputStream);
            while ((url = streamReader.ReadLine()) != null)
            {
                // Check url and print log
                if (urlChecker.CheckURL(url))
                {
                    var urlElement = BuildURLElement(url);
                    document.Root.Add(urlElement);

                    if (logger != null)
                    {
                        logger.WriteLine("[VALID]: " + url);
                    }
                }
                else
                {
                    if (logger != null)
                    {
                        logger.WriteLine("[INVALID]: " + url);
                    }
                }
            }

            return document;
        }

        /// <summary>Create XML element of given URL</summary>
        /// <param name="url">URL to build XML element</param>
        /// <returns>XML element of given URL</returns>
        private static XElement BuildURLElement(string url)
        {
            var urlElement = new XElement("urlAddress");
            urlElement.Add(BuildSchemeElement(url));
            urlElement.Add(BuildHostElement(url));
            urlElement.Add(BuildURIElement(url));
            urlElement.Add(BuildParametersElement(url));
            return urlElement;
        }

        /// <summary>Create XML scheme element of given URL</summary>
        /// <param name="url">URL to build XML scheme element</param>
        /// <returns>URL's scheme XML element</returns>
        private static XElement BuildSchemeElement(string url)
        {
            string schemeSeparator = "://";
            string scheme = url.Substring(0, url.IndexOf(schemeSeparator));

            var schemeElement = new XElement("scheme");
            var schemeTypeAttribute = new XAttribute("type", scheme);
            schemeElement.Add(schemeTypeAttribute);
            return schemeElement;
        }
        
        /// <summary>Create XML host element of given URL</summary>
        /// <param name="url">URL to build XML host element</param>
        /// <returns>URL's host XML element</returns>
        private static XElement BuildHostElement(string url)
        {
            string schemeSeparator = "://";
            int schemeSeparatorEndPos = url.IndexOf(schemeSeparator) + schemeSeparator.Length;
            int hostEndPos = url.IndexOf("/", schemeSeparatorEndPos);
            string host = url.Substring(schemeSeparatorEndPos, hostEndPos - schemeSeparatorEndPos);

            var hostElement = new XElement("host");
            var hostNameAttribute = new XAttribute("name", host);
            hostElement.Add(hostNameAttribute);
            return hostElement;
        }

        /// <summary>Create XML URI element of given URL</summary>
        /// <param name="url">URL to build XML URI element</param>
        /// <returns>URL's URI XML element</returns>
        private static XElement BuildURIElement(string url)
        {
            string schemeSeparator = "://";
            int schemeSeparatorEndPos = url.IndexOf(schemeSeparator) + schemeSeparator.Length;
            int hostEndPos = url.IndexOf("/", schemeSeparatorEndPos);
            int uriEndPos = url.IndexOf("?") - hostEndPos;
            string uri = url.Substring(hostEndPos + 1, uriEndPos - 1);
            string[] uriList = uri.Split('/');

            var uriElement = new XElement("uri");
            foreach (var i in uriList)
            {
                var segmentElement = new XElement("segment");
                segmentElement.Add(i);
                uriElement.Add(segmentElement);
            }

            return uriElement;
        }

        /// <summary>Create XML parameters element of given URL</summary>
        /// <param name="url">URL to build XML parameters element</param>
        /// <returns>URL's parameters XML element</returns>
        private static XElement BuildParametersElement(string url)
        {
            string parameters = url.Substring(url.IndexOf("?") + 1);
            string[] parametersList = parameters.Split('&');

            var parametersElement = new XElement("parameters");
            foreach (var parameter in parametersList)
            {
                string[] paramInfo = parameter.Split('=');
                var parameterElement = new XElement("parameter");
                var parameterKeyAttribute = new XAttribute("key", paramInfo[0]);
                var parameterValueAttribute = new XAttribute("value", paramInfo[1]);
                parameterElement.Add(parameterKeyAttribute);
                parameterElement.Add(parameterValueAttribute);
                parametersElement.Add(parameterElement);
            }

            return parametersElement;
        }

        #endregion PrivateAPI
    }
}