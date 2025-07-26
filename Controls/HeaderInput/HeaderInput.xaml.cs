using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Controls{
    public partial class HeaderInput : UserControl{
        public class HeaderEntry{
            public string Key{ get; set; } = string.Empty;
            public string Value{ get; set; } = string.Empty;
        }

        public ObservableCollection<HeaderEntry> Headers{ get; } = new ObservableCollection<HeaderEntry>();

        public HeaderInput(){
            InitializeComponent();
            HeaderGrid.ItemsSource = Headers;
            Headers.Add(new HeaderEntry());
        }

        public bool TryGetHeaders(out Dictionary<string, string> headers, out string error){
            headers = new Dictionary<string, string>();
            error = string.Empty;
            foreach(var h in Headers){
                if(string.IsNullOrWhiteSpace(h.Key)) continue;
                if(headers.ContainsKey(h.Key)){
                    error = $"Duplicate header: {h.Key}";
                    return false;
                }
                headers[h.Key] = h.Value ?? string.Empty;
            }
            return true;
        }
    }
}
