using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;
using KnToolsHulft;
using KnToolsHulft.Data;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;

namespace KnToolsHulftUI
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            string holderName = Directory.GetCurrentDirectory();
            HulftBookName.Text = holderName + "\\" + "hulftBook.xlsx";
            //_ = HulftBookName.Focus();
        }

        /// <summary>
        /// window 終了
        /// </summary>
        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// HelpのAboutウィンドウ表示
        /// </summary>
        private void OnMenuAbout(object sender, RoutedEventArgs e)
        {
            var _childWindow = new About();
            _childWindow.Top = this.Top + 120;
            _childWindow.Left = this.Left + 120;
            _childWindow.ShowDialog();
        }

        /// <summary>
        /// クリックされて、ExcelBook ファイルを指定するメソッド
        /// </summary>
        private void Button_Click_SelectHulftBook(object sender, RoutedEventArgs e)
        {
            OpenDocumentHulftBook();
        }

        /// <summary>
        /// ExcelBook ファイルをopenFileDialogにて設定するメソッド
        /// </summary>
        private void OpenDocumentHulftBook()
        {
            try
            {
                // テキストボックスからファイル名 (ファイルパス) を取得
                string fileName = HulftBookName.Text;

                // OpenFileDialog クラスのインスタンスを生成
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.FileName = "hulftBook.xlsx";
                    openFileDialog.DefaultExt = ".xlsx";
                    openFileDialog.CheckFileExists = false;     //存在しなくも良いを指定

                    // ファイルの種類リストを設定
                    openFileDialog.Filter = "HultBook(.xlsx)|*.xlsx";

                    // テキストボックスにファイル名 (ファイルパス) が設定されている場合は
                    // ファイルのディレクトリー (フォルダー) を初期表示する
                    if (fileName != string.Empty)
                    {
                        // FileInfo クラスのインスタンスを生成
                        FileInfo fileInfo = new FileInfo(fileName);
                        // ディレクトリー名 (ディレクトリーパス) を取得
                        string directoryName = fileInfo.DirectoryName;
                        // 存在する場合は InitialDirectory プロパティに設定
                        if (Directory.Exists(directoryName))
                        {
                            openFileDialog.InitialDirectory = directoryName;
                        }
                    }

                    // ダイアログを表示
                    DialogResult dialogResult = openFileDialog.ShowDialog();
                    if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        // キャンセルされたので終了
                        return;
                    }

                    // 選択されたファイル名 (ファイルパス) をテキストボックスに設定
                    this.HulftBookName.Text = openFileDialog.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// HulftBookTextBoxへドラッグオーバーのメソッド
        /// </summary>
        private void EhDragOverHulftBookDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Effects = IsSingleFile(args) != null ? System.Windows.DragDropEffects.Copy : System.Windows.DragDropEffects.None;
            args.Handled = true;
        }

        /// <summary>
        /// Hulft定義(Snd)のTextBoxへドラッグオーバーのメソッド
        /// </summary>
        private void EhDragOverSndDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Effects = IsSingleFile(args) != null ? System.Windows.DragDropEffects.Copy : System.Windows.DragDropEffects.None;
            args.Handled = true;
        }
        /// <summary>
        /// Hulft定義(Rcv)のTextBoxへドラッグオーバーのメソッド
        /// </summary>
        private void EhDragOverRcvDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Effects = IsSingleFile(args) != null ? System.Windows.DragDropEffects.Copy : System.Windows.DragDropEffects.None;
            args.Handled = true;
        }
        /// <summary>
        /// Hulft定義(Hst)のTextBoxへドラッグオーバーのメソッド
        /// </summary>
        private void EhDragOverHstDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Effects = IsSingleFile(args) != null ? System.Windows.DragDropEffects.Copy : System.Windows.DragDropEffects.None;
            args.Handled = true;
        }
        /// <summary>
        /// Hulft定義(TGrp)のTextBoxへドラッグオーバーのメソッド
        /// </summary>
        private void EhDragOverTGrpDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Effects = IsSingleFile(args) != null ? System.Windows.DragDropEffects.Copy : System.Windows.DragDropEffects.None;
            args.Handled = true;
        }
        /// <summary>
        /// Hulft定義(Job)のTextBoxへドラッグオーバーのメソッド
        /// </summary>
        private void EhDragOverJobDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Effects = IsSingleFile(args) != null ? System.Windows.DragDropEffects.Copy : System.Windows.DragDropEffects.None;
            args.Handled = true;
        }

        /// <summary>
        /// ドラッグオーバーしているファイルのシングルファイルかを調べるメソッド
        /// </summary>
        private string IsSingleFile(System.Windows.DragEventArgs args)
        {
            // Check for files in the hovering data object.
            if (args.Data.GetDataPresent(System.Windows.DataFormats.FileDrop, true))
            {
                var fileNames = args.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
                // Check for a single file or folder.
                if (fileNames?.Length is 1)
                {
                    // Check for a file (a directory will return false).
                    if (File.Exists(fileNames[0]))
                    {
                        // At this point we know there is a single file.
                        return fileNames[0];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// HulftBookのTextBoxへのドラッグアンドロップのメソッド
        /// </summary>
        private void EhDropHulftBookDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Handled = true;    // Mark the event as handled, so TextBox's native Drop handler is not called.
            var fileNames = args.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
            HulftBookName.Text = fileNames[0];
        }

        /// <summary>
        /// Hulft定義(Snd)のTextBoxへのドラッグアンドロップのメソッド
        /// </summary>
        private void EhDropSndDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Handled = true;    // Mark the event as handled, so TextBox's native Drop handler is not called.
            var fileNames = args.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
            tbHulftSndDefFileName.Text = fileNames[0];
        }

        /// <summary>
        /// Hulft定義(Rcv)のTextBoxへのドラッグアンドロップのメソッド
        /// </summary>
        private void EhDropRcvDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Handled = true;    // Mark the event as handled, so TextBox's native Drop handler is not called.
            var fileNames = args.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
            tbHulftRcvDefFileName.Text = fileNames[0];
        }

        /// <summary>
        /// Hulft定義(Hst)のTextBoxへのドラッグアンドロップのメソッド
        /// </summary>
        private void EhDropHstDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Handled = true;    // Mark the event as handled, so TextBox's native Drop handler is not called.
            var fileNames = args.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
            tbHulftHstDefFileName.Text = fileNames[0];
        }

        /// <summary>
        /// Hulft定義(TGrp)のTextBoxへのドラッグアンドロップのメソッド
        /// </summary>
        private void EhDropTGrpDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Handled = true;    // Mark the event as handled, so TextBox's native Drop handler is not called.
            var fileNames = args.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
            tbHulftTGrpDefFileName.Text = fileNames[0];
        }

        /// <summary>
        /// Hulft定義(Job)のTextBoxへのドラッグアンドロップのメソッド
        /// </summary>
        private void EhDropJobDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Handled = true;    // Mark the event as handled, so TextBox's native Drop handler is not called.
            var fileNames = args.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
            tbHulftJobDefFileName.Text = fileNames[0];
        }

        /// <summary>
        /// Hulft定義ファイル(Snd)を指定するダイアログを呼び出すメソッド
        /// </summary>
        private void Button_Click_Snd(object sender, RoutedEventArgs e)
        {
            OpenDocumentDef(tbHulftSndDefFileName);
        }

        /// <summary>
        /// Hulft定義ファイル(Rcv)を指定するダイアログを呼び出すメソッド
        /// </summary>
        private void Button_Click_Rcv(object sender, RoutedEventArgs e)
        {
            OpenDocumentDef(tbHulftRcvDefFileName);
        }

        /// <summary>
        /// Hulft定義ファイル(Hst)を指定するダイアログを呼び出すメソッド
        /// </summary>
        private void Button_Click_Hst(object sender, RoutedEventArgs e)
        {
            OpenDocumentDef(tbHulftHstDefFileName);
        }

        /// <summary>
        /// Hulft定義ファイル(TGrp)を指定するダイアログを呼び出すメソッド
        /// </summary>
        private void Button_Click_TGrp(object sender, RoutedEventArgs e)
        {
            OpenDocumentDef(tbHulftTGrpDefFileName);
        }

        /// <summary>
        /// Hulft定義ファイル(Job)を指定するダイアログを呼び出すメソッド
        /// </summary>
        private void Button_Click_Job(object sender, RoutedEventArgs e)
        {
            OpenDocumentDef(tbHulftJobDefFileName);
        }

        /// <summary>
        /// Hulft定義ファイルを指定するダイアログを表示するメソッド
        /// </summary>
        /// <param name="defName">WfpのTextBoxのコントロール</param>
        private void OpenDocumentDef(System.Windows.Controls.TextBox defName)
        {
            try
            {
                // 
                string fileName = defName.Text;

                // OpenFileDialog クラスのインスタンスを生成
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.FileName = System.IO.Path.GetFileName(fileName);
                    openFileDialog.DefaultExt = ".def";
                    openFileDialog.CheckFileExists = true;     //存在しなくてはいけない

                    // ファイルの種類リストを設定
                    openFileDialog.Filter = "HultDefine(.def,*.txt)|*.def;*.txt|すべてのファイル(*.*)|*.*";

                    // テキストボックスにファイル名 (ファイルパス) が設定されている場合は
                    // ファイルのディレクトリー (フォルダー) を初期表示する
                    if (fileName != string.Empty)
                    {
                        // FileInfo クラスのインスタンスを生成
                        FileInfo fileInfo = new FileInfo(fileName);
                        // ディレクトリー名 (ディレクトリーパス) を取得
                        string directoryName = fileInfo.DirectoryName;
                        // 存在する場合は InitialDirectory プロパティに設定
                        if (Directory.Exists(directoryName))
                        {
                            openFileDialog.InitialDirectory = directoryName;
                        }
                    }

                    // ダイアログを表示
                    DialogResult dialogResult = openFileDialog.ShowDialog();
                    if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        // キャンセルされたので終了
                        return;
                    }

                    // 選択されたファイル名 (ファイルパス) をテキストボックスに設定
                    defName.Text = openFileDialog.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// HulftBook を作成するメソッド
        /// </summary>
        private async void Button_Click_CreateHulftBook(object sender, RoutedEventArgs e)
        {
            var file = HulftBookName.Text;
            if (string.IsNullOrWhiteSpace(file))
            {
                //MessageBox.Show("生成するHulftBookを指定して下さい。");
                HulftBookName.Focus();
                await DialogHost.Show(new MyMsgBox("生成するHulftBookファイルの指定がありません。指定して下さい。"));

                return;
            }
            // HulftBookのフォルダは問題ないか？
            // FileInfo クラスのインスタンスを生成
            FileInfo fileInfo = new FileInfo(HulftBookName.Text);
            // ディレクトリー名 (ディレクトリーパス) を取得
            string directoryName = fileInfo.DirectoryName;
            // 存在する場合は InitialDirectory プロパティに設定
            if (!Directory.Exists(directoryName))
            {
                //MessageBox.Show("指定したHulftBookのフォルダを見直して下さい。");
                HulftBookName.Focusable = true;
                _ = HulftBookName.Focus();
                await DialogHost.Show(new MyMsgBox("指定したHulftBookのフォルダを見直して下さい。"));
                return;
            }

            var defs = new Dictionary<string, string>()
            {
                 { "snd",null }
                ,{ "rcv",null }
                ,{ "hst",null }
                ,{ "tgrp",null }
                ,{ "job",null }
            };

            // カーソルをくるくるに変える
            this.Cursor = System.Windows.Input.Cursors.Wait;

            // Snd
            if ((tbHulftSndDefFileName.Text != string.Empty) && File.Exists(tbHulftSndDefFileName.Text))
            {
                defs["snd"] = tbHulftSndDefFileName.Text;
            }
            // Rcv
            if ((tbHulftRcvDefFileName.Text != string.Empty) && File.Exists(tbHulftRcvDefFileName.Text))
            {
                defs["rcv"] = tbHulftRcvDefFileName.Text;
            }
            // Hst
            if ((tbHulftHstDefFileName.Text != string.Empty) && File.Exists(tbHulftHstDefFileName.Text))
            {
                defs["hst"] = tbHulftHstDefFileName.Text;
            }
            // TGrp
            if ((tbHulftTGrpDefFileName.Text != string.Empty) && File.Exists(tbHulftTGrpDefFileName.Text))
            {
                defs["tgrp"] = tbHulftTGrpDefFileName.Text;
            }
            // Job
            if ((tbHulftJobDefFileName.Text != string.Empty) && File.Exists(tbHulftJobDefFileName.Text))
            {
                defs["job"] = tbHulftJobDefFileName.Text;
            }

            var book = HulftBookName.Text;
            new CreateNewTemplateBook(book);

            if (defs["snd"] != null)
            {
                List<HulftSndDef> hulftSndDatas = BuildHulftSndDef.StreamBuildHulftSndDef(defs["snd"]);
                new UpdateBook(book, hulftSndDatas);
            }
            if (defs["rcv"] != null)
            {
                List<HulftRcvDef> hulftRcvDatas = BuildHulftRcvDef.StreamBuildHulftRcvDef(defs["rcv"]);
                new UpdateBook(book, hulftRcvDatas);
            }
            if (defs["hst"] != null)
            {
                List<HulftHstDef> hulftHstDatas = BuildHulftHstDef.StreamBuildHulftHstDef(defs["hst"]);
                new UpdateBook(book, hulftHstDatas);
            }
            if (defs["tgrp"] != null)
            {
                List<HulftTGrpDef> hulftTGrpDatas = BuildHulftTGrpDef.StreamBuildHulftTGrpDef(defs["tgrp"]);
                new UpdateBook(book, hulftTGrpDatas);
            }
            if (defs["job"] != null)
            {
                List<HulftJobDef> hulftJobDatas = BuildHulftJobDef.StreamBuildHulftJobDef(defs["job"]);
                new UpdateBook(book, hulftJobDatas);
            }

            // カーソルを戻す
            this.Cursor = null;

        }

    }
}
