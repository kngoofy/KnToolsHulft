using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KnToolsHulftUI
{
    /// <summary>
    /// About.xaml の相互作用ロジック
    /// </summary>
    public partial class About : Window
    {
        /// <summary>
        /// HelpのAboutウィンドウ
        /// </summary>
        public About()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 終了
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
