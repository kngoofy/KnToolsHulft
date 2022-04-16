using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KnToolsHulft.Data;
using System.Diagnostics;

namespace KnToolsHulft
{
    /// <summary>
    /// HULFT集信定義を扱うクラス
    /// </summary>
    public static class BuildHulftRcvDef
    {
        /// <summary>
        /// HULFT集信定義のフラットテキストファイルを読んで、HulftRcvDefクラスのListを生成して返す。
        /// </summary> 
        /// <param name="file">HULFT集信定義ファイル名</param>
        /// <returns>HulftRcvDefクラスのList</returns>
        public static List<HulftRcvDef> StreamBuildHulftRcvDef(string filename)
        {
            string htmlText = File.ReadAllText(filename);
            return StringBuildHulftRcvDef(htmlText);
        }

        public static List<HulftRcvDef> StringBuildHulftRcvDef(string HtmlText)
        {
            List<HulftRcvDef> hulftRcvDefs = new List<HulftRcvDef>();
            HulftRcvDef hulftdef = new HulftRcvDef();

            string fileContent = "";
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
                        case "RCVFILE":
                            hulftdef.RcvFile = array[1];
                            break;
                        case "FILENAME":
                            hulftdef.FileName = array[1];
                            break;
                        case "OWNER":
                            hulftdef.Owner = array[1];
                            break;
                        case "GROUP":
                            hulftdef.Group = array[1];
                            break;
                        case "PERM":
                            hulftdef.Perm = array[1];
                            break;
                        case "TRANSMODE":
                            hulftdef.TransMode = array[1];
                            break;
                        case "ABNORMAL":
                            hulftdef.Abnormal = array[1];
                            break;
                        case "RCVTYPE":
                            hulftdef.RcvType = array[1];
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
                        case "EJOBID":
                            hulftdef.EjobId = array[1];
                            break;
                        case "GENCTL":
                            hulftdef.GenCtl = array[1];
                            break;
                        case "PASSWORD":
                            hulftdef.Password = array[1];
                            break;
                        case "CODESET":
                            hulftdef.CodeSet = array[1];
                            break;
                        case "JOBWAIT":
                            hulftdef.JobWait = array[1];
                            break;
                        case "GENMNGNO":
                            hulftdef.GenMngNo = array[1];
                            break;
                        case "DATAVERIFY":
                            hulftdef.DataVerify = array[1];
                            break;

                        case "END":
                            hulftRcvDefs.Add(hulftdef.Clone());
                            break;
                    }
                }

            }

            return hulftRcvDefs;
        }

        ///// <summary>
        ///// HULFT集信定義のフラットテキストファイルを読んで、HulftRcvDefクラスのListを生成して返す。
        ///// </summary> 
        ///// <param name="file">HULFT集信定義ファイル名</param>
        ///// <returns>HulftRcvDefクラスのList</returns>
        //public static List<HulftRcvDef> ReadBuildHulftRcvDef(string file)
        //{
        //    List<HulftRcvDef> hulftRcvDefs = new List<HulftRcvDef>();
        //    HulftRcvDef hulftdef = new HulftRcvDef();

        //    string fileContent = "";
        //    using (var sr = new StreamReader(file, Encoding.Default))
        //    {
        //        while ((fileContent = sr.ReadLine()) != null)
        //        {
        //            fileContent.Trim();
        //            if (fileContent == "") continue;
        //            if (fileContent == "#") continue;

        //            string[] array = fileContent.Split('=');
        //            switch (array[0])
        //            {
        //                case "# ID":
        //                    hulftdef.ClearRest();
        //                    hulftdef.Id = array[1];
        //                    break;
        //                case "RCVFILE":
        //                    hulftdef.RcvFile = array[1];
        //                    break;
        //                case "COMMENT":
        //                    hulftdef.Comment = array[1];
        //                    break;
        //                case "FILENAME":
        //                    hulftdef.FileName = array[1];
        //                    break;
        //                case "TRANSMODE":
        //                    hulftdef.TransMode = array[1];
        //                    break;
        //                case "ABNORMAL":
        //                    hulftdef.Abnormal = array[1];
        //                    break;
        //                case "RCVTYPE":
        //                    hulftdef.RcvType = array[1];
        //                    break;
        //                case "GENCTL":
        //                    hulftdef.GenCtl = array[1];
        //                    break;
        //                case "GENMNGNO":
        //                    hulftdef.GenMngNo = array[1];
        //                    break;
        //                case "CODESET":
        //                    hulftdef.CodeSet = array[1];
        //                    break;
        //                case "JOBID":
        //                    hulftdef.JobId = array[1];
        //                    break;
        //                case "EJOBID":
        //                    hulftdef.Comment = array[1];
        //                    break;
        //                case "JOBWAIT":
        //                    hulftdef.JobWait = array[1];
        //                    break;
        //                case "GRPID":
        //                    hulftdef.GrpId = array[1];
        //                    break;
        //                case "DATAVERIFY":
        //                    hulftdef.DataVerify = array[1];
        //                    break;
        //                case "PASSWORD":
        //                    hulftdef.Password = array[1];
        //                    break;
        //                case "END":
        //                    hulftRcvDefs.Add(hulftdef.Clone());
        //                    break;
        //            }
        //        }

        //    }

        //    return hulftRcvDefs;
        //}

        //サンプル：HULFT集信定義
        //
        //#
        //# ID=RCV1
        //#
        //
        //RCVFILE=RCV1
        //FILENAME = RCV1.txt
        //CODESET=0
        //TRANSMODE=NEW
        //ABNORMAL = DELETE
        //RCVTYPE=S
        //GENCTL = YES
        //GENMNGNO=世代管理数
        //JOBID = 正常時ジョブID
        //EJOBID=異常時ジョブID
        //GRPID = 転送グループID
        //PASSWORD=暗号キー
        //MAILID = メール連携ID
        //JOBWAIT=J
        //DATAVERIFY = 0
        //COMMENT=コメント
        //END

    }
}
