using System.Windows.Controls;
using System.Windows;

namespace Controls{
    public partial class APINameInput: UserControl{
        private TextBox ctrlNameTextBox => (TextBox)FindName("NameTextBox");
        private TextBlock ctrlNameLabel => (TextBlock)FindName("NameLabel");
        public event Action<string>? NameChanged;

        private bool _editingName;
        public APINameInput(){
            InitializeComponent();
        }
        
        public string APIName{
            get => ctrlNameTextBox.Text;
            set => ctrlNameTextBox.Text = value;
        }
        
        private void EditNameButton_Click(object sender, RoutedEventArgs e){
            ctrlNameTextBox.Visibility = ctrlNameTextBox.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            if(!_editingName){
                ctrlNameTextBox.Text = ctrlNameLabel.Text;
                ctrlNameLabel.Visibility = Visibility.Collapsed;
                ctrlNameTextBox.Visibility = Visibility.Visible;
                EditNameButton.Content = "Save";
                _editingName = true;
            }else{
                ctrlNameLabel.Text = ctrlNameTextBox.Text;
                ctrlNameLabel.Visibility = Visibility.Visible;
                ctrlNameTextBox.Visibility = Visibility.Collapsed;
                EditNameButton.Content = "Edit";
                NameChanged?.Invoke(ctrlNameLabel.Text);
                _editingName = false;
            }
        }

    }
}
