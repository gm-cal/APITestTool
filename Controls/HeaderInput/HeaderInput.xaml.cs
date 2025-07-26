using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Controls;
using Utils;

namespace Controls{
    public partial class HeaderInput : UserControl{
        public HeaderInput(){
            InitializeComponent();
        }
        public bool TryGetHeaders(out Dictionary<string, string> headers, out string error){
            headers = new Dictionary<string, string>();
            error = "";
            if(string.IsNullOrWhiteSpace(HeadersTextBox.Text)) return true;
            if(!JsonUtils.TryFormatJson(HeadersTextBox.Text, out string formatted, out error)) return false;
            try{
                headers = JsonSerializer.Deserialize<Dictionary<string, string>>(formatted) ?? new Dictionary<string, string>();
                HeadersTextBox.Text = formatted;
                return true;
            }catch(JsonException ex){
                error = ex.Message;
                return false;
            }
        }
    }
}
