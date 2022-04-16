using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using KnToolsHulft.Data;
using System.Diagnostics;

namespace KnToolsHulft
{
    /// <summary>
    /// HULFT配信定義を扱うクラス
    /// </summary>

    public static class BuildHulftSndDef
    {
        /// <summary>
        /// HULFT配信定義のフラットテキストファイルを読んで、HulftSndDefクラスのListを生成して返す。
        /// </summary> 
        /// <param name="file">HULFT配信定義ファイル名</param>
        /// <returns>HulftSndDefクラスのList</returns>

        public static List<HulftSndDef> StreamBuildHulftSndDef(string filename)
        {
            string htmlText = File.ReadAllText(filename);
            return StringBuildHulftSndDef(htmlText);
        }

        public static List<HulftSndDef> StringBuildHulftSndDef(string HtmlText)
        {
            string fileContent = "";

            //HULFT配信定義のクラスと積み上げたList型
            List<HulftSndDef> hulftSndDefs = new List<HulftSndDef>();
            //Dictionary<string, HulftSndDef> dict = new Dictionary<string,HulftSndDef>();
            HulftSndDef hulftdef = new HulftSndDef();

            using (StringReader sr = new StringReader(HtmlText))
            {
                while ((fileContent = sr.ReadLine()) != null)
                {
                    //Debug.WriteLine(fileContent);
                    fileContent = fileContent.Trim();
                    if (fileContent == "") continue;
                    if (fileContent == "#") continue;

                    string[] array = fileContent.Split('=');
                    switch (array[0])
                    {
                        case "# ID":
                            hulftdef.ClearRest();
                            hulftdef.Id = array[1];
                            break;
                        case "SNDFILE":
                            hulftdef.SndFile = array[1];
                            break;
                        case "FILENAME":
                            hulftdef.FileName = array[1];
                            break;
                        case "DBID":
                            hulftdef.DbId = array[1];
                            break;
                        case "TRANSTYPE":
                            hulftdef.TransType = array[1];
                            break;
                        case "TRANSPRTY":
                            hulftdef.Transprty = array[1];
                            break;
                        case "INTERVAL":
                            hulftdef.Interval = array[1];
                            break;
                        case "BLOCKLEN":
                            hulftdef.BlockLen = array[1];
                            break;
                        case "BLOCKCNT":
                            hulftdef.BlockCnt = array[1];
                            break;
                        case "COMP":
                            hulftdef.Comp = array[1];
                            break;
                        case "JOBID":
                            hulftdef.JobId = array[1];
                            break;
                        case "COMMENT":
                            hulftdef.Comment = string.Join("=", array.Skip(1).Take(2));
                            break;
                        case "GRPID":
                            hulftdef.GrpId = array[1];
                            break;
                        case "FMTID":
                            hulftdef.FmtId = array[1];
                            break;
                        case "EJOBID":
                            hulftdef.EjobId = array[1];
                            break;
                        case "KJCHNGE":
                            hulftdef.KjChnge = array[1];
                            break;
                        case "CLEAR":
                            hulftdef.Clear = array[1];
                            break;
                        case "PASSWORD":
                            hulftdef.Password = array[1];
                            break;
                        case "CODESET":
                            hulftdef.CodeSet = array[1];
                            break;
                        case "COMPSIZE":
                            hulftdef.CompSize = array[1];
                            break;
                        case "SHIFTTRANSACT":
                            hulftdef.Shifttransact = array[1];
                            break;
                        case "PREJOBID":
                            hulftdef.PrejobId = array[1];
                            break;

                        case "END":
                            hulftSndDefs.Add(hulftdef.Clone());
                            //dict[hulftdef.Id]= hulftdef.Clone();
                            break;
                    }
                }
            }

            return hulftSndDefs;
        }

        ///// <summary>
        ///// HULFT配信定義のフラットテキストファイルを読んで、HulftSndDefクラスのListを生成して返す。
        ///// </summary> 
        ///// <param name="file">HULFT配信定義ファイル名</param>
        ///// <returns>HulftSndDefクラスのList</returns>

        //public static List<HulftSndDef> ReadBuildHulftSndDef(string filePathName)
        //{
        //    string fileContent = "";

        //    //HULFT配信定義のクラスと積み上げたList型
        //    List<HulftSndDef> hulftSndDefs = new List<HulftSndDef>();
        //    HulftSndDef hulftdef = new HulftSndDef();

        //    using (var sr = new StreamReader(filePathName, Encoding.Default))
        //    {
        //        while ((fileContent = sr.ReadLine()) != null)
        //        {
        //            fileContent.Trim();
        //            if (fileContent == "") continue;
        //            if (fileContent == "#") continue;

        //            //fileContent.Contains("# ID=");
        //            string[] array = fileContent.Split('=');
        //            //Console.WriteLine(string.Join(" ", array));
        //            switch (array[0])
        //            {
        //                case "# ID":
        //                    hulftdef.ClearRest();
        //                    hulftdef.Id = array[1];
        //                    break;
        //                case "SNDFILE":
        //                    hulftdef.SndFile = array[1];
        //                    break;
        //                case "FILENAME":
        //                    hulftdef.FileName = array[1];
        //                    break;
        //                case "TRANSTYPE":
        //                    hulftdef.TransType = array[1];
        //                    break;
        //                case "INTERVAL":
        //                    hulftdef.Interval = array[1];
        //                    break;
        //                case "BLOCKLEN":
        //                    hulftdef.BlockLen = array[1];
        //                    break;
        //                case "BLOCKCNT":
        //                    hulftdef.BlockCnt = array[1];
        //                    break;
        //                case "COMP":
        //                    hulftdef.Comp = array[1];
        //                    break;
        //                case "GRPID":
        //                    hulftdef.GrpId = array[1];
        //                    break;
        //                case "KJCHNGE":
        //                    hulftdef.KjChnge = array[1];
        //                    break;
        //                case "CLEAR":
        //                    hulftdef.Clear = array[1];
        //                    break;
        //                case "CODESET":
        //                    hulftdef.CodeSet = array[1];
        //                    break;
        //                case "SHIFTTRANSACT":
        //                    hulftdef.Shifttransact = array[1];
        //                    break;
        //                case "END":
        //                    hulftSndDefs.Add(hulftdef.Clone());
        //                    //dict[hulftdef.Id]= hulftdef.Clone();
        //                    break;
        //            }
        //        }
        //    }

        //    return hulftSndDefs;
        //}

        //サンプル：HULFT配信定義
        //
        //#
        //# ID=LOOPBACK1
        //#
        //
        //SNDFILE=LOOPBACK1
        //FILENAME = C:\HULFT\LOOPSND.txt
        //TRANSTYPE = T
        //TRANSPRTY=50
        //INTERVAL=0
        //BLOCKLEN=4096
        //BLOCKCNT=3
        //COMP=N
        //GRPID = LOOPBACK
        //KJCHNGE=S
        //CLEAR = K
        //CODESET=A
        //SHIFTTRANSACT = Y
        //END

    }
}
