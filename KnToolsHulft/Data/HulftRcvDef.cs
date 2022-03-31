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
        public string Comment { get; set; } = "COMMENT";        // 〇

        //基本設定
        public string FileName { get; set; } = "FILENAME";      // ×FILENAME=C:\HULFT\LOOPSND.txt
        public string TransMode { get; set; } = "TRANSMODE";    // ×TRANSTYPE=T
        public string Abnormal { get; set; } = "ABNORMAL";      // ×
        public string RcvType { get; set; } = "RCVTYPE";        // ×
        public string GenCtl { get; set; } = "GENCTL";          // ×
        public string GenMngNo { get; set; } = "GENMNGNO";      // 〇
        public string CodeSet { get; set; } = "CODESET";        //CODESET =A
        public string JobId { get; set; } = "JOBID";            // 〇
        public string EjobId { get; set; } = "EJOBID";          // 〇

        //拡張設定
        public string JobWait { get; set; } = "JOBWAIT";        // 〇
        public string GrpId { get; set; } = "GRPID";            // 〇//GRPID=LOOPBACK
        public string DataVerify { get; set; } = "DATAVERIFY";  // 〇
        public string MailId { get; set; } = "MAILID";          // 〇
        public string Password { get; set; } = "PASSWORD";      // 〇×

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
        public new List<string> getListValues()
        {
            var list = new List<string>
            {
                Id,
                RcvFile,
                Comment,
                FileName,
                TransMode,
                Abnormal,
                RcvType,
                GenCtl,
                GenMngNo,
                CodeSet,
                JobId,
                EjobId,
                JobWait,
                GrpId,
                DataVerify,
                MailId,
                Password
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
            RcvFile = "";
            Comment = "";
            FileName = "";
            TransMode = "";
            Abnormal = "";
            RcvType = "";
            GenCtl = "";
            GenMngNo = "";
            CodeSet = "";
            JobId = "";
            EjobId = "";
            JobWait = "";
            GrpId = "";
            DataVerify = "";
            MailId = "";
            Password = "";
        }

    }
}
