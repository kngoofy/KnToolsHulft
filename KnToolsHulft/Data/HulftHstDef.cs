using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnToolsHulft.Data
{
    /// <summary>
    /// HULFTのホスト定義のクラス 一つのHULFT定義に値する
    /// </summary>
    public class HulftHstDef : HulftDef
    {
        //プロパティ
        //管理設定
        public string Id { get; set; } = "ID";                          // ID=LOOPBACK

        public string Host { get; set; } = "HOST";                      //× ホスト名
        public string Comment { get; set; } = "COMMENT";                //〇 コメント

        public string HostType { get; set; } = "HOSTTYPE";              //× ホスト種
        public string KCodeType { get; set; } = "KCODETYPE";            //× 転送コードセット・漢字コード種
        public string RcvPort { get; set; } = "RCVPORT";                //× 集信ポートNo.
        public string ReQPort { get; set; } = "REQPORT";                //× 要求受付ポートNo.
        public string JisYear { get; set; } = "JISYEAR";                //× 日本語規格・JIS年度
        public string ConnectType { get; set; } = "CONNECTTYPE";        //〇 接続形態
        public string HostSPSNum { get; set; } = "HOSTSPSNUM";          //〇 ホスト別配信多重度
        public string HUL7Mode { get; set; } = "HUL7MODE";              //〇 HULFT7通信モード
        //PROXYサーバ
        public string MyProxyName { get; set; } = "MYPROXYNAME";        //〇 PROXYサーバ名
        public string MyProxyPort { get; set; } = "MYPROXYPORT";        //〇 PROXYポートNo.
        //セキュリティ
        public string SendPermit { get; set; } = "SENDPERMIT";          //〇 送信要求・再送要求受付許可
        public string HULJobPermit { get; set; } = "HULJOBPERMIT";      //〇 集信後ジョブ結果参照要求受付許可
        public string HULSNDRCPermit { get; set; } = "HULSNDRCPERMIT";  //〇 ジョブ実行結果通知受付許可
        public string HULRJOBPermit { get; set; } = "HULRJOBPERMIT";    //〇 リモートジョブ実行受付許可
        public string AllowWinstTrans { get; set; } = "ALLOWINSTTRANS"; //〇 簡易転送受付許可
        public string UsrNotiry { get; set; } = "USRNOTIFY";            //〇 ユーザの通知

        /// <summary>
        /// コンストラクタ 引数なし
        /// </summary>
        public HulftHstDef() : base(HulftManageType.hst)
        {
            ClearRest();
        }

        /// <summary>
        /// コンストラクタ 第一引数
        /// </summary>
        /// <param name="type">string "Header" かそれ以外</param>
        public HulftHstDef(string type) : base(HulftManageType.hst)
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
        /// <returns>HulftHstDefクラスのクーロンされたオブジェクト</returns>
        public HulftHstDef Clone()
        {
            return (HulftHstDef)MemberwiseClone();
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
                Host,
                HostType,
                KCodeType,
                RcvPort,
                ReQPort,
                Comment,
                JisYear,
                ConnectType,
                HostSPSNum,
                SendPermit,
                HULJobPermit,
                HULSNDRCPermit,
                HULRJOBPermit,
                UsrNotiry,
                HUL7Mode,
                //AllowWinstTrans,
                //MyProxyName,
                //MyProxyPort,
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
            //ManagementType = HulftExportType.none; //親クラスのKeyID
            Id = "";
            Host = "";
            HostType = "";
            KCodeType = "";
            RcvPort = "";
            ReQPort = "";
            Comment = "";
            JisYear = "";
            ConnectType = "";
            HostSPSNum = "";
            SendPermit = "";
            HULJobPermit = "";
            HULSNDRCPermit = "";
            HULRJOBPermit = "";
            UsrNotiry = "";
            HUL7Mode = "";
            AllowWinstTrans = "";
            MyProxyName = "";
            MyProxyPort = "";
        }

    }
}
