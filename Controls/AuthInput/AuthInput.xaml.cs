using System.Windows.Controls;

namespace Controls.AuthInput{
    public partial class AuthInput : UserControl{
        public AuthInput(){
            InitializeComponent();
            AuthComboBox.SelectedIndex = 0;
        }
        public string AuthType{
            get => ((ComboBoxItem)AuthComboBox.SelectedItem)?.Content?.ToString() ?? "None";
        }
        public string TokenPath{
            get => TokenPathTextBox.Text;
            set => TokenPathTextBox.Text = value;
        }
    }
}
