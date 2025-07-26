using System.Windows.Controls;

namespace Controls.ResponseOutput{
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
