using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KnToolsHulft.Data;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using AngleSharp;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;
using System.Net;
using System.Xml.Linq;

using HtmlAgilityPack;

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
            var options = new string[] { "-snd", "-rcv", "-hst", "-tgrp", "-o", "-h" };
            var target = options.ToDictionary(p => p.Substring(1), p => args.SkipWhile(a => a != p).Skip(1).FirstOrDefault());

            //Hulft Excelシートのテンプレートをまず作成する。オプションで生成Book名指定している場合はそこに
            var OutPutBookName = "NewTemplate.xlsx";
            if (target["o"] != null)
            {
                OutPutBookName = target["o"];
            }

            //まずテンプレートExcelBookとして生成する。
            var makeSheet = new CreateNewTemplateBook(OutPutBookName);
            //return;

            //下記の処理で、生成したテンプレートExcelBookにシートにデータを積み込み、書式を付ける。

            //(1) Sndシート[snd] 中身肉付け オプションでファイルが指定されていたら
            if (target["snd"] != null)
            {
                var hulftSndData = new BuildHulftSndDef();
                List<HulftSndDef> hulftSndDatas = hulftSndData.ReadBuildHulftSndDef(target["snd"]);
                var updateBookSndSheet = new UpdateBook(OutPutBookName, hulftSndDatas);
            }

            //(2) Rcvシート[rcv] 中身肉付け オプションでファイルが指定されていたら
            if (target["rcv"] != null)
            {
                var hulftRcvData = new BuildHulftRcvDef();
                List<HulftRcvDef> hulftRcvDatas = hulftRcvData.ReadBuildHulftRcvDef(target["rcv"]);
                var updateBookRcvSheet = new UpdateBook(OutPutBookName, hulftRcvDatas);
            }

            //(3) Hstシート[Host] 中身肉付け オプションでファイルが指定されていたら
            if (target["hst"] != null)
            {
                var hulftHstData = new BuildHulftHstDef();
                List<HulftHstDef> hulftHstDatas = hulftHstData.ReadBuildHulftHstDef(target["hst"]);
                var updateBookHstSheet = new UpdateBook(OutPutBookName, hulftHstDatas);
            }

            //(4) TGrpシート[Group] 中身肉付け オプションでファイルが指定されていたら
            if (target["tgrp"] != null)
            {
                var hulftTGrpData = new BuildHulftTGrpDef();
                List<HulftTGrpDef> hulftTGrpDatas = hulftTGrpData.ReadBuildHulftTGrpDef(target["tgrp"]);
                var updateBookTGrpSheet = new UpdateBook(OutPutBookName, hulftTGrpDatas);
            }

            return;


            ////var updateSheet = new UpdateBook("sample.xlsx");
            //var updateSheet = new UpdateBook("NewTemplate.xlsx", "hulftdef.xlsx", sndDatas, rcvDatas, tgrpDatas, hstDatas);
            ////var updateSheet = new UpdateBook("NewTemplate.xlsx", "hulftdef.xlsx");
            ////updateSheet.UpdateSndBook("NewTemplate.xlsx", datas);
            ////NewExcelBook("sample.xlsx");



        }


        public void Nop()
        {
            //パラメータなし引数は値がnullでないかでチェック
            //if (result["hoge"] != null) Console.WriteLine("hogeがあります");

            //foreach (var param in target)
            //{
            //    Console.WriteLine(param.Key + "=" + param.Value);
            //}

            //return;


            //            //サンプルとして使用するHTML
            //            var htmlText = @"
            //<html>
            //    <head>
            //        <meta charset = 'UTF-8'/>
            //        <title>AngleSharpの使い方</title>
            //    </head>
            //    <body>
            //        <div id = 'header' name='headerName'>
            //        <h1 id = 'headerTitle'>AngleSharpの使い方</h1>
            //        </div>
            //        <ul id='linkList'>
            //            <li class = 'link'><a href='@'>トレーニング用リンク1</a></li>
            //            <li class = 'link'><a href='@'>トレーニング用リンク2</a></li>

            //       </ul>

            //<pre>
            //#
            //# ID=LOOPBACK1
            //#

            //SNDFILE=LOOPBACK1
            //FILENAME=C:\HULFT\LOOPSND.txt
            //TRANSTYPE=T
            //TRANSPRTY=50
            //INTERVAL=0
            //BLOCKLEN=4096
            //BLOCKCNT=3
            //COMP=N
            //GRPID=LOOPBACK
            //KJCHNGE=S
            //CLEAR=K
            //CODESET=A
            //SHIFTTRANSACT=Y
            //END

            //#
            //# ID=LOOPBACK2
            //#

            //SNDFILE=LOOPBACK2
            //FILENAME=C:\HULFT\LOOPSND2.txt
            //TRANSTYPE=T
            //TRANSPRTY=50
            //INTERVAL=0
            //BLOCKLEN=4096
            //BLOCKCNT=3
            //COMP=N
            //GRPID=LOOPBACK
            //KJCHNGE=S
            //CLEAR=K
            //CODESET=A
            //SHIFTTRANSACT=Y
            //END
            //</pre>
            //     </body>
            //</html>
            //";

            //            string htmlstr = @"
            //<!DOCTYPE html>
            //<html lang=""ja"">
            //  < head >
            //    < meta charset = ""UTF-8"" >

            //     < title > HTML Parser Sample</ title >

            //      </ head >

            //      < body >

            //        < p id = 'id-p' > ID = id - pの文字 </ p >

            //         < p class=""class-p"">class=class-pの文字1</p>
            //    <p class=""class-p"">class=class-pの文字2</p>
            //    <p class=""class-p"">class=class-pの文字3</p>
            //  </body>
            //</html>
            //";

            //            var htmlDoc = new HtmlDocument();
            //            htmlDoc.LoadHtml(htmlText);

            //            HtmlNode n = htmlDoc.DocumentNode.SelectSingleNode("/html/body/pre");
            //            Console.WriteLine(n.InnerText);

            //           // return;

            //            var parser = new HtmlParser();

            //            // HtmlParserクラスのParserメソッドを使用してパースする。
            //            // Parserメソッドの戻り値の型はIHtmlDocument
            //            var doc = parser.ParseDocument(htmlstr);

            //            var idP = doc.GetElementById("id-p");
            //  //          Console.WriteLine("GetElementByIdを使って[id-p]の値取得 : {0}", idP.TextContent);

            //            // aタグの要素を全て取得する。
            //            //var element = htmlDocument.GetElementBy   Id("title");
            //            //Console.WriteLine(element.InnerHtml.ToString());

            //           // var urlElements = htmlDocument.QuerySelectorAll("ul.id");
            //         //   Console.WriteLine(urlElements);
            ////
            ////var str = urlElements.Select(n => n.InnerHtml).ToString();
            //            //Console.WriteLine(str.ToString());
            //            //Console.WriteLine(urlElements.Select(m => m.InnerHtml).ToString());

            //        //    return;


            //            var w = new GetWebPage();


            // //           Task<string> webTask = w.GetPageAsync(@"http://abehiroshi.la.coocan.jp//"); 
            // //           webTask.Wait();
            // //           string result = webTask.Result;  // 結果

            // //           var xmldoc = XDocument.Parse(result);
            // //           var rev = xmldoc.Root.Descendants("rev").FirstOrDefault();
            //            //reWebUtility.HtmlDecode(rev?.Value);


            //            //\GetWebPage.GetDownloadFileAsync(@"http://dev.windows.com/ja-jp").GetAwaiter().GetResult();

            //            /*
            //            // Uri webUri = new Uri("http://dev.windows.com/ja-jp");
            //            // GetWebPageAsyncメソッドを呼び出す
            //            Task<string> webTask = GetWebPage.GetWebPageAsync(webUri);
            //            webTask.Wait(); // Mainメソッドではawaitできないので、処理が完了するまで待機する
            //            string result = webTask.Result;  // 結果

            //            var doc = default(IHtmlDocument);
            //            var parser = new HtmlParser();
            //            doc = parser.ParseDocumentAsync(result);


            //            if (result != null)
            //            {
            //                // サンプルとして、取得したHTMLデータの<h1>タグ以降を一定長だけ表示
            //                Console.WriteLine("========");
            //                int h1pos = result.IndexOf("<h1", StringComparison.OrdinalIgnoreCase);
            //                if (h1pos < 0)
            //                    h1pos = 0;
            //                const int MaxLength = 720;
            //                int len = result.Length - h1pos;
            //                if (len > MaxLength)
            //                    len = MaxLength;
            //                Console.WriteLine(result.Substring(h1pos, len));
            //                Console.WriteLine("========");
            //            }
            //        */

            //          //  return;

            //string sndFile = @"E:\02.Kazu-Development\01.visualstudio\KnToolsHulft\KnToolsHulft\TestData\hultsnd.txt";
            //if (!System.IO.File.Exists(sndFile))
            //{
            //    return;
            //}
            //string rcvFile = @"E:\02.Kazu-Development\01.visualstudio\KnToolsHulft\KnToolsHulft\TestData\hultrcv.txt";
            //if (!System.IO.File.Exists(rcvFile))
            //{
            //    return;
            //}
            //string hstFile = @"E:\02.Kazu-Development\01.visualstudio\KnToolsHulft\KnToolsHulft\TestData\hulthst.txt";
            //if (!System.IO.File.Exists(hstFile))
            //{
            //    return;
            //}
            //string tgrpFile = @"E:\02.Kazu-Development\01.visualstudio\KnToolsHulft\KnToolsHulft\TestData\hulttgrp.txt";
            //if (!System.IO.File.Exists(tgrpFile))
            //{
            //    return;
            //}

            ////
            //var sndData = new BuildHulftSndDef();
            //List<HulftSndDef> sndDatas = sndData.ReadBuildHulftSndDef(sndFile);

            //var rcvData = new BuildHulftRcvDef();
            //List<HulftRcvDef> rcvDatas = rcvData.ReadBuildHulftRcvDef(rcvFile);

            //var tgrpData = new BuildHulftTGrpDef();
            //List<HulftTGrpDef> tgrpDatas = tgrpData.ReadBuildHulftTGrpDef(tgrpFile);

            //var hstData = new BuildHulftHstDef();
            //List<HulftHstDef> hstDatas = hstData.ReadBuildHulftHstDef(hstFile);

        }
    }
}
