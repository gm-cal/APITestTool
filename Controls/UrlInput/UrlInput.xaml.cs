using System.Windows.Controls;

namespace Controls{
    public partial class UrlInput : UserControl{
        public UrlInput(){
            InitializeComponent();
        }
        public string Url{
            get => UrlTextBox.Text;
            set => UrlTextBox.Text = value;
        }

        public string Text{
            get => Url;
            set => Url = value;
        }
    }
}
