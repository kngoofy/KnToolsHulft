using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using KnToolsHulft.Data;

//using HtmlAgilityPack;

namespace KnToolsHulft
{
    class Program
    {
        /// <summary>
        /// コマンドラインから実行する場合のメインメソッド
        /// </summary>
        /// <param name="args">コマンドラインからの引数 オプションパラメータあり</param>
        /// <remarks>
        ///  HULFT定義の各フラットファイルから、ExcelBookを生成するツール
        ///  この下のMainはコマンドラインで実行するを想定
        /// </remarks>
        static void Main(string[] args)
        {

            // コマンドラインのオプションパラメータの解釈
            args = args.Concat(new string[] { "" }).ToArray(); // オプションのみと　そもそも入っていないの識別
            var options = new string[] { "-snd", "-rcv", "-tgrp", "-hst", "-job", "-o", "-h" };
            var target = options.ToDictionary(p => p.Substring(1), p => args.SkipWhile(a => a != p).Skip(1).FirstOrDefault());

            //オプションで生成HulftBook名指定している場合と指定していない場合
            var OutPutBookName = "NewHulftBook.xlsx";
            if (target["o"] != null)
            {
                OutPutBookName = target["o"];
            }

            // usage 表示
            if (target["h"] != null || args.Length < 2)
            {
                Console.WriteLine("Help:");
                Console.WriteLine(" -snd  配信定義ファイル");
                Console.WriteLine(" -rcv  集信定義ファイル");
                Console.WriteLine(" -tgrp 転送グループ定義ファイル");
                Console.WriteLine(" -hst  ホスト詳細定義ファイル");
                Console.WriteLine(" -job  ジョブ定義ファイル");
                Console.WriteLine(" -o    生成されるHulftBookファイル 指定がない場合は[" + OutPutBookName + "]");
                Console.WriteLine(" -h    このヘルプ");
                Console.WriteLine(" 引数がない場合もこのヘルプが表示されます。[" + args.Length + "]");
                
                return;
            }

            //まずテンプレートExcelBookとして生成する。
            var makeSheet = new CreateNewTemplateBook(OutPutBookName);

            //下記の処理で、生成したテンプレートExcelBookにシートにデータを積み込み、書式を付ける。

            //(1) Sndシート[snd] 中身肉付け オプションでファイルが指定されていたら
            if (target["snd"] != null && File.Exists(target["snd"]))
            {
                List<HulftSndDef> hulftSndDatas = BuildHulftSndDef.StreamBuildHulftSndDef(target["snd"]);
                var updateBookSndSheet = new UpdateBook(OutPutBookName, hulftSndDatas);
            }

            //(2) Rcvシート[rcv] 中身肉付け オプションでファイルが指定されていたら
            if (target["rcv"] != null && File.Exists(target["rcv"]))
            {
                List<HulftRcvDef> hulftRcvDatas = BuildHulftRcvDef.StreamBuildHulftRcvDef(target["rcv"]);
                var updateBookRcvSheet = new UpdateBook(OutPutBookName, hulftRcvDatas);
            }

            //(3) Hstシート[Host] 中身肉付け オプションでファイルが指定されていたら
            if (target["hst"] != null && File.Exists(target["hst"]))
            {
                List<HulftHstDef> hulftHstDatas = BuildHulftHstDef.StreamBuildHulftHstDef(target["hst"]);
                var updateBookHstSheet = new UpdateBook(OutPutBookName, hulftHstDatas);
            }

            //(4) TGrpシート[Group] 中身肉付け オプションでファイルが指定されていたら
            if (target["tgrp"] != null && File.Exists(target["snd"]))
            {
                List<HulftTGrpDef> hulftTGrpDatas = BuildHulftTGrpDef.StreamBuildHulftTGrpDef(target["tgrp"]);
                var updateBookTGrpSheet = new UpdateBook(OutPutBookName, hulftTGrpDatas);
            }

            //(5) Jobシート[Job] 中身肉付け オプションでファイルが指定されていたら
            if (target["job"] != null && File.Exists(target["snd"]))
            {
                List<HulftJobDef> hulftJobDatas = BuildHulftJobDef.StreamBuildHulftJobDef(target["job"]);
                var updateBookJobSheet = new UpdateBook(OutPutBookName, hulftJobDatas);
            }

        }

    }
}
