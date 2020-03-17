using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Measures.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Measures
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        #region 构造函数
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region 字段
        DonateDialog donateDialog = new DonateDialog();
        AboutDialog aboutDialog = new AboutDialog();
        private string lastAccent;
        // 颜色枚举
        private enum AccentEnum
        {
            Red = 0,
            Green = 1,
            Blue = 2,
            Purple = 3,
            Orange = 4,
            Lime = 5,
            Emerald = 6,
            Teal = 7,
            Cyan = 8,
            Cobalt = 9,
            Indigo = 10,
            Violet = 11,
            Pink = 12,
            Magenta = 13,
            Crimson = 14,
            Amber = 15,
            Yellow = 16,
            Brown = 17,
            Olive = 18,
            Steel = 19,
            Mauve = 20,
            Taupe = 21,
            Sienna = 22,
        }
        #endregion

        #region 属性
        private string _apptheme = "BaseLight";
        public string AppTheme
        {
            get { return _apptheme; }
            set { _apptheme = value; }
        }
        #endregion

        #region 方法
        private async void btnDonate_Click(object sender, RoutedEventArgs e)
        {
            donateDialog.btnClose.Click += btnClose_Donate;
            await this.ShowMetroDialogAsync(donateDialog);
        }

        private async void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            aboutDialog.btnClose.Click += btnClose_About;
            await this.ShowMetroDialogAsync(aboutDialog);
        }

        private void btnClose_About(object sender, RoutedEventArgs e)
        {
            this.HideMetroDialogAsync(aboutDialog);
        }

        private void btnClose_Donate(object sender, RoutedEventArgs e)
        {
            this.HideMetroDialogAsync(donateDialog);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeTheme(RandomAccent(), this.AppTheme);
        }

        // TabControl更改标签页时随机更改主题颜色
        private void tabMeasures_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ChangeTheme(RandomAccent(), this.AppTheme);
        }

        // 相应明暗模式切换
        private void btnTheme_IsCheckedChanged(object sender, EventArgs e)
        {
            if (this.btnTheme.IsChecked == false)
                this.AppTheme = "BaseLight";
            else
                this.AppTheme = "BaseDark";
            ChangeTheme(lastAccent, this.AppTheme);
        }

        // 改变主题
        private void ChangeTheme(string accent, string apptheme)
        {
            ThemeManager.ChangeAppStyle(Application.Current,
                                                    ThemeManager.GetAccent(accent),
                                                    ThemeManager.GetAppTheme(apptheme));
        }

        // 生成随机颜色名称
        private string RandomAccent()
        {
            Array values = Enum.GetValues(typeof(AccentEnum));
            Random random = new Random();
            AccentEnum randomAccent = (AccentEnum)values.GetValue(random.Next(values.Length));
            lastAccent = randomAccent.ToString();
            return lastAccent;
        }

        // 双击复制到剪切板
        private void TextBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var obj = sender as TextBox;
            obj.SelectAll();
            obj.Copy();
        }
        #endregion
    }
}
