using System.Windows.Controls;

namespace RadioButtonDemo.Pages
{
    /// <summary>
    /// MVVMPage.xaml 的交互逻辑
    /// </summary>
    public partial class MVVMPage : Page
    {
        public MVVMPage()
        {
            InitializeComponent();
            
            // 在MVVM模式中，大部分逻辑都在ViewModel中实现
            // 视图代码非常简洁，主要负责初始化和设置DataContext
        }
    }
} 