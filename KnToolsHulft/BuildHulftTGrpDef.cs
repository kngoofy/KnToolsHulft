using System.Collections.Generic;
using System.Text;
using System.IO;
using KnToolsHulft.Data;

namespace KnToolsHulft
{
    /// <summary>
    /// HULFT転送グループ定義を扱うクラス
    /// </summary>

    class BuildHulftTGrpDef
    {
        /// <summary>
        /// HULFT転送グループ定義のフラットテキストファイルを読んで、HulftTGrpクラスのListを生成して返す。
        /// </summary> 
        /// <param name="file">HULFT転送グループ定義ファイル名</param>
        /// <returns>HulftTGrpクラスのList</returns>

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

            return hulftTGrpDefs;
        }

        //サンプル：HULFT転送グループ定義
        //
        //#
        //# ID=GRP1
        //#
        //
        //GRP=GRP1
        //SERVER DEF
        //  grp1host1
        //  grp1host2
        //DEFEND
        //COMMENT=コメント1
        //END

    }
}
