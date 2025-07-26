using System.Windows;
using System.Windows.Controls;
using Models;
using Services;

namespace Controls{
    public partial class ApiRequestTab : UserControl{
        private readonly ApiRequestService _service = new ApiRequestService();
        public ApiRequestTab(){
            InitializeComponent();
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

            var (response, status) = await _service.SendRequestAsync(setting);
            if(Utils.JsonUtils.TryFormatJson(response, out string formatted, out _))
                ResponseOutputControl.Text = formatted;
            else
                ResponseOutputControl.Text = response;
        }
    }
}
