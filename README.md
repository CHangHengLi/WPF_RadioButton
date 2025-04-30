# WPF RadioButton 控件演示程序

## 项目简介

本项目是一个WPF RadioButton控件的综合演示程序，展示了RadioButton控件的各种功能和使用场景。该项目采用最新的.NET 8.0开发，包含了从基础用法到MVVM架构的多个示例。
![image](https://github.com/user-attachments/assets/94c0e6e2-5af2-4627-8142-e813f58e38f8)

## 功能特点

* **基本用法** - 展示RadioButton的基本属性和事件
* **分组管理** - 演示如何通过GroupName属性对RadioButton进行分组
* **数据绑定** - 展示RadioButton与数据模型的绑定方式
* **样式与模板** - 自定义RadioButton的外观和行为
* **选项卡示例** - 使用RadioButton实现选项卡界面
* **问卷调查示例** - 在表单中应用RadioButton
* **MVVM模式示例** - 在MVVM架构中使用RadioButton，包含主题切换功能

## 系统要求

* Windows操作系统
* .NET 8.0或更高版本
* Visual Studio 2022或其他支持.NET 8.0的IDE

## 快速开始

1. 克隆或下载本项目
2. 使用Visual Studio 2022打开`RadioButtonDemo.sln`解决方案文件
3. 构建并运行项目

```bash
dotnet build
dotnet run
```

## 项目结构

```
WPF_RadioButton/
├── Pages/                 # 各种演示页面
│   ├── BasicPage.xaml     # 基本用法示例
│   ├── GroupingPage.xaml  # 分组管理示例
│   ├── DataBindingPage.xaml # 数据绑定示例
│   ├── StylingPage.xaml   # 样式与模板示例
│   ├── TabsPage.xaml      # 选项卡示例
│   ├── SurveyPage.xaml    # 问卷调查示例
│   └── MVVMPage.xaml      # MVVM模式示例
├── Models/                # 数据模型
├── ViewModels/            # 视图模型(MVVM)
├── Converters/            # 值转换器
├── Themes/                # 主题资源
│   ├── LightTheme.xaml    # 浅色主题
│   └── DarkTheme.xaml     # 深色主题
├── MainWindow.xaml        # 主窗口
└── App.xaml               # 应用程序定义
```

## 主题切换

本项目实现了动态主题切换功能：

1. 通过MVVM模式示例页面中的RadioButton切换主题
2. 支持浅色主题、深色主题和跟随系统设置
3. 主题变化会影响整个应用程序界面

## 主要特性详解

### 1. 基本用法

展示了RadioButton的选中状态、内容设置、事件响应等基础功能。

### 2. 分组管理

通过设置`GroupName`属性，将多个RadioButton归为一组，保证组内只有一个选项被选中。

### 3. 数据绑定

演示了RadioButton与数据模型的双向绑定，包括与枚举类型的绑定。

### 4. 样式与模板

展示如何自定义RadioButton的外观，包括使用样式和控件模板。

### 5. 选项卡示例

使用RadioButton实现类似TabControl的选项卡界面效果。

### 6. 问卷调查示例

在表单应用中使用RadioButton构建调查问卷。

### 7. MVVM模式示例

在MVVM架构下使用RadioButton，实现了主题切换功能，展示了命令绑定和视图模型。

## 技术要点

* XAML界面设计
* 样式与控件模板
* 数据绑定
* 命令模式
* MVVM架构
* 资源字典与主题
* 事件处理

## 参考资料

* [Microsoft WPF RadioButton文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.controls.radiobutton)
* [WPF MVVM模式](https://learn.microsoft.com/zh-cn/windows/uwp/data-binding/data-binding-and-mvvm)

## 许可证

本项目采用MIT许可证。 
