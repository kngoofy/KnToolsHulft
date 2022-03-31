using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.Net;

using AngleSharp.Html.Dom;
using System.Xml.Linq;

namespace KnToolsHulft
{
    class GetWebPage
    {
        private static readonly HttpClient client=null;
        private readonly HttpClient _httpClient = new HttpClient();

        /*
        public string GetWebData()
        {
            var text =  await GetPageAsync(@"http://www.bing.com/");

            var xmldoc = XDocument.Parse(text);
            var rev = xmldoc.Root.Descendants("rev").FirstOrDefault();
            return WebUtility.HtmlDecode(rev?.Value);
            //return text;
        }

        public async Task<string> GetWebDataAsync()
        {
            var text = await GetPageAsync(@"http://www.bing.com/");

            //return text;

        }
        */

        public async Task<string> GetPageAsync(string urlstr)
        {
            var str = await _httpClient.GetStringAsync(urlstr);
            return str;
        }
        public static async Task GetDownloadFileAsync(/*string uri*/)
        {
            try
            {
                // まずは、スクレイピングするデータを取得します
                var response = await client.GetAsync(@"https://developer.microsoft.com/ja-jp/");
                var sorce = await response.Content.ReadAsStringAsync();

                // パースします
                var doc = default(IHtmlDocument);
                var parser = new HtmlParser();
                doc = await parser.ParseDocumentAsync(sorce);    // ここが変わっています!!

                // 取得したいURLデータを探します
                // 今回取得したいデータは、同一のselectorの最後のデータでしたので、
                // .Last()で取得しています
                // .Select()とかで取得したほうがいいこともあると思います
                var url = doc.QuerySelectorAll(" < 取得したい条件>").Last().GetAttribute("href");

                // ファイルをダウンロードします
                // 今回取得したURLはhttps://xxx から始まるURLなのでそのまま使用しています
                //  WebClient webClient = new WebClient();
                //  webClient.DownloadFile(url, < 保存するファイル名（絶対パスで）>);

                // ZIPファイルを解凍します
                // ZipFile.ExtractToDirectory(< 保存するファイル名（絶対パスで）>, < 解凍先フォルダー名 >);
            }
            catch (Exception ex)
            {
                // エラー処理
                Console.WriteLine(ex);
            }
        }


        public static async Task<string> GetWebPageAsync(Uri uri)
        {

            using (HttpClient client = new HttpClient())
            {
                // ユーザーエージェント文字列をセット（オプション）
                client.DefaultRequestHeaders.Add(
                    "User-Agent",
                    "Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko");

                // 受け入れ言語をセット（オプション）
                client.DefaultRequestHeaders.Add("Accept-Language", "ja-JP");

                // タイムアウトをセット（オプション）
                client.Timeout = TimeSpan.FromSeconds(10.0);

                try
                {
                    // Webページを取得するのは、事実上この1行だけ
                    return await client.GetStringAsync(uri);
                }
                catch (HttpRequestException e)
                {
                    // 404エラーや、名前解決失敗など
                    Console.WriteLine("\n例外発生!");
                    // InnerExceptionも含めて、再帰的に例外メッセージを表示する
                    Exception ex = e;
                    while (ex != null)
                    {
                        Console.WriteLine("例外メッセージ: {0} ", ex.Message);
                        ex = ex.InnerException;
                    }
                }
                catch (TaskCanceledException e)
                {
                    // タスクがキャンセルされたとき（一般的にタイムアウト）
                    Console.WriteLine("\nタイムアウト!");
                    Console.WriteLine("例外メッセージ: {0} ", e.Message);
                }
                return null;
            }

        }

    }
}
