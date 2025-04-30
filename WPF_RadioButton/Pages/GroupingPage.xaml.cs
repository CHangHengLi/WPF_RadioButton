using System.Windows;
using System.Windows.Controls;

namespace RadioButtonDemo.Pages
{
    /// <summary>
    /// GroupingPage.xaml 的交互逻辑
    /// </summary>
    public partial class GroupingPage : Page
    {
        public GroupingPage()
        {
            InitializeComponent();
        }

        private void TestGroup_Checked(object sender, RoutedEventArgs e)
        {
            // 获取当前选中的RadioButton
            if (sender is RadioButton radioButton)
            {
                txtCurrentSelected.Text = radioButton.Content.ToString();
            }
        }
    }
} 