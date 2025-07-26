using System.Collections.Generic;

namespace Models{
    public class ApiSetting{
        public string Name      { get; set; } = string.Empty;
        public string Url       { get; set; } = string.Empty;
        public string Method    { get; set; } = string.Empty; // GET, POST, PUT, DELETE
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public string Body      { get; set; } = string.Empty;
        public string AuthType  { get; set; } = string.Empty; // None, Bearer
        public string BearerTokenPath { get; set; } = string.Empty;
        public int TimeoutSeconds { get; set; } = 30;
    }
}
