using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using KnToolsHulft.Data;

namespace KnToolsHulft
{
    public class BuildHulftSndDef
    {

        //
        public List<HulftSndDef> ReadBuildHulftSndDef(string filePathName)
        {

            // int counterLine = 0;
            string fileContent = "";

            //HULFT配信定義のクラスと積み上げたList型
            List<HulftSndDef> hulftSndDefs = new List<HulftSndDef>();
            //Dictionary<string, HulftSndDef> dict = new Dictionary<string,HulftSndDef>();
            HulftSndDef hulftdef = new HulftSndDef();

            using (var sr = new StreamReader(filePathName, Encoding.Default))
            {
                while ((fileContent = sr.ReadLine()) != null)
                {
                    fileContent.Trim();
                    if (fileContent == "") continue;
                    if (fileContent == "#") continue;

                    //fileContent.Contains("# ID=");
                    string[] array = fileContent.Split('=');
                    //Console.WriteLine(string.Join(" ", array));
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
                        case "TRANSTYPE":
                            hulftdef.TransType = array[1];
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
                        case "GRPID":
                            hulftdef.GrpId = array[1];
                            break;
                        case "KJCHNGE":
                            hulftdef.KjChnge = array[1];
                            break;
                        case "CLEAR":
                            hulftdef.Clear = array[1];
                            break;
                        case "CODESET":
                            hulftdef.CodeSet = array[1];
                            break;
                        case "SHIFTTRANSACT":
                            hulftdef.Shifttransact = array[1];
                            break;
                        case "END":
                            hulftSndDefs.Add(hulftdef.Clone());
                            //dict[hulftdef.Id]= hulftdef.Clone();
                            break;
                    }
                }
            }
            //
            return hulftSndDefs;
        }

        //
    }
}
