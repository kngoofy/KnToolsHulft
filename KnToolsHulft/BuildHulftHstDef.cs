using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KnToolsHulft.Data;

namespace KnToolsHulft
{
    class BuildHulftHstDef
    {

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
            //
            return hulftHstDefs;
        }

    }
}
