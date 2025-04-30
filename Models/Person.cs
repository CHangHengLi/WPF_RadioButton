using System.ComponentModel;

namespace RadioButtonDemo.Models
{
    /// <summary>
    /// 人员信息类，用于数据绑定示例
    /// </summary>
    public class Person : INotifyPropertyChanged
    {
        private string _name;
        private Gender _gender;
        private bool _isMale;
        private bool _isFemale;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public Gender Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
                
                // 更新IsMale和IsFemale属性
                IsMale = value == Gender.Male;
                IsFemale = value == Gender.Female;
            }
        }

        public bool IsMale
        {
            get => _isMale;
            set
            {
                _isMale = value;
                OnPropertyChanged(nameof(IsMale));
                
                // 如果选中男性，则更新性别和女性属性
                if (value)
                {
                    _gender = Gender.Male;
                    _isFemale = false;
                    OnPropertyChanged(nameof(Gender));
                    OnPropertyChanged(nameof(IsFemale));
                }
            }
        }

        public bool IsFemale
        {
            get => _isFemale;
            set
            {
                _isFemale = value;
                OnPropertyChanged(nameof(IsFemale));
                
                // 如果选中女性，则更新性别和男性属性
                if (value)
                {
                    _gender = Gender.Female;
                    _isMale = false;
                    OnPropertyChanged(nameof(Gender));
                    OnPropertyChanged(nameof(IsMale));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 