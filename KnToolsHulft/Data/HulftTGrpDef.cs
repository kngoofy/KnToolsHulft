using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnToolsHulft.Data
{
    /// <summary>
    /// HULFTの転送グループのクラス 一つのHULFT定義に値する
    /// </summary>

    public class HulftTGrpDef : HulftDef
    {
        //プロパティ
        //ターゲットグループ管理設定
        public string Id { get; set; } = "ID";                  // ID=LOOPBACK

        public string Grp { get; set; } = "GRP";                // × 転送グループID
        public string Comment { get; set; } = "COMMENT";        // 〇 コメント
        //public string Server { get; set; } = "SERVER";          // 〇 ホスト名
        public List<string> ServerList = new List<string>();    // × ホスト名

        /// <summary>
        /// コンストラクタ 引数なし
        /// </summary>        
        public HulftTGrpDef() : base(HulftManageType.tgrp)
        {
            ClearRest();
        }

        /// <summary>
        /// コンストラクタ 第一引数
        /// </summary>
        /// <param name="type">string "Header" かそれ以外</param>
        public HulftTGrpDef(string type) : base(HulftManageType.tgrp)
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
        public HulftTGrpDef Clone()
        {
            return (HulftTGrpDef)MemberwiseClone();
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
                Grp,
                Comment,
                string.Join(",",ServerList)
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
            Grp = "";
            Comment = "";
            ServerList = new List<string> { };
        }

    }
}
