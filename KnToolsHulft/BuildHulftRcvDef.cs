using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using KnToolsHulft.Data;

namespace KnToolsHulft
{
    public class BuildHulftRcvDef
    {

        public List<HulftRcvDef> ReadBuildHulftRcvDef(string file)
        {

            List<HulftRcvDef> hulftRcvDefs = new List<HulftRcvDef>();
            HulftRcvDef hulftdef = new HulftRcvDef();

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
                        case "# ID":
                            hulftdef.ClearRest();
                            hulftdef.Id = array[1];
                            break;
                        case "RCVFILE":
                            hulftdef.RcvFile = array[1];
                            break;
                        case "COMMENT":
                            hulftdef.Comment = array[1];
                            break;
                        case "FILENAME":
                            hulftdef.FileName = array[1];
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
                        case "GENCTL":
                            hulftdef.GenCtl = array[1];
                            break;
                        case "GENMNGNO":
                            hulftdef.GenMngNo = array[1];
                            break;
                        case "CODESET":
                            hulftdef.CodeSet = array[1];
                            break;
                        case "JOBID":
                            hulftdef.JobId = array[1];
                            break;
                        case "EJOBID":
                            hulftdef.Comment = array[1];
                            break;
                        case "JOBWAIT":
                            hulftdef.JobWait = array[1];
                            break;
                        case "GRPID":
                            hulftdef.GrpId = array[1];
                            break;
                        case "DATAVERIFY":
                            hulftdef.DataVerify = array[1];
                            break;
                        case "MAILID":
                            hulftdef.MailId = array[1];
                            break;
                        case "PASSWORD":
                            hulftdef.Password = array[1];
                            break;
                        case "END":
                            hulftRcvDefs.Add(hulftdef.Clone());
                            break;
                    }
                }

            }
            //
            return hulftRcvDefs;
        }
    }
}
