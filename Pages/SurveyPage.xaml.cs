using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace RadioButtonDemo.Pages
{
    /// <summary>
    /// SurveyPage.xaml 的交互逻辑
    /// </summary>
    public partial class SurveyPage : Page
    {
        public SurveyPage()
        {
            InitializeComponent();
        }

        private void Survey_ValueChanged(object sender, RoutedEventArgs e)
        {
            // 显示/隐藏其他语言文本框
            if (rbLangOther != null && txtOtherLanguage != null)
            {
                txtOtherLanguage.Visibility = rbLangOther.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
                
                // 控制占位符文本的可见性
                if (txtPlaceholder != null)
                {
                    // 只有当文本框可见且内容为空时，才显示占位符
                    txtPlaceholder.Visibility = (rbLangOther.IsChecked == true && string.IsNullOrEmpty(txtOtherLanguage.Text)) 
                        ? Visibility.Visible 
                        : Visibility.Collapsed;
                }
            }
            
            // 验证所有问题是否已回答
            ValidateSurvey();
        }
        
        private void ValidateSurvey()
        {
            bool ageSelected = rbAge1.IsChecked == true || rbAge2.IsChecked == true || 
                               rbAge3.IsChecked == true || rbAge4.IsChecked == true || 
                               rbAge5.IsChecked == true;
                               
            bool languageSelected = rbLang1.IsChecked == true || rbLang2.IsChecked == true || 
                                    rbLang3.IsChecked == true || rbLang4.IsChecked == true || 
                                    rbLang5.IsChecked == true || rbLangOther.IsChecked == true;
                                    
            bool frequencySelected = rbFreq1.IsChecked == true || rbFreq2.IsChecked == true || 
                                     rbFreq3.IsChecked == true || rbFreq4.IsChecked == true || 
                                     rbFreq5.IsChecked == true;
            
            // 如果选择"其他"，则验证文本框是否已填写
            bool otherLanguageValid = rbLangOther.IsChecked != true || 
                                     (rbLangOther.IsChecked == true && !string.IsNullOrWhiteSpace(txtOtherLanguage.Text));
            
            // 所有问题已回答且符合要求时，启用提交按钮
            btnSubmit.IsEnabled = ageSelected && languageSelected && frequencySelected && otherLanguageValid;
        }

        private void SubmitSurvey_Click(object sender, RoutedEventArgs e)
        {
            // 隐藏表单，显示结果
            surveyForm.Visibility = Visibility.Collapsed;
            resultPanel.Visibility = Visibility.Visible;
            
            // 收集结果
            StringBuilder result = new StringBuilder();
            
            // 年龄
            result.AppendLine("1. 您的年龄范围:");
            if (rbAge1.IsChecked == true) result.AppendLine("   18岁以下");
            else if (rbAge2.IsChecked == true) result.AppendLine("   18-25岁");
            else if (rbAge3.IsChecked == true) result.AppendLine("   26-35岁");
            else if (rbAge4.IsChecked == true) result.AppendLine("   36-50岁");
            else if (rbAge5.IsChecked == true) result.AppendLine("   50岁以上");
            
            // 编程语言
            result.AppendLine("\n2. 您最喜欢哪种编程语言:");
            if (rbLang1.IsChecked == true) result.AppendLine("   C#");
            else if (rbLang2.IsChecked == true) result.AppendLine("   Java");
            else if (rbLang3.IsChecked == true) result.AppendLine("   Python");
            else if (rbLang4.IsChecked == true) result.AppendLine("   C++");
            else if (rbLang5.IsChecked == true) result.AppendLine("   JavaScript");
            else if (rbLangOther.IsChecked == true) result.AppendLine($"   其他: {txtOtherLanguage.Text}");
            
            // 使用频率
            result.AppendLine("\n3. 您使用WPF的频率:");
            if (rbFreq1.IsChecked == true) result.AppendLine("   每天都用");
            else if (rbFreq2.IsChecked == true) result.AppendLine("   每周几次");
            else if (rbFreq3.IsChecked == true) result.AppendLine("   每月几次");
            else if (rbFreq4.IsChecked == true) result.AppendLine("   很少使用");
            else if (rbFreq5.IsChecked == true) result.AppendLine("   从未使用过");
            
            // 显示结果
            txtResult.Text = result.ToString();
        }

        private void OtherLanguage_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 控制占位符文本的可见性
            if (txtPlaceholder != null && txtOtherLanguage != null)
            {
                txtPlaceholder.Visibility = string.IsNullOrEmpty(txtOtherLanguage.Text) 
                    ? Visibility.Visible 
                    : Visibility.Collapsed;
            }
            
            // 同时触发表单验证
            ValidateSurvey();
        }
    }
} 