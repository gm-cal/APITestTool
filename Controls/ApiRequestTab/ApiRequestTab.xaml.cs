using System.Windows;
using System.Windows.Controls;
using System;
using Models;
using Services;

namespace Controls{
    public partial class ApiRequestTab : UserControl{
        private readonly ApiRequestService _service = new ApiRequestService();
        private bool _editingName;

        public event Action<string>? NameChanged;

        public ApiRequestTab(){
            InitializeComponent();
        }

        private void EditNameButton_Click(object sender, RoutedEventArgs e){
            if(!_editingName){
                NameTextBox.Text = NameLabel.Text;
                NameLabel.Visibility = Visibility.Collapsed;
                NameTextBox.Visibility = Visibility.Visible;
                EditNameButton.Content = "Save";
                _editingName = true;
            }else{
                NameLabel.Text = NameTextBox.Text;
                NameLabel.Visibility = Visibility.Visible;
                NameTextBox.Visibility = Visibility.Collapsed;
                EditNameButton.Content = "Edit";
                NameChanged?.Invoke(NameLabel.Text);
                _editingName = false;
            }
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e){
            if(!HeaderInputControl.TryGetHeaders(out var headers, out string hErr)){
                MessageBox.Show($"Header Error: {hErr}");
                return;
            }
            if(!BodyInputControl.TryGetBody(out var body, out string bErr)){
                MessageBox.Show($"Body Error: {bErr}");
                return;
            }

            ApiSetting setting = new ApiSetting{
                Url = UrlInputControl.Url,
                Method = MethodSelecterControl.Method,
                Headers = headers,
                Body = body,
                AuthType = AuthInputControl.AuthType,
                BearerTokenPath = AuthInputControl.TokenPath
            };

            if(Application.Current.MainWindow is MainWindow main)
                main.StatusText.Text = "Sending...";

            var (response, status) = await _service.SendRequestAsync(setting);

            if(Utils.JsonUtils.TryFormatJson(response, out string formatted, out _))
                ResponseOutputControl.Text = formatted;
            else
                ResponseOutputControl.Text = response;

            if(Application.Current.MainWindow is MainWindow main2)
                main2.StatusText.Text = $"Status: {status}";
        }
    }
}
