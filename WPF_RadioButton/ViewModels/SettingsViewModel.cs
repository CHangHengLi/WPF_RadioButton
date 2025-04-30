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
            // 在实际应用中，这里会包含主题切换的逻辑
            Console.WriteLine($"主题已切换为: {theme}");
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