using System.Windows.Controls;

namespace Controls{
    public partial class MethodSelecter : UserControl{
        public MethodSelecter(){
            InitializeComponent();
            MethodComboBox.SelectedIndex = 0;
        }
        public string Method{
            get => ((ComboBoxItem)MethodComboBox.SelectedItem)?.Content?.ToString() ?? "GET";
        }

        public string Text => Method;
    }
}
