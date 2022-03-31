using System;//
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPOI.SS.UserModel;

using NPOI.XSSF.UserModel;
using KnToolsHulft.Data;
using NPOI.SS.Util;

namespace KnToolsHulft
{
    /// <summary>
    /// ExcelBookの各Sheetにデータを埋め、書式を組み立てるクラス 
    /// </summary>
    public class UpdateBook
    {
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        /// <param name="outputFile">ExcelBookファイル名</param>
        /// <param name="sndLists">HULFT配信定義を組み立てたList</param>
        public UpdateBook(string outputFile, List<HulftSndDef> sndLists)
        {
            try
            {
                var book = WorkbookFactory.Create(outputFile);
                // 各シートを埋める
                UpdateSndBook(book, sndLists);

                // UpdateしたExcelファイルを閉じる
                using (var fs = new FileStream(outputFile, FileMode.Create))
                {
                    book.Write(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        /// <param name="outputFile">ExcelBookファイル名</param>
        /// <param name="rcvLists">HULFT集信定義を組み立てたList</param>
        public UpdateBook(string outputFile, List<HulftRcvDef> rcvLists)
        {
            try
            {
                var book = WorkbookFactory.Create(outputFile);
                // 各シートを埋める
                UpdateRcvBook(book, rcvLists);

                // UpdateしたExcelファイルを閉じる
                using (var fs = new FileStream(outputFile, FileMode.Create))
                {
                    book.Write(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        /// <param name="outputFile">ExcelBookファイル名</param>
        /// <param name="hstLists">HULFTホスト定義を組み立てたList</param>
        public UpdateBook(string outputFile, List<HulftHstDef> hstLists)
        {
            try
            {
                var book = WorkbookFactory.Create(outputFile);
                // 各シートを埋める
                UpdateHstBook(book, hstLists);

                // UpdateしたExcelファイルを閉じる
                using (var fs = new FileStream(outputFile, FileMode.Create))
                {
                    book.Write(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        /// <param name="outputFile">ExcelBookファイル名</param>
        /// <param name="tgrpLists">HULFT転送グループを組み立てたList</param>
        public UpdateBook(string outputFile, List<HulftTGrpDef> tgrpLists)
        {
            try
            {
                var book = WorkbookFactory.Create(outputFile);
                // 各シートを埋める
                UpdateTGrpBook(book, tgrpLists);

                // UpdateしたExcelファイルを閉じる
                using (var fs = new FileStream(outputFile, FileMode.Create))
                {
                    book.Write(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="outputFile">ExcelBookファイル名</param>
        /// <param name="sndLists">HULFT配信定義を組み立てたList</param>
        /// <param name="rcvLists">HULFT集信定義を組み立てたList</param>
        /// <param name="tgrpLists">HULFT転送グループ定義を組み立てたList</param>
        /// <param name="hstLists">HULFTホスト定義を組み立てたList</param>
        public UpdateBook(string outputFile, List<HulftSndDef> sndLists, List<HulftRcvDef> rcvLists, List<HulftTGrpDef> tgrpLists, List<HulftHstDef> hstLists)
        {
            // Bookの中身を埋める
            try
            {
                var book = WorkbookFactory.Create(outputFile);

                // セルに充てるスタイルの組み立て
                //Dictionary<String, ICellStyle> styles = MyCreateStyles.createStyles(book);
                // 各シートを埋める
                UpdateSndBook(book, sndLists);
                UpdateRcvBook(book, rcvLists);
                UpdateHstBook(book, hstLists);
                UpdateTGrpBook(book, tgrpLists);

                // UpdateしたExcelファイルを閉じる
                using (var fs = new FileStream(outputFile, FileMode.Create))
                {
                    book.Write(fs);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Sndシートのデータ埋めと書式あてこみメソッド
        /// </summary>
        /// <param name="book">ExcelBookオブジェクト</param>
        /// <param name="lists">HULFT配信定義データオブジェクト</param>
        /// <returns></returns>
        public bool UpdateSndBook(IWorkbook book, List<HulftSndDef> lists)
        {
            var sheet = book.GetSheet(ConstHulft.SHEETNAME_SND);

            // セルに充てるスタイルの組み立て
            Dictionary<String, ICellStyle> styles = MyCreateStyles.CreateStyles(book);

            // 左上にシート名を
            WriteCell(sheet, styles["indexLabel"], (0, 0), ConstHulft.SHEETNAME_SND);

            // データヘッダーの組み立て
            var header = new HulftSndDef("Header");
            //var headerArray = header.getValueArray();
            var headerList = header.GetListValues();

            // データヘッダーブロックの書き出し
            (int y, int x) p = (2, 1);
            headerList.Insert(0, "No.");
            for (int x = 0; x < headerList.Count; x++)
            {
                WriteCell(sheet, styles["indexLabel"], (p.y, p.x + x), headerList[x]);
            }
            sheet.SetAutoFilter(new CellRangeAddress(p.y, p.y, p.x, p.x+ headerList.Count-1));

            // データブロックの書き出し
            p = (3, 1);
            for (int y = 0; y < lists.Count; y++)
            {
                var dataList = lists[y].GetListValues();
                dataList.Insert(0, (y + 1).ToString());
                for (int x = 0; x < dataList.Count; x++)
                {
                    WriteCell(sheet, styles["defData"], (p.y + y, p.x + x), dataList[x]);
                    sheet.AutoSizeColumn(p.x + x, true);
                }
            }

            return true;
        }

        /// <summary>
        /// Rcvシートのデータ埋めと書式あてこみメソッド
        /// </summary>
        /// <param name="book">ExcelBookオブジェクト</param>
        /// <param name="lists">HULFT集信定義データオブジェクト</param>
        /// <returns></returns>
        public bool UpdateRcvBook(IWorkbook book, List<HulftRcvDef> lists)
        {
            var sheet = book.GetSheet(ConstHulft.SHEETNAME_RCV);

            // セルに充てるスタイルの組み立て
            Dictionary<String, ICellStyle> styles = MyCreateStyles.CreateStyles(book);

            // 左上にシート名を
            WriteCell(sheet, styles["indexLabel"], (0, 0), ConstHulft.SHEETNAME_RCV);

            // データヘッダーの組み立て
            var header = new HulftRcvDef("Header");
            //var headerArray = header.getValueArray();
            var headerList = header.GetListValues();

            // データヘッダーブロックの書き出し
            (int y, int x) p = (2, 1);
            headerList.Insert(0, "No.");
            for (int x = 0; x < headerList.Count; x++)
            {
                WriteCell(sheet, styles["indexLabel"], (p.y, p.x + x), headerList[x]);
            }
            sheet.SetAutoFilter(new CellRangeAddress(p.y, p.y, p.x, p.x + headerList.Count - 1));

            // データブロックの書き出し
            p = (3, 1);
            for (int y = 0; y < lists.Count; y++)
            {
                var dataList = lists[y].GetListValues();
                dataList.Insert(0, (y + 1).ToString());
                for (int x = 0; x < dataList.Count; x++)
                {
                    WriteCell(sheet, styles["defData"], (p.y + y, p.x + x), dataList[x]);
                    sheet.AutoSizeColumn(p.x + x, true);
                }
            }

            return true;
        }

        /// <summary>
        /// Hstシートのデータ埋めと書式あてこみメソッド
        /// </summary>
        /// <param name="book">ExcelBookオブジェクト</param>
        /// <param name="lists">HULFTホスト定義データオブジェクト</param>
        /// <returns></returns>
        public bool UpdateHstBook(IWorkbook book, List<HulftHstDef> lists)
        {
            var sheet = book.GetSheet(ConstHulft.SHEETNAME_HST);

            // セルに充てるスタイルの組み立て
            Dictionary<String, ICellStyle> styles = MyCreateStyles.CreateStyles(book);

            // 左上にシート名を
            WriteCell(sheet, styles["indexLabel"], (0, 0), ConstHulft.SHEETNAME_HST);

            // データヘッダーの組み立て
            var header = new HulftHstDef("Header");
            //var headerArray = header.getValueArray();
            var headerList = header.GetListValues();

            // データヘッダーブロックの書き出し
            (int y, int x) p = (2, 1);
            headerList.Insert(0, "No.");
            for (int x = 0; x < headerList.Count; x++)
            {
                WriteCell(sheet, styles["indexLabel"], (p.y, p.x + x), headerList[x]);
            }
            sheet.SetAutoFilter(new CellRangeAddress(p.y, p.y, p.x, p.x + headerList.Count - 1));

            // データブロックの書き出し
            p = (3, 1);
            for (int y = 0; y < lists.Count; y++)
            {
                var dataList = lists[y].GetListValues();
                dataList.Insert(0, (y + 1).ToString());
                for (int x = 0; x < dataList.Count; x++)
                {
                    WriteCell(sheet, styles["defData"], (p.y + y, p.x + x), dataList[x]);
                    sheet.AutoSizeColumn(p.x + x, true);
                }
            }

            return true;
        }

        /// <summary>
        /// TGrpシートのデータ埋めと書式あてこみメソッド
        /// </summary>
        /// <param name="book">ExcelBookオブジェクト</param>
        /// <param name="lists">HULFT転送グループ定義データオブジェクト</param>
        /// <returns></returns>
        public bool UpdateTGrpBook(IWorkbook book, List<HulftTGrpDef> lists)
        {
            var sheet = book.GetSheet(ConstHulft.SHEETNAME_GRP);

            // セルに充てるスタイルの組み立て
            Dictionary<String, ICellStyle> styles = MyCreateStyles.CreateStyles(book);

            // 左上にシート名を
            WriteCell(sheet, styles["indexLabel"], (0, 0), ConstHulft.SHEETNAME_GRP);

            // データヘッダーの組み立て
            var header = new HulftTGrpDef("Header");
            //var headerArray = header.getValueArray();
            var headerList = header.GetListValues();

            // データヘッダーブロックの書き出し
            (int y, int x) p = (2, 1);
            headerList.Insert(0, "No.");
            for (int x = 0; x < headerList.Count; x++)
            {
                WriteCell(sheet, styles["indexLabel"], (p.y, p.x + x), headerList[x]);
            }
            sheet.SetAutoFilter(new CellRangeAddress(p.y, p.y, p.x, p.x + headerList.Count - 1));

            // データブロックの書き出し
            p = (3, 1);
            for (int y = 0; y < lists.Count; y++)
            {
                //var dataList = lists[y].getListValues();
                var dataList = lists[y].GetListListValues();
                dataList.Insert(0, (y + 1).ToString());
                for (int x = 0; x < dataList.Count; x++)
                {
                    WriteCell(sheet, styles["defData"], (p.y + y, p.x + x), dataList[x]);
                    sheet.AutoSizeColumn(p.x + x, true);
                }
            }

            return true;
        }

        /// <summary>
        /// セルに書き込むメッソド
        /// </summary>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="style">セルスタイル</param>
        /// <param name="s">座標</param>
        /// <param name="value">文字列の値</param>
        public static void WriteCell(ISheet sheet, ICellStyle style, (int y, int x) s, string value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.SetCellType(CellType.String);
            cell.SetCellValue(value);
            cell.CellStyle = style;
        }

        /// <summary>
        /// セルに書き込むメッソド
        /// </summary>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="style">セルスタイル</param>
        /// <param name="s">座標</param>
        /// <param name="value">文字列のList</param>
        public static void WriteCell(ISheet sheet, ICellStyle style, (int y, int x) s, List<string> value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.SetCellType(CellType.String);
            cell.SetCellValue(string.Join(",", value));
            cell.CellStyle = style;
        }
    }
}
