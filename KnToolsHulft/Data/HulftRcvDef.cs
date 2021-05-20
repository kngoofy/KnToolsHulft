using System.Collections.Generic;

namespace KnToolsHulft.Data

{
    public class HulftRcvDef : HulftDef
    {
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

        //コンストラクタ
        public HulftRcvDef() : base(HulftManageType.rcv)
        {
            ClearRest();
        }
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

        //クラスのコピークーロンを返すメソッド
        public HulftRcvDef Clone()
        {
            return (HulftRcvDef)MemberwiseClone();
        }

        //
        public List<string> getListValues()
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

        //メンバのクリアリセット
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
