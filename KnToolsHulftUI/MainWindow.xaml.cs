﻿using System;
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

namespace KnToolsHulftUI
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var path = Directory.GetCurrentDirectory();

            var holderName = Directory.GetCurrentDirectory();
            HulftBookName.Text = holderName + "\\" + "hulftBook.xlsx";

            //tbHulftSndDefFileName.Text = holderName + "\\" + "snd.def";
            //tbHulftRcvDefFileName.Text = holderName + "\\" + "rcv.def";
            //tbHulftHstDefFileName.Text = holderName + "\\" + "hst.def"; ;
            //tbHulftTGrpDefFileName.Text = holderName + "\\" + "tgrp.def"; ;

        }

        // window 終了
        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// クリックされて、ExcelBook ファイルを指定するメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                string fileName = this.HulftBookName.Text;

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
        /// ドラッグオーバーしているファイルのシングルファイルかを調べるメソッド
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
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
                    openFileDialog.CheckFileExists = false;     //存在しなくも良いを指定

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
        private void Button_Click_CreateHulftBook(object sender, RoutedEventArgs e)
        {
            // HulftBookのフォルダは問題ないか？
            // FileInfo クラスのインスタンスを生成
            FileInfo fileInfo = new FileInfo(HulftBookName.Text);
            // ディレクトリー名 (ディレクトリーパス) を取得
            string directoryName = fileInfo.DirectoryName;
            // 存在する場合は InitialDirectory プロパティに設定
            if (!Directory.Exists(directoryName))
            {
                MessageBox.Show("HulftBookのフォルダを見直して下さい。");
            }

            var defs = new Dictionary<string, string>()
            {
                 { "snd",null }
                ,{ "rcv",null }
                ,{ "hst",null }
                ,{ "TGrp",null }
            };

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
                defs["Hst"] = tbHulftHstDefFileName.Text;
            }
            // TGrp
            if ((tbHulftTGrpDefFileName.Text != string.Empty) && File.Exists(tbHulftTGrpDefFileName.Text))
            {
                defs["TGrp"] = tbHulftTGrpDefFileName.Text;
            }

            var book = HulftBookName.Text;
            var makeSheet = new CreateNewTemplateBook(book);

            if (defs["snd"] != null)
            {
                var hulftSndData = new BuildHulftSndDef();
                List<HulftSndDef> hulftSndDatas = hulftSndData.ReadBuildHulftSndDef(defs["snd"]);
                var updateBookSndSheet = new UpdateBook(book, hulftSndDatas);
            }
            if (defs["rcv"] != null)
            {
                var hulftRcvData = new BuildHulftRcvDef();
                List<HulftRcvDef> hulftRcvDatas = hulftRcvData.ReadBuildHulftRcvDef(defs["rcv"]);
                var updateBookSndSheet = new UpdateBook(book, hulftRcvDatas);
            }
            if (defs["hst"] != null)
            {
                var hulftHstData = new BuildHulftHstDef();
                List<HulftHstDef> hulftHstDatas = hulftHstData.ReadBuildHulftHstDef(defs["Hst"]);
                var updateBookSndSheet = new UpdateBook(book, hulftHstDatas);
            }
            if (defs["TGrp"] != null)
            {
                var hulftTGrpData = new BuildHulftTGrpDef();
                List<HulftTGrpDef> hulftTGrpDatas = hulftTGrpData.ReadBuildHulftTGrpDef(defs["TGrp"]);
                var updateBookSndSheet = new UpdateBook(book, hulftTGrpDatas);
            }
        }

    }
}
