using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Models;
using Services;

namespace Controls{
    public partial class TestAllTab : UserControl{
        private readonly ApiRequestService _service = new ApiRequestService();
        public TestAllTab(){
            InitializeComponent();
            LoadFolders();
        }

        private void LoadFolders(){
            Directory.CreateDirectory("api");
            FolderList.ItemsSource = Directory.GetDirectories("api").Select(Path.GetFileName);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e){
            LoadFolders();
        }
        private void FolderList_SelectionChanged(object sender, SelectionChangedEventArgs e){
            FileList.ItemsSource = null;
            if(FolderList.SelectedItem == null) return;
            string folder = Path.Combine("api", FolderList.SelectedItem.ToString()!);
            var files = Directory.GetFiles(folder, "*.json").Select(Path.GetFileName);
            FileList.ItemsSource = files;
        }

        private async void TestAllButton_Click(object sender, RoutedEventArgs e){
            if(FolderList.SelectedItem == null) return;
            string folder = Path.Combine("api", FolderList.SelectedItem.ToString()!);
            var files = Directory.GetFiles(folder, "*.json");
            int total = files.Length;
            int success = 0, fail = 0;

            if(Application.Current.MainWindow is MainWindow main)
                main.StatusText.Text = "Running...";

            foreach(var file in files){
                try{
                    string json = File.ReadAllText(file);
                    ApiSetting? setting = System.Text.Json.JsonSerializer.Deserialize<ApiSetting>(json);
                    if(setting == null){
                        fail++;
                        continue;
                    }
                    var (_, status) = await _service.SendRequestAsync(setting);
                    if(status >= 200 && status < 300) success++; else fail++;
                }catch(Exception){
                    fail++;
                }
            }

            if(Application.Current.MainWindow is MainWindow main2)
                main2.StatusText.Text = "Ready";

            ResultText.Text = $"Total:{total} Success:{success} Fail:{fail}";
        }
    }
}
