using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KnToolsHulft.Data;

namespace KnToolsHulft
{
    class BuildHulftTGrpDef
    {
        public List<HulftTGrpDef> ReadBuildHulftTGrpDef(string file)
        {

            List<HulftTGrpDef> hulftTGrpDefs = new List<HulftTGrpDef>();
            HulftTGrpDef hulftdef = new HulftTGrpDef();

            string fileContent = "";
            bool serverDef = false;
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
                        case "GRP":
                            hulftdef.Grp = array[1];
                            break;
                        case "COMMENT":
                            hulftdef.Comment = array[1];
                            break;
                        case "SERVER DEF":
                            serverDef = true;
                            //hulftdef.Server = array[1];
                            break;
                        case "DEFEND":
                            serverDef = false;
                            break;
                        case "END":
                            hulftTGrpDefs.Add(hulftdef.Clone());
                            break;
                    }

                    if (serverDef && array[0] != "SERVER DEF")
                    {
                        hulftdef.ServerList.Add(fileContent);
                        continue;
                    }

                }

            }
            //
            return hulftTGrpDefs;
        }

    }
}
