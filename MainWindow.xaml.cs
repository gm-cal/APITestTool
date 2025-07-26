using System.Windows;
using System.Windows.Controls;
using Controls;

public partial class MainWindow : Window{
    private int _tabCount = 1;

    public MainWindow(){
        InitializeComponent();
    }

    private void AddTabButton_Click(object sender, RoutedEventArgs e){
        _tabCount++;
        TabItem item = new TabItem{
            Header = $"Request{_tabCount}",
            Content = new ApiRequestTab()
        };
        MainTabControl.Items.Add(item);
        MainTabControl.SelectedItem = item;
    }
}
