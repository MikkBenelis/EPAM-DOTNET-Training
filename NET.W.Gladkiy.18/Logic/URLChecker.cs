using System.Text;
using System.Text.RegularExpressions;

namespace Logic
{
    public class URLChecker
    {
        #region Fields

        // URL regex fields
        private string schemeRegex;
        private string hostRegex;
        private string pathRegex;
        private string parametersRegex;

        #endregion Fields

        #region Properties

        // URL scheme regex
        public string SchemeRegex
        {
            get => @"(https?)";
            set => schemeRegex = value;
        }

        // URL host regex
        public string HostRegex
        {
            get => @"([a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5})";
            set => hostRegex = value;
        }

        // URL path regex
        public string PathRegex
        {
            get => @"((([a-zA-Z0-9]+(\-[a-zA-Z0-9]+)*)(\/[a-zA-Z0-9]+(\-[a-zA-Z0-9]+)*)*)*)";
            set => pathRegex = value;
        }

        // URL parameters regex
        public string ParametersRegex
        {
            get => @"(([a-z0-9]+=[a-z0-9]+)*)";
            set => parametersRegex = value;
        }

        #endregion Properties

        #region PublicAPI

        public bool CheckURL(string url)
        {
            var sb = new StringBuilder();
            sb.Append(SchemeRegex + @":\/\/");
            sb.Append(HostRegex + @"\/");
            sb.Append(PathRegex + @"\?");
            sb.Append(ParametersRegex);

            var regex = new Regex(sb.ToString());
            return regex.IsMatch(url.ToLower());
        }

        #endregion PublicAPI
    }
}
