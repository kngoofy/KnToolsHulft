using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsHulft.Data
{
    /// <summary>
    /// HULFTのホスト定義のクラス 一つのHULFT定義に値する
    /// </summary>
    public class HulftHstDef : HulftDef
    {
        //プロパティ
        //管理設定
        public string Id { get; set; } = "HOSTID";                      // ID=LOOPBACK

        public string Host { get; set; } = "HOST";                      //× ホスト名
        public string Comment { get; set; } = "COMMENT";                //〇 コメント
        public string HostType { get; set; } = "HOSTTYPE";              //× ホスト種
        public string KCodeType { get; set; } = "KCODETYPE";            //× 漢字コード種

        public string RcvPort { get; set; } = "RCVPORT";                //× 集信ポートNo.
        public string ReQPort { get; set; } = "REQPORT";                //× 要求受付ポートNo.
        public string JisYear { get; set; } = "HJISYEARULFTID";         //× 日本語規格
        //public string JISYEAR { get; set; } = "JISYEAR";                //× 
        public string ConnectType { get; set; } = "CONNECTTYPE";        //〇 接続形態
        public string HostSPSNum { get; set; } = "HOSTSPSNUM";          //〇 ホスト別配信多重度
        public string HUL7Mode { get; set; } = "HUL7MODE";              //〇 HULFT7通信モード
        //PROXYサーバ
        public string MyProxyName { get; set; } = "MYPROXYNAME";        //〇
        public string MyProxyPort { get; set; } = "MYPROXYPORT";        //〇
        //セキュリティ
        public string SendPermit { get; set; } = "SENDPERMIT";          //〇 送信要求・再送要求受付許可
        public string HULJobPermit { get; set; } = "HULJOBPERMIT";      //〇 集信後ジョブ結果参照要求受付許可
        public string HULSNDRCPermit { get; set; } = "HULSNDRCPERMIT";  //〇 ジョブ実行結果通知受付許可
        public string HULRJOBPermit { get; set; } = "HULRJOBPERMIT";    //〇 リモートジョブ実行受付許可
        public string AllowWinstTrans { get; set; } = "ALLOWINSTTRANS";  //〇 簡易転送受付許可
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

        // newにした
        public new List<string> getListValues()
        {
            var list = new List<string>
            {
                Id,
                Host,
                Comment,
                HostType,
                KCodeType,
                RcvPort,
                ReQPort,
                JisYear,
                ConnectType,
                HostSPSNum,
                HUL7Mode,
                MyProxyName,
                MyProxyPort,
                SendPermit,
                HULJobPermit,
                HULSNDRCPermit,
                HULRJOBPermit,
                AllowWinstTrans,
                UsrNotiry
            };
            //base.getValueArray();
            return list;
        }

        /*
         //選択したプロパティ値を配列で返すメソッド
          public override string[] getValueArray()
          {
            return getListValues().ToArray();
           }
        */

        /// <summary>
        /// クラスのプロパティに初期値をクリアリセットするメソッド
        /// </summary>
        public override void ClearRest()
        {
            //base.ClearRest();
            //ManagementType = HulftExportType.none; //親クラスのKeyID
            Id = "";
            Host = "";
            Comment = "";
            HostType = "";
            KCodeType = "";
            RcvPort = "";
            ReQPort = "";
            JisYear = "";
            ConnectType = "";
            HostSPSNum = "";
            HUL7Mode = "";
            MyProxyName = "";
            MyProxyPort = "";
            SendPermit = "";
            HULJobPermit = "";
            HULSNDRCPermit = "";
            HULRJOBPermit = "";
            AllowWinstTrans = "";
            UsrNotiry = "";
        }

    }
}
