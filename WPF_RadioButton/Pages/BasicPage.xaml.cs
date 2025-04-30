using System.Windows;
using System.Windows.Controls;

namespace RadioButtonDemo.Pages
{
    /// <summary>
    /// BasicPage.xaml 的交互逻辑
    /// </summary>
    public partial class BasicPage : Page
    {
        public BasicPage()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            eventResult.Text = "RadioButton已被选中!";
        }
    }
} 