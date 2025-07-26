using System.Windows.Controls;
using Utils;

namespace Controls{
    public partial class BodyInput : UserControl{
        public BodyInput(){
            InitializeComponent();
        }
        public bool TryGetBody(out string body, out string error){
            body = string.Empty;
            error = string.Empty;
            if(string.IsNullOrWhiteSpace(BodyTextBox.Text)) return true;
            if(!JsonUtils.TryFormatJson(BodyTextBox.Text, out string formatted, out error)) return false;
            body = formatted;
            BodyTextBox.Text = formatted;
            return true;
        }
    }
}
