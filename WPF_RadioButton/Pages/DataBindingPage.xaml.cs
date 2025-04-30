using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using RadioButtonDemo.Models;

namespace RadioButtonDemo.Pages
{
    /// <summary>
    /// DataBindingPage.xaml 的交互逻辑
    /// </summary>
    public partial class DataBindingPage : Page, INotifyPropertyChanged
    {
        private Person _person;

        public Person Person
        {
            get => _person;
            set
            {
                _person = value;
                OnPropertyChanged(nameof(Person));
                OnPropertyChanged(nameof(SelectedGenderText));
            }
        }

        public string SelectedGenderText
        {
            get
            {
                if (Person != null)
                {
                    if (Person.IsMale)
                        return "男";
                    else if (Person.IsFemale)
                        return "女";
                }
                return "未选择";
            }
        }

        public DataBindingPage()
        {
            InitializeComponent();
            
            // 初始化数据
            Person = new Person { Name = "测试用户" };
            
            // 设置DataContext
            DataContext = this;
            
            // 监听Person属性变化
            Person.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Person.IsMale) || 
                    e.PropertyName == nameof(Person.IsFemale) || 
                    e.PropertyName == nameof(Person.Gender))
                {
                    OnPropertyChanged(nameof(SelectedGenderText));
                }
            };
        }

        private void ResetGender_Click(object sender, RoutedEventArgs e)
        {
            // 重置性别选择
            Person.IsMale = false;
            Person.IsFemale = false;
            Person.Gender = Gender.Male; // 默认值
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
} 