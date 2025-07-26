using System.Windows.Controls;

namespace Controls{
    public partial class ResponseOutput : UserControl{
        public ResponseOutput(){
            InitializeComponent();
        }
        public string Text{
            get => ResponseTextBox.Text;
            set => ResponseTextBox.Text = value;
        }
    }
}
