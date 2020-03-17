using MahApps.Metro.Controls.Dialogs;
using Measures.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Measures.Views
{
    /// <summary>
    /// AboutDialog.xaml 的交互逻辑
    /// </summary>
    public partial class AboutDialog : CustomDialog
    {
        public AboutDialog()
        {
            InitializeComponent();

            this.AppName = GetAssemblyTitle();
            this.AppVersion = "版本：" + GetAssemblyVersion();
            this.AppCopyright = GetAssemblyCopyright();
            this.uriBlog = new Uri("https://iktcao.github.io/");
            this.uriGithub = new Uri("https://github.com/iktcao/");
            this.uriEmail = new Uri("mailto:iktcao@gmail.com?subject=关于工程单位换算程序的反馈&body=反馈如下:");

            this.SupportInfos = new ObservableCollection<SupportInfo>()
            {
                new SupportInfo("/Asserts/Images/MVVMLight.png",
                    "http://www.mvvmlight.net/", "MVVM Light Toolkit"),
                new SupportInfo("/Asserts/Images/MahApps.Metro.png",
                    "https://mahapps.com/", "MahApps.Metro"),
            };

            this.DataContext = this;
        }

        public string AppName { get; set; }
        public string AppVersion { get; set; }
        public string AppCopyright { get; set; }
        public ObservableCollection<SupportInfo> SupportInfos { get; set; }

        private Uri uriGithub;
        private Uri uriEmail;
        private Uri uriBlog;

        // 打开超链接
        private void OpenLink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(e.Uri.AbsoluteUri);
                e.Handled = true;
            }
            catch (System.Exception)
            {
                throw new DirectoryNotFoundException();
            }
        }

        // 获取程序集标题
        public string GetAssemblyTitle()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute title = (AssemblyTitleAttribute)attributes[0];
                if (!string.IsNullOrEmpty(title.Title))
                    return title.Title;
            }
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }

        // 获取程序集版本
        public string GetAssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        // 获取程序集版权声明
        public string GetAssemblyCopyright()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }

        // 获取程序集描述说明
        public string GetAssemblyDescription()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }

        private void btnGithub_Click(object sender, RoutedEventArgs e)
        {

            Process.Start(this.uriGithub.AbsoluteUri);
            e.Handled = true;
        }

        private void btnBlog_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(this.uriBlog.AbsoluteUri);
            e.Handled = true;
        }

        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(this.uriEmail.AbsoluteUri);
            e.Handled = true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}