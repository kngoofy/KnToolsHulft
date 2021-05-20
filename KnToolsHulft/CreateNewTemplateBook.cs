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
    class CreateNewTemplateBook
    {

        //コンストラクタ
        public CreateNewTemplateBook(string sheetName)
        {
            this.NewExcelBook(sheetName);
        }

        public bool NewExcelBook(string bookName)
        {
            try
            {
                //Hulft定義Bookのテンプレートを新規に作成
                IWorkbook book = new XSSFWorkbook();

                Dictionary<String, ICellStyle> styles = MyCreateStyles.createStyles(book);

                //定型シートを作成
                book.CreateSheet(ConstHulft.SHEETNAME_IDX);
                book.CreateSheet(ConstHulft.SHEETNAME_SND);
                book.CreateSheet(ConstHulft.SHEETNAME_RCV);
                book.CreateSheet(ConstHulft.SHEETNAME_GRP);
                book.CreateSheet(ConstHulft.SHEETNAME_HST);

                var sheetIdx = book.GetSheet(ConstHulft.SHEETNAME_IDX);
                var sheetSnd = book.GetSheet(ConstHulft.SHEETNAME_SND);
                var sheetRcv = book.GetSheet(ConstHulft.SHEETNAME_RCV);
                var sheetGrp = book.GetSheet(ConstHulft.SHEETNAME_GRP);
                var sheetHst = book.GetSheet(ConstHulft.SHEETNAME_HST);
                
                //定型シートの中身を整える
                FormatSheetIdx(book, styles, sheetIdx);
                FormatSheetSnd(styles, sheetSnd);
                FormatSheetRcv(styles, sheetRcv);
                FormatSheetGrp(styles, sheetGrp);
                FormatSheetHst(styles, sheetHst);

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

        public bool FormatSheetIdx(IWorkbook book, Dictionary<String, ICellStyle> styles, ISheet sheet)
        {

            //メモリ線を非表示
            sheet.DisplayGridlines = false;

            //TopLeft シートタイトル埋め込み
            WriteCell(sheet, styles["topleft"], (0, 0), "HULFT定義BookのIndex");
            
            //Sheetのインデックス埋め込み
            var titles = new List<(int no, string name)> {
                  (1,ConstHulft.SHEETNAME_SND)
                , (2,ConstHulft.SHEETNAME_RCV)
                , (3,ConstHulft.SHEETNAME_GRP)
                , (4,ConstHulft.SHEETNAME_HST)
            };
            
            //
            (int y, int x) p = (1, 1);
            
            foreach (var t in titles)
            {
                //style.BorderLeft = BorderStyle.None;
                WriteCell(sheet, styles["indexBox"], (p.y + t.no, p.x), t.no.ToString());   //番号埋め

                //style.BorderLeft = BorderStyle.Dotted;
                var link = new XSSFHyperlink(HyperlinkType.Document);
                link.Address = t.name + "!A1";
                WriteCell(sheet, styles["indexLabel"], link, (p.y + t.no, p.x + 1), t.name);        //シート名埋め
            }

            return true;
        }

        //セル設定(文字列用)
        public static void WriteCell(ISheet sheet, ICellStyle style, (int y, int x) s, string value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.SetCellValue(value);
            cell.CellStyle = style;
        }

        //
        public static void WriteCell(ISheet sheet, ICellStyle style, IHyperlink link, (int y, int x) s, string value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.Hyperlink = link;
            cell.SetCellValue(value);
            cell.CellStyle = style;
        }

        public bool FormatSheetSnd(Dictionary<String, ICellStyle> styles, ISheet sheet)
        {
            sheet.DisplayGridlines = false;
            WriteCell(sheet, styles["topleft"], (0, 0), ConstHulft.SHEETNAME_SND);
            return true;
        }
        public bool FormatSheetRcv(Dictionary<String, ICellStyle> styles, ISheet sheet)
        {
            sheet.DisplayGridlines = false;
            WriteCell(sheet, styles["topleft"], (0, 0), ConstHulft.SHEETNAME_RCV);
            return true;
        }
        public bool FormatSheetHst(Dictionary<String, ICellStyle> styles, ISheet sheet)
        {
            sheet.DisplayGridlines = false;
            WriteCell(sheet, styles["topleft"], (0, 0), ConstHulft.SHEETNAME_HST);
            return true;
        }
        public bool FormatSheetGrp(Dictionary<String, ICellStyle> styles, ISheet sheet)
        {
            sheet.DisplayGridlines = false;
            WriteCell(sheet, styles["topleft"], (0, 0), ConstHulft.SHEETNAME_GRP);
            return true;
        }

        
        //書式変更
        public static void WriteStyle(ISheet sheet, int columnIndex, int rowIndex, ICellStyle style)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.CellStyle = style;
        }

        //指定したセルの値を取得する
        public static void getCellValue(ISheet sheet, int idxColumn, int idxRow)
        {
            var row = sheet.GetRow(idxRow) ?? sheet.CreateRow(idxRow); //指定した行を取得できない時はエラーとならないよう新規作成している
            var cell = row.GetCell(idxColumn) ?? row.CreateCell(idxColumn); //一行上の処理の列版
            string value;

            switch (cell.CellType)
            {
                case CellType.String:
                    value = cell.StringCellValue;
                    break;
                case CellType.Numeric:
                    value = cell.NumericCellValue.ToString();
                    break;
                case CellType.Boolean:
                    value = cell.BooleanCellValue.ToString();
                    break;
                default:
                    value = "Value無し";
                    break;
            }
            //Console.WriteLine("value: " + value);
        }

    }
}
