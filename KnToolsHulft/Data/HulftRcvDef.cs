using System.Collections.Generic;

namespace KnToolsHulft.Data

{
    /// <summary>
    /// HULFTの集信定義のクラス 一つのHULFT定義に値する
    /// </summary>
    public class HulftRcvDef : HulftDef
    {
        //プロパティ
        //集信管理設定
        public string Id { get; set; } = "HULFTID";             // ID=LOOPBACK

        public string RcvFile { get; set; } = "RCVFILE";        // ×SNDFILE=LOOPBACK
        public string Comment { get; set; } = "COMMENT";        // 〇コメント

        //基本設定
        public string FileName { get; set; } = "FILENAME";      // ×FILENAME=C:\HULFT\LOOPSND.txt
        public string Owner { get; set; } = "OWNER";            // 〇オーナ名
        public string Group { get; set; } = "GROUP";            // 〇グループ名
        public string Perm { get; set; } = "PERM";              // 〇パーミッション
        public string TransMode { get; set; } = "TRANSMODE";    // ×登録モード
        public string Abnormal { get; set; } = "ABNORMAL";      // ×異常時の処理
        public string RcvType { get; set; } = "RCVTYPE";        // ×集信形態
        public string GenCtl { get; set; } = "GENCTL";          // ×世代管理
        public string GenMngNo { get; set; } = "GENMNGNO";      // 〇世代管理数
        public string CodeSet { get; set; } = "CODESET";        // 〇EBCDICセット・コードセット
        public string JobId { get; set; } = "JOBID";            // 〇正常時ジョブID
        public string EjobId { get; set; } = "EJOBID";          // 〇異常時ジョブID

        //拡張設定
        public string JobWait { get; set; } = "JOBWAIT";        // 〇集信完了通知
        public string GrpId { get; set; } = "GRPID";            // 〇転送グループID
        public string DataVerify { get; set; } = "DATAVERIFY";  // 〇データ検証
        public string Password { get; set; } = "PASSWORD";      // 〇×暗号キー

        //
        /// <summary>
        /// コンストラクタ 引数なし
        /// </summary>
        /// 
        public HulftRcvDef() : base(HulftManageType.rcv)
        {
            ClearRest();
        }
        /// <summary>
        /// コンストラクタ 第一引数
        /// </summary>
        /// <param name="type">string "Header" かそれ以外</param>
        public HulftRcvDef(string type) : base(HulftManageType.rcv)
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
        /// <returns>HulftrcvDefクラスのクーロンされたオブジェクト</returns>
        public HulftRcvDef Clone()
        {
            return (HulftRcvDef)MemberwiseClone();
        }

        //newにした
        public new List<string> GetListValues()
        {
            var list = new List<string>
            {
                Id,
                RcvFile,
                FileName,
                Owner,
                Group,
                Perm,
                TransMode,
                Abnormal,
                RcvType,
                JobId,
                Comment,
                GrpId,
                EjobId,
                GenCtl,
                Password,
                CodeSet,
                JobWait,
                GenMngNo,
                DataVerify,
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
            base.ClearRest();
            Id = "";
            RcvFile = "";
            FileName = "";
            Owner = "";
            Group = "";
            Perm = "";
            TransMode = "";
            Abnormal = "";
            RcvType = "";
            JobId = "";
            Comment = "";
            GrpId = "";
            EjobId = "";
            GenCtl = "";
            Password = "";
            CodeSet = "";
            JobWait = "";
            GenMngNo = "";
            DataVerify = "";
        }

    }
}
