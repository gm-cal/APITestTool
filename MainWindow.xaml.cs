using System.Windows;
using System.Windows.Controls;
using Controls;

public partial class MainWindow : Window{
    private int _tabCount = 1;

    public MainWindow(){
        InitializeComponent();
    }

    private void MenuAddTab_Click(object sender, RoutedEventArgs e){
        AddRequestTab();
    }

    private void MenuExit_Click(object sender, RoutedEventArgs e){
        Close();
    }

    private void MenuRunAll_Click(object sender, RoutedEventArgs e){
        MainTabControl.SelectedIndex = 0; // TestAll tab assumed first
    }

    private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e){
        if(MainTabControl.SelectedItem == AddTabItem){
            AddRequestTab();
        }
    }

    private void AddRequestTab(){
        _tabCount++;
        TabItem item = new TabItem();
        DockPanel header = new DockPanel();
        TextBlock text = new TextBlock{ Text = $"Request{_tabCount}", Margin = new Thickness(0,0,5,0) };
        Button close = new Button{ Content = "x", Padding = new Thickness(0), Width = 16, Height = 16 };
        close.Click += (s, e) => MainTabControl.Items.Remove(item);
        header.Children.Add(text);
        header.Children.Add(close);
        item.Header = header;
        item.Content = new ApiRequestTab();
        MainTabControl.Items.Insert(MainTabControl.Items.Count - 1, item);
        MainTabControl.SelectedItem = item;
    }
}
