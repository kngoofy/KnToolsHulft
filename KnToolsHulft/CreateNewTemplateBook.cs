using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using KnToolsHulft.Data;

namespace KnToolsHulft
{
    /// <summary>
    /// ExcelBookのテンプレート作成関連のクラス
    /// </summary>
    public class CreateNewTemplateBook
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sheetName">テンプレートとしてのExcelブックのファイル名</param>
        public CreateNewTemplateBook(string sheetName)
        {
            this.NewExcelBook(sheetName);
        }

        /// <summary>
        /// Excelブックの中身を構成していくメソッド
        /// </summary>
        /// <param name="bookName">Excelファイル名</param>
        /// <returns></returns>
        public bool NewExcelBook(string bookName)
        {
            try
            {
                //Hulft定義Bookのテンプレートを新規に作成
                IWorkbook book = new XSSFWorkbook();

                Dictionary<String, ICellStyle> styles = MyCreateStyles.CreateStyles(book);

                //定型シートを作成
                book.CreateSheet(ConstHulft.SHEETNAME_IDX);
                book.CreateSheet(ConstHulft.SHEETNAME_SND);
                book.CreateSheet(ConstHulft.SHEETNAME_RCV);
                book.CreateSheet(ConstHulft.SHEETNAME_GRP);
                book.CreateSheet(ConstHulft.SHEETNAME_HST);
                book.CreateSheet(ConstHulft.SHEETNAME_JOB);

                var sheetIdx = book.GetSheet(ConstHulft.SHEETNAME_IDX);
                var sheetSnd = book.GetSheet(ConstHulft.SHEETNAME_SND);
                var sheetRcv = book.GetSheet(ConstHulft.SHEETNAME_RCV);
                var sheetGrp = book.GetSheet(ConstHulft.SHEETNAME_GRP);
                var sheetHst = book.GetSheet(ConstHulft.SHEETNAME_HST);
                var sheetJob = book.GetSheet(ConstHulft.SHEETNAME_JOB);

                //定型シートの中身を整える
                FormatSheetIdx(styles, sheetIdx);
                FormatSheetSnd(styles, sheetSnd);
                FormatSheetRcv(styles, sheetRcv);
                FormatSheetGrp(styles, sheetGrp);
                FormatSheetHst(styles, sheetHst);
                FormatSheetJob(styles, sheetJob);

                //テンプレートBookを書き出す
                using (var fs = new FileStream(bookName, FileMode.Create))
                {
                    book.Write(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return true;
        }

        /// <summary>
        /// Book内のIndexシートの飾り付けるメソッド
        /// </summary>
        /// <param name="book">ExcelBookのIクラス</param>
        /// <param name="styles">使用するスタイルのDictionary</param>
        /// <param name="sheet">ExcelSheetのIクラス</param>
        /// <returns>Bool True or False</returns>
        public bool FormatSheetIdx(Dictionary<String, ICellStyle> styles, ISheet sheet)
        {
            //メモリ線を非表示
            sheet.DisplayGridlines = false;

            //TopLeft シートタイトル埋め込み
            WriteCell(sheet, styles["topleft"], (0, 0), ConstHulft.SHEETNAME_IDX);

            //Sheetのインデックス埋め込み
            var titles = new List<(int no, string name)> {
                  (1,ConstHulft.SHEETNAME_SND)
                , (2,ConstHulft.SHEETNAME_RCV)
                , (3,ConstHulft.SHEETNAME_GRP)
                , (4,ConstHulft.SHEETNAME_HST)
                , (5,ConstHulft.SHEETNAME_JOB)
            };

            //Sheetの中身を整える
            (int y, int x) = (1, 1);

            foreach (var (no, name) in titles)
            {
                //番号埋め
                WriteCell(sheet, styles["indexBox"], (y + no, x), no);

                //シート名を埋めてリンクを付ける
                var link = new XSSFHyperlink(HyperlinkType.Document)
                {
                    Address = name + "!A1"
                };
                WriteCell(sheet, styles["indexLabel"], link, (y + no, x + 1), name);
            }

            //カラムの横幅Autoが好き
            sheet.AutoSizeColumn(0, true);

            return true;
        }

        /// <summary>
        /// Book内のSndシートを飾り付けるメソッド HULFT配信定義用シート
        /// </summary>
        /// <param name="styles">CellStyleをセットしたDictionaryオブジェクト</param>
        /// <param name="sheet">Sndシートオブジェクト</param>
        /// <returns>true or false</returns>
        public bool FormatSheetSnd(Dictionary<String, ICellStyle> styles, ISheet sheet)
        {
            sheet.DisplayGridlines = false;
            WriteCell(sheet, styles["topleft"], (0, 0), ConstHulft.SHEETNAME_SND);
            return true;
        }

        /// <summary>
        /// Book内のRcvシートを飾り付けるメソッド HULFT集信定義用シート
        /// </summary>
        /// <param name="styles"></param>
        /// <param name="sheet">Rcvシートオブジェクト</param>
        /// <returns>true or false</returns>
        public bool FormatSheetRcv(Dictionary<String, ICellStyle> styles, ISheet sheet)
        {
            sheet.DisplayGridlines = false;
            WriteCell(sheet, styles["topleft"], (0, 0), ConstHulft.SHEETNAME_RCV);
            return true;
        }

        /// <summary>
        /// Book内のHostシートを飾り付けるメソッド HULFTホスト詳細定義用シート
        /// </summary>
        /// <param name="styles">CellStyleをセットしたDictionaryオブジェクト</param>
        /// <param name="sheet">Hostシートオブジェクト</param>
        /// <returns>true or false</returns>
        public bool FormatSheetHst(Dictionary<String, ICellStyle> styles, ISheet sheet)
        {
            sheet.DisplayGridlines = false;
            WriteCell(sheet, styles["topleft"], (0, 0), ConstHulft.SHEETNAME_HST);
            return true;
        }

        /// <summary>
        /// Book内のGroupシートを飾り付けるメソッド HULFT転送グループ定義用シート
        /// </summary>
        /// <param name="styles">CellStyleをセットしたDictionaryオブジェクト</param>
        /// <param name="sheet">Groupシートオブジェクト</param>
        /// <returns>true or false</returns>
        public bool FormatSheetGrp(Dictionary<String, ICellStyle> styles, ISheet sheet)
        {
            sheet.DisplayGridlines = false;
            WriteCell(sheet, styles["topleft"], (0, 0), ConstHulft.SHEETNAME_GRP);
            return true;
        }

        /// <summary>
        /// Book内のJobシートを飾り付けるメソッド HULFTジョブ定義用シート
        /// </summary>
        /// <param name="styles">CellStyleをセットしたDictionaryオブジェクト</param>
        /// <param name="sheet">Jobシートオブジェクト</param>
        /// <returns>true or false</returns>
        public bool FormatSheetJob(Dictionary<String, ICellStyle> styles, ISheet sheet)
        {
            sheet.DisplayGridlines = false;
            WriteCell(sheet, styles["topleft"], (0, 0), ConstHulft.SHEETNAME_JOB);
            return true;
        }


        /// <summary>
        /// セルに書式を付けるメソッド Cellに数字を設定
        /// </summary>
        /// <param name="sheet">対象Sheetオブジェクト</param>
        /// <param name="style">Cellに設定するstyleオブジェクト</param>
        /// <param name="s">セルの行と列(タプル)</param>
        /// <param name="value">Cellに設定する数値</param>
        public static void WriteCell(ISheet sheet, ICellStyle style, (int y, int x) s, int value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.SetCellValue(value);
            cell.CellStyle = style;
            cell.SetCellType(CellType.Numeric);
        }

        /// <summary>
        /// セルに書式を付けるメソッド Cellに文字列を設定
        /// </summary>
        /// <param name="sheet">対象Sheetオブジェクト</param>
        /// <param name="style">Cellに設定するstyleオブジェクト</param>
        /// <param name="s">セルの行と列(タプル)</param>
        /// <param name="value">Cellに設定する文字列</param>
        public static void WriteCell(ISheet sheet, ICellStyle style, (int y, int x) s, string value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.SetCellValue(value);
            cell.CellStyle = style;
            cell.SetCellType(CellType.String);
        }

        /// <summary>
        /// セルに書式を付けるメソッド Cellにハイパーリンクつける
        /// </summary>
        /// <param name="sheet">対象Sheetオブジェクト</param>
        /// <param name="style">Cellに設定するstyleオブジェクト</param>
        /// <param name="link">リンク</param>
        /// <param name="s">セルの行と列(タプル)</param>
        /// <param name="value">Cellに設定する文字列</param>
        public static void WriteCell(ISheet sheet, ICellStyle style, IHyperlink link, (int y, int x) s, string value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.Hyperlink = link;
            cell.SetCellValue(value);
            cell.CellStyle = style;
            cell.SetCellType(CellType.String);
        }

    }
}
