using System;//
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPOI.SS.UserModel;

using NPOI.XSSF.UserModel;
using KnToolsHulft.Data;

namespace KnToolsHulft
{
    public class UpdateBook
    {

        //コンストラクタ
        public UpdateBook(string templateFile, string outputFile
            //, List<HulftSndDef> sndlLsts,
            //List<HulftRcvDef> rcvLists,
            //List<HulftTGrpDef> tgrpLists,
            //List<HulftHstDef> hstLists
            )
        {

            string sndFile = @"E:\02.Kazu-Development\visualstudio\KnToolsHulft\KnToolsHulft\TestData\hultsnd.txt";
            if (!System.IO.File.Exists(sndFile))
            {
                return;
            }
            string rcvFile = @"E:\02.Kazu-Development\visualstudio\KnToolsHulft\KnToolsHulft\TestData\hultrcv.txt";
            if (!System.IO.File.Exists(rcvFile))
            {
                return;
            }
            string hstFile = @"E:\02.Kazu-Development\visualstudio\KnToolsHulft\KnToolsHulft\TestData\hulthst.txt";
            if (!System.IO.File.Exists(hstFile))
            {
                return;
            }
            string tgrpFile = @"E:\02.Kazu-Development\visualstudio\KnToolsHulft\KnToolsHulft\TestData\hulttgrp.txt";
            if (!System.IO.File.Exists(tgrpFile))
            {
                return;
            }

            //
            var sndData = new BuildHulftSndDef();
            List<HulftSndDef> sndDatas = sndData.ReadBuildHulftSndDef(sndFile);

            var rcvData = new BuildHulftRcvDef();
            List<HulftRcvDef> rcvDatas = rcvData.ReadBuildHulftRcvDef(rcvFile);

            var tgrpData = new BuildHulftTGrpDef();
            List<HulftTGrpDef> tgrpDatas = tgrpData.ReadBuildHulftTGrpDef(tgrpFile);

            var hstData = new BuildHulftHstDef();
            List<HulftHstDef> hstDatas = hstData.ReadBuildHulftHstDef(hstFile);

            // Bookの中身を埋める
            try
            {
                var book = WorkbookFactory.Create(templateFile);


                // セルに充てるスタイルの組み立て
                //Dictionary<String, ICellStyle> styles = MyCreateStyles.createStyles(book);
                // 各シートを埋める
                UpdateSndBook(book, sndDatas);
                UpdateRcvBook(book, rcvDatas);
                UpdateHstBook(book, hstDatas);
                UpdateTGrpBook(book, tgrpDatas);

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

        public bool UpdateSndBook(IWorkbook book, List<HulftSndDef> lists)
        {
            var sheet = book.GetSheet(ConstHulft.SHEETNAME_SND);

            // セルに充てるスタイルの組み立て
            Dictionary<String, ICellStyle> styles = MyCreateStyles.createStyles(book);

            // 左上にシート名を
            WriteCell(sheet, styles["indexLabel"], (0, 0), ConstHulft.SHEETNAME_SND);

            // データヘッダーの組み立て
            var header = new HulftSndDef("Header");
            //var headerArray = header.getValueArray();
            var headerList = header.getListValues();

            // データヘッダーブロックの書き出し
            (int y, int x) p = (2, 1);
            headerList.Insert(0, "No.");
            for (int x = 0; x < headerList.Count; x++)
            {
                WriteCell(sheet, styles["indexLabel"], (p.y, p.x + x), headerList[x]);
            }

            // データブロックの書き出し
            p = (3, 1);
            for (int y = 0; y < lists.Count; y++)
            {
                var dataList = lists[y].getListValues();
                dataList.Insert(0, (y + 1).ToString());
                for (int x = 0; x < dataList.Count; x++)
                {
                    WriteCell(sheet, styles["defData"], (p.y + y, p.x + x), dataList[x]);
                    sheet.AutoSizeColumn(p.x + x, true);
                }
            }

            return true;
        }

        public bool UpdateRcvBook(IWorkbook book, List<HulftRcvDef> lists)
        {
            var sheet = book.GetSheet(ConstHulft.SHEETNAME_RCV);

            // セルに充てるスタイルの組み立て
            Dictionary<String, ICellStyle> styles = MyCreateStyles.createStyles(book);

            // 左上にシート名を
            WriteCell(sheet, styles["indexLabel"], (0, 0), ConstHulft.SHEETNAME_RCV);

            // データヘッダーの組み立て
            var header = new HulftRcvDef("Header");
            //var headerArray = header.getValueArray();
            var headerList = header.getListValues();

            // データヘッダーブロックの書き出し
            (int y, int x) p = (2, 1);
            headerList.Insert(0, "No.");
            for (int x = 0; x < headerList.Count; x++)
            {
                WriteCell(sheet, styles["indexLabel"], (p.y, p.x + x), headerList[x]);
            }

            // データブロックの書き出し
            p = (3, 1);
            for (int y = 0; y < lists.Count; y++)
            {
                var dataList = lists[y].getListValues();
                dataList.Insert(0, (y + 1).ToString());
                for (int x = 0; x < dataList.Count; x++)
                {
                    WriteCell(sheet, styles["defData"], (p.y + y, p.x + x), dataList[x]);
                    sheet.AutoSizeColumn(p.x + x, true);
                }
            }

            return true;
        }

        public bool UpdateHstBook(IWorkbook book, List<HulftHstDef> lists)
        {
            var sheet = book.GetSheet(ConstHulft.SHEETNAME_HST);

            // セルに充てるスタイルの組み立て
            Dictionary<String, ICellStyle> styles = MyCreateStyles.createStyles(book);

            // 左上にシート名を
            WriteCell(sheet, styles["indexLabel"], (0, 0), ConstHulft.SHEETNAME_RCV);

            // データヘッダーの組み立て
            var header = new HulftHstDef("Header");
            //var headerArray = header.getValueArray();
            var headerList = header.getListValues();

            // データヘッダーブロックの書き出し
            (int y, int x) p = (2, 1);
            headerList.Insert(0, "No.");
            for (int x = 0; x < headerList.Count; x++)
            {
                WriteCell(sheet, styles["indexLabel"], (p.y, p.x + x), headerList[x]);
            }

            // データブロックの書き出し
            p = (3, 1);
            for (int y = 0; y < lists.Count; y++)
            {
                var dataList = lists[y].getListValues();
                dataList.Insert(0, (y + 1).ToString());
                for (int x = 0; x < dataList.Count; x++)
                {
                    WriteCell(sheet, styles["defData"], (p.y + y, p.x + x), dataList[x]);
                    sheet.AutoSizeColumn(p.x + x, true);
                }
            }

            return true;
        }

        public bool UpdateTGrpBook(IWorkbook book, List<HulftTGrpDef> lists)
        {
            var sheet = book.GetSheet(ConstHulft.SHEETNAME_GRP);

            // セルに充てるスタイルの組み立て
            Dictionary<String, ICellStyle> styles = MyCreateStyles.createStyles(book);

            // 左上にシート名を
            WriteCell(sheet, styles["indexLabel"], (0, 0), ConstHulft.SHEETNAME_RCV);

            // データヘッダーの組み立て
            var header = new HulftTGrpDef("Header");
            //var headerArray = header.getValueArray();
            var headerList = header.getListValues();

            // データヘッダーブロックの書き出し
            (int y, int x) p = (2, 1);
            headerList.Insert(0, "No.");
            for (int x = 0; x < headerList.Count; x++)
            {
                WriteCell(sheet, styles["indexLabel"], (p.y, p.x + x), headerList[x]);
            }

            // データブロックの書き出し
            p = (3, 1);
            for (int y = 0; y < lists.Count; y++)
            {
                //var dataList = lists[y].getListValues();
                var dataList = lists[y].getListListValues();
                dataList.Insert(0, (y + 1).ToString());
                for (int x = 0; x < dataList.Count; x++)
                {
                    WriteCell(sheet, styles["defData"], (p.y + y, p.x + x), dataList[x]);
                    sheet.AutoSizeColumn(p.x + x, true);
                }
            }

            return true;
        }


        public static void WriteCell(ISheet sheet, ICellStyle style, (int y, int x) s, string value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.SetCellType(CellType.String);
            cell.SetCellValue(value);
            cell.CellStyle = style;
        }
        public static void WriteCell(ISheet sheet, ICellStyle style, (int y, int x) s, List<string> value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.SetCellType(CellType.String);
            cell.SetCellValue(string.Join(",",value));
            cell.CellStyle = style;
        }
    }
}
