using System.Collections.Generic;
using System.Text;
using System.IO;
using KnToolsHulft.Data;

namespace KnToolsHulft
{
    /// <summary>
    /// HULFTホスト定義を扱うクラス
    /// </summary>

    class BuildHulftHstDef
    {
        /// <summary>
        /// HULFTホスト定義のフラットテキストファイルを読んで、HulftHstDefクラスのListを生成して返す。
        /// </summary> 
        /// <param name="file">HULFTホスト定義ファイル名</param>
        /// <returns>HulftHstDefクラスのList</returns>

        public List<HulftHstDef> ReadBuildHulftHstDef(string file)
        {
            List<HulftHstDef> hulftHstDefs = new List<HulftHstDef>();
            HulftHstDef hulftdef = new HulftHstDef();

            string fileContent = "";
            using (var sr = new StreamReader(file, Encoding.Default))
            {
                while ((fileContent = sr.ReadLine()) != null)
                {
                    fileContent.Trim();
                    if (fileContent == "") continue;
                    if (fileContent == "#") continue;

                    string[] array = fileContent.Split('=');
                    switch (array[0])
                    {
                        case "!# ID":
                            hulftdef.ClearRest();
                            hulftdef.Id = array[1];
                            break;
                        case "HOST":
                            hulftdef.Host = array[1];
                            break;
                        case "COMMENT":
                            hulftdef.Comment = array[1];
                            break;
                        case "HOSTTYPE":
                            hulftdef.HostType = array[1];
                            break;
                        case "KCODETYPE":
                            hulftdef.KCodeType = array[1];
                            break;
                        case "RCVPORT":
                            hulftdef.RcvPort = array[1];
                            break;
                        case "REQPORT":
                            hulftdef.ReQPort = array[1];
                            break;
                        case "HJISYEARULFTID":
                            hulftdef.JisYear = array[1];
                            break;
                        case "CONNECTTYPE":
                            hulftdef.ConnectType = array[1];
                            break;
                        case "HOSTSPSNUM":
                            hulftdef.HostSPSNum = array[1];
                            break;
                        case "HUL7MODE":
                            hulftdef.HUL7Mode = array[1];
                            break;
                        case "MYPROXYNAME":
                            hulftdef.MyProxyName = array[1];
                            break;
                        case "MYPROXYPORT":
                            hulftdef.MyProxyPort = array[1];
                            break;
                        case "SENDPERMIT":
                            hulftdef.SendPermit = array[1];
                            break;
                        case "HULJOBPERMIT":
                            hulftdef.HULJobPermit = array[1];
                            break;
                        case "HULSNDRCPERMIT":
                            hulftdef.HULSNDRCPermit = array[1];
                            break;
                        case "HULRJOBPERMIT":
                            hulftdef.HULRJOBPermit = array[1];
                            break;
                        case "ALLOWINSTTRANS":
                            hulftdef.AllowWinstTrans = array[1];
                            break;
                        case "USRNOTIFY":
                            hulftdef.UsrNotiry = array[1];
                            break;
                        case "END":
                            hulftHstDefs.Add(hulftdef.Clone());
                            break;
                    }
                }
            }

            return hulftHstDefs;
        }

        //サンプル：HULFTホスト定義
        //
        //#
        //# ID=Host1
        //#
        //
        //HOST=Host1
        //HOSTTYPE = UNIX
        //KCODETYPE=UTF-8
        //JISYEAR=0
        //CONNECTTYPE=LAN
        //RCVPORT = 30000
        //REQPORT=31000
        //HOSTSPSNUM=0
        //MYPROXYNAME=PROXY1
        //MYPROXYPORT = 8080
        //SENDPERMIT=Y
        //HULJOBPERMIT = Y
        //HULSNDRCPERMIT=Y
        //HULRJOBPERMIT = Y
        //ALLOWINSTTRANS=Y
        //USRNOTIFY = Y
        //HUL7MODE=Y
        //COMMENT = コメント
        //END

    }

}
