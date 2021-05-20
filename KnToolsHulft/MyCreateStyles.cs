﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace KnToolsHulft
{
     class MyCreateStyles
    {
        public static Dictionary<String, ICellStyle> createStyles(IWorkbook wb)
        {
            //
            Dictionary<String, ICellStyle> styles = new Dictionary<String, ICellStyle>();

            short borderColor = IndexedColors.Grey50Percent.Index;
            IDataFormat df = wb.CreateDataFormat();

            ICellStyle style;
     
            IFont headerFont = wb.CreateFont();
            headerFont.IsBold = true;

            // index sheet [title]
            IFont topleftFont = wb.CreateFont();
            topleftFont.FontHeightInPoints = ((short)14);
            topleftFont.IsBold = true;
            topleftFont.Color = (IndexedColors.White.Index);
            //style = wb.CreateCellStyle();
            style = CreateBorderedStyle(wb);
            style.Alignment = (HorizontalAlignment.Left);
            style.VerticalAlignment = VerticalAlignment.Center;
            style.FillForegroundColor = (IndexedColors.DarkBlue.Index);
            style.FillPattern = (FillPattern.SolidForeground);
            style.SetFont(topleftFont);
            styles.Add("topleft", style);

            // index sheet [title]
            IFont indexTitleFont = wb.CreateFont();
            indexTitleFont.FontHeightInPoints = ((short)48);
            indexTitleFont.Color = (IndexedColors.DarkBlue.Index);
            //style = wb.CreateCellStyle();
            style = CreateBorderedStyle(wb);
            style.Alignment = (HorizontalAlignment.Center);
            style.VerticalAlignment = VerticalAlignment.Center;
            style.SetFont(indexTitleFont);
            styles.Add("inexTitle", style);

            //
            IFont indexBoxFont = wb.CreateFont();
            indexBoxFont.FontHeightInPoints = ((short)12);
            //indexBoxFont.Color = (IndexedColors.White.Index);
            indexBoxFont.IsBold = true;
            //style = wb.CreateCellStyle();
            style = CreateBorderedStyle(wb);
            style.Alignment = (HorizontalAlignment.Right);
            style.VerticalAlignment = (VerticalAlignment.Center);
            //style.FillForegroundColor = (IndexedColors.DarkBlue.Index);
            //style.FillPattern = (FillPattern.SolidForeground);
            style.SetFont(indexBoxFont);
            styles.Add("indexBox", style);

            //
            IFont indexLavelFont = wb.CreateFont();
            indexLavelFont.FontHeightInPoints = ((short)12);
            indexLavelFont.Color = (IndexedColors.White.Index);
            indexLavelFont.IsBold = true;
            style = wb.CreateCellStyle();
            style.Alignment = (HorizontalAlignment.Center);
            style.VerticalAlignment = (VerticalAlignment.Center);
            style.FillForegroundColor = (IndexedColors.DarkBlue.Index);
            style.FillPattern = (FillPattern.SolidForeground);
            style.SetFont(indexLavelFont);
            styles.Add("indexLabel", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.FillForegroundColor = (IndexedColors.LightCornflowerBlue.Index);
            style.FillPattern = FillPattern.SolidForeground;
            style.SetFont(headerFont);
            styles.Add("sheet_label", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            //style.FillForegroundColor = (IndexedColors.LightCornflowerBlue.Index);
            //style.FillPattern = FillPattern.SolidForeground;
            style.SetFont(headerFont);
            styles.Add("header", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            //style.FillForegroundColor = (IndexedColors.LightCornflowerBlue.Index);
            //style.FillPattern = FillPattern.SolidForeground;
            style.SetFont(headerFont);
            styles.Add("defData", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.FillForegroundColor = (IndexedColors.LightCornflowerBlue.Index);
            style.FillPattern = FillPattern.SolidForeground;
            style.SetFont(headerFont);
            style.DataFormat = (df.GetFormat("d-mmm"));
            styles.Add("header_date", style);

            IFont font1 = wb.CreateFont();
            font1.IsBold = true;
            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font1);
            styles.Add("cell_b", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font1);
            styles.Add("cell_b_centered", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font1);
            style.DataFormat = (df.GetFormat("d-mmm"));
            styles.Add("cell_b_date", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font1);
            style.FillForegroundColor = (IndexedColors.Grey25Percent.Index);
            style.FillPattern = FillPattern.SolidForeground;
            style.DataFormat = (df.GetFormat("d-mmm"));
            styles.Add("cell_g", style);

            IFont font2 = wb.CreateFont();
            font2.Color = (IndexedColors.Blue.Index);
            font2.IsBold = true;
            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font2);
            styles.Add("cell_bb", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font1);
            style.FillForegroundColor = (IndexedColors.Grey25Percent.Index);
            style.FillPattern = FillPattern.SolidForeground;
            style.DataFormat = (df.GetFormat("d-mmm"));
            styles.Add("cell_bg", style);

            IFont font3 = wb.CreateFont();
            font3.FontHeightInPoints = ((short)14);
            font3.Color = (IndexedColors.DarkBlue.Index);
            font3.IsBold = true;
            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font3);
            style.WrapText = (true);
            styles.Add("cell_h", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.WrapText = (true);
            styles.Add("cell_normal", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.WrapText = (true);
            styles.Add("cell_normal_centered", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.WrapText = (true);
            style.DataFormat = (df.GetFormat("d-mmm"));
            styles.Add("cell_normal_date", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.Indention = ((short)1);
            style.WrapText = (true);
            styles.Add("cell_indented", style);

            style = CreateBorderedStyle(wb);
            style.FillForegroundColor = (IndexedColors.Blue.Index);
            style.FillPattern = FillPattern.SolidForeground;
            styles.Add("cell_blue", style);

            return styles;
        }
        private static ICellStyle CreateBorderedStyle(IWorkbook wb)
        {
            ICellStyle style = wb.CreateCellStyle();
            style.BorderRight = BorderStyle.Thin;
            style.RightBorderColor = (IndexedColors.Black.Index);
            style.BorderBottom = BorderStyle.Thin;
            style.BottomBorderColor = (IndexedColors.Black.Index);
            style.BorderLeft = BorderStyle.Thin;
            style.LeftBorderColor = (IndexedColors.Black.Index);
            style.BorderTop = BorderStyle.Thin;
            style.TopBorderColor = (IndexedColors.Black.Index);
            return style;
        }

    }
}