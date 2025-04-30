using System;
using System.Windows.Input;
using RadioButtonDemo.Models;

namespace RadioButtonDemo.ViewModels
{
    /// <summary>
    /// 设置视图模型，用于MVVM示例
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        private ThemeOption _selectedTheme;

        public ThemeOption SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (_selectedTheme != value)
                {
                    _selectedTheme = value;
                    OnPropertyChanged(nameof(SelectedTheme));
                    ApplyThemeChange(value);
                }
            }
        }

        public ICommand ThemeChangeCommand { get; }

        public SettingsViewModel()
        {
            // 默认选择浅色主题
            _selectedTheme = ThemeOption.Light;
            
            // 初始化命令
            ThemeChangeCommand = new RelayCommand(ChangeTheme);
        }

        private void ChangeTheme(object parameter)
        {
            if (parameter is ThemeOption theme)
            {
                SelectedTheme = theme;
            }
        }

        private void ApplyThemeChange(ThemeOption theme)
        {
            // 实际应用主题切换的逻辑
            var app = System.Windows.Application.Current;
            var resources = app.Resources;
            
            // 清除之前的主题资源
            resources.MergedDictionaries.Clear();
            
            // 根据选择的主题添加相应的资源字典
            switch (theme)
            {
                case ThemeOption.Light:
                    resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary
                    {
                        Source = new Uri("/RadioButtonDemo;component/Themes/LightTheme.xaml", UriKind.Relative)
                    });
                    break;
                    
                case ThemeOption.Dark:
                    resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary
                    {
                        Source = new Uri("/RadioButtonDemo;component/Themes/DarkTheme.xaml", UriKind.Relative)
                    });
                    break;
                    
                case ThemeOption.System:
                    // 根据系统设置选择主题
                    bool isDarkTheme = IsSystemInDarkMode();
                    resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary
                    {
                        Source = new Uri(isDarkTheme 
                            ? "/RadioButtonDemo;component/Themes/DarkTheme.xaml" 
                            : "/RadioButtonDemo;component/Themes/LightTheme.xaml", UriKind.Relative)
                    });
                    break;
            }
            
            Console.WriteLine($"主题已切换为: {theme}");
        }

        private bool IsSystemInDarkMode()
        {
            try
            {
                // 这只是一个简化的检测系统主题的方法
                // 在生产环境中，应该使用正确的API检测系统主题
                return Microsoft.Win32.Registry.GetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                    "AppsUseLightTheme", 1)?.ToString() == "0";
            }
            catch
            {
                // 如果无法获取系统主题，默认返回false（浅色主题）
                return false;
            }
        }
    }

    /// <summary>
    /// 简单的命令实现类
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
} 