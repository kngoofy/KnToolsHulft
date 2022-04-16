using System.Collections.Generic;
using System.Text;
using System.IO;
using KnToolsHulft.Data;
using System;
using System.Diagnostics;


namespace KnToolsHulft
{
    /// <summary>
    /// HULFTジョブ定義を扱うクラス
    /// </summary>
    public static class BuildHulftJobDef
    {
        /// <summary>
        /// HULFTジョブ定義のフラットテキストファイルを読んで、HulftJobDefクラスのListを生成して返す。
        /// </summary>
        /// <param name="file">HULFTジョブ定義ファイル名</param>
        /// <returns>HulftTGrpクラスのList</returns>
        public static List<HulftJobDef> StreamBuildHulftJobDef(string filename)
        {
            string htmlText = File.ReadAllText(filename);
            return StringBuildHulftJobDef(htmlText);
        }

        /// <summary>
        /// HULFTジョブ定義の文字列を解釈して、HulftJobDefクラスのListを生成して返す。
        /// </summary>
        /// <param name="HtmlText">HULFTジョブ定義文字列</param>
        /// <returns>HulftTGrpクラスのList</returns>
        public static List<HulftJobDef> StringBuildHulftJobDef(string HtmlText)
        {
            List<HulftJobDef> hulftJobDefs = new List<HulftJobDef>();
            HulftJobDef hulftdef = new HulftJobDef();

            using (StringReader sr = new StringReader(HtmlText))
            {

                string fileContent = "";
                bool jobDef = false;

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
                        case "JOB":
                            hulftdef.Job = array[1];
                            break;
                        case "COMMENT":
                            hulftdef.Comment = array[1];
                            break;
                        case "JOB DEF":
                            jobDef = true;
                            break;
                        case "DEFEND":
                            jobDef = false;
                            break;

                        case "END":
                            hulftJobDefs.Add(hulftdef.Clone());
                            break;
                    }

                    if (jobDef && array[0] != "JOB DEF")
                    {
                        hulftdef.JobList.Add(fileContent);
                        continue;
                    }

                }
            }

            return hulftJobDefs;
        }

        //サンプル：HULFTジョブ定義
        //
        //#
        //# ID=JOB1
        //#
        //
        //GRP=JOB1
        //JOB DEF
        //  job1
        //  job2
        //DEFEND
        //COMMENT=コメント1
        //END

    }
}
