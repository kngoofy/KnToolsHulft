using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnToolsHulft.Data
{
    /// <summary>
    /// HULFTのジョブ起動のクラス 一つのHULFT定義に値する
    /// </summary>
    public class HulftJobDef : HulftDef
    {
        //プロパティ
        //ジョブ管理設定
        public string Id { get; set; } = "ID";              // ID

        public string Job { get; set; } = "JOB";            // × ジョブID
        public string Comment { get; set; } = "COMMENT";    // 〇 コメント
        public List<string> JobList = new List<string>();   // × 起動ジョブ

        /// <summary>
        /// コンストラクタ 引数なし
        /// </summary>
        public HulftJobDef() : base(HulftManageType.job)
        {
            ClearRest();
        }

        /// <summary>
        /// コンストラクタ 第一引数
        /// </summary>
        /// <param name="type">string "Header" かそれ以外</param>
        public HulftJobDef(string type) : base(HulftManageType.job)
        {
            switch (type)
            {
                case "Header":
                    break;
                default:
                    ClearRest();
                    break;
            }
        }

        /// <summary>
        /// クラスのコピークーロンを返すメソッド
        /// </summary>
        /// <returns>HulftTGtpDefクラスのクーロンされたオブジェクト</returns>
        public HulftJobDef Clone()
        {
            return (HulftJobDef)MemberwiseClone();
        }

        /// <summary>
        /// クラスのプロパティからStringのListを組み立てて返すメソッド
        /// </summary>
        /// <returns>stringのList</returns>
        public override List<string> GetListValues()
        {
            var list = new List<string>
            {
                Id,
                Job,
                Comment,
                string.Join(",",JobList)
             };
            return list;
        }

        /// <summary>
        /// 選択したプロパティ値をstringの配列で返すメソッド
        /// </summary>
        /// <returns>stringの配列</returns>
        public override string[] GetValueArray()
        {
            return GetListValues().ToArray();
        }

        /// <summary>
        /// クラスのプロパティに初期値をクリアリセットするメソッド
        /// </summary>
        public override void ClearRest()
        {
            //base.ClearRest();
            Id = "";
            Job = "";
            Comment = "";
            JobList = new List<string> { };
        }

    }
}
