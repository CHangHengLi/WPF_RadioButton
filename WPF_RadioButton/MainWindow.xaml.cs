using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RadioButtonDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // 页面类型字典，用于导航
    private Dictionary<string, Type> _pageTypes;

    public MainWindow()
    {
        InitializeComponent();
        
        // 初始化页面类型映射
        InitializePageTypes();
        
        // 默认导航到基本用法页面
        NavigateToPage("BasicPage");
    }

    private void InitializePageTypes()
    {
        _pageTypes = new Dictionary<string, Type>
        {
            { "BasicPage", typeof(Pages.BasicPage) },
            { "GroupingPage", typeof(Pages.GroupingPage) },
            { "DataBindingPage", typeof(Pages.DataBindingPage) },
            { "StylingPage", typeof(Pages.StylingPage) },
            { "TabsPage", typeof(Pages.TabsPage) },
            { "SurveyPage", typeof(Pages.SurveyPage) },
            { "MVVMPage", typeof(Pages.MVVMPage) }
        };
    }

    private void NavigateToPage(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string pageName)
        {
            NavigateToPage(pageName);
        }
    }
    
    private void NavigateToPage(string pageName)
    {
        if (_pageTypes.TryGetValue(pageName, out Type pageType))
        {
            // 创建页面实例并导航
            Page page = (Page)Activator.CreateInstance(pageType);
            MainContent.Navigate(page);
        }
    }
}