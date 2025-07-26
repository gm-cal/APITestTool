using System.Windows.Controls;

namespace Controls.UrlInput{
    public partial class UrlInput : UserControl{
        public UrlInput(){
            InitializeComponent();
        }
        public string Url{
            get => UrlTextBox.Text;
            set => UrlTextBox.Text = value;
        }
    }
}
