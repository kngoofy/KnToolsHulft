using System.Collections.Generic;


namespace KnToolsHulft.Data
{
    public class HulftSndDef : HulftDef
    {
        //配信管理設定
        public string Id { get; set; } = "HULFTID";                     // ID=LOOPBACK

        public string SndFile { get; set; } = "SNDFILE";                // × ファイルID SNDFILE=LOOPBACK
        public string Comment { get; set; } = "COMMENT";                // 〇 コメント
        //基本設定
        public string FileName { get; set; } = "FILENAME";              // × ファイル名 FILENAME=C:\HULFT\LOOPSND.txt
        public string TransType { get; set; } = "TRANSTYPE";            // × 転送タイプ TRANSTYPE=T
        public string FmtId { get; set; } = "FMTID";                    // 〇 M/フォーマットID
        public string Comp { get; set; } = "COMP";                      // × 圧縮方式 COMP=N
        public string CompSize { get; set; } = "COMPSIZE";              // 〇 圧縮単位
        public string DeflateLevel { get; set; } = "DEFLATELEVEL";      // 〇 DEFLATEレベル
        public string KjChnge { get; set; } = "KJCHNGE";                // × コード変換 KJCHNGE =S
        public string CodeSet { get; set; } = "CODESET";                // 〇 EBCDICセット CODESET =A
        public string Clear { get; set; } = "CLEAR";                    // 〇 配信ファイルの扱い
        public string GrpId { get; set; } = "GRPID";                    // × 転送グループID GRPID=LOOPBACK
        public string PrejobId { get; set; } = "PREJOBID";              // 〇 配信前ジョブID
        public string JobId { get; set; } = "JOBID";                    // 〇 正常時ジョブID
        public string EjobId { get; set; } = "EJOBID";                  // 〇 異常時ジョブID
        //拡張設定
        public string DbId { get; set; } = "DBID";                      // 〇 連携DBID
        public string Interval { get; set; } = "INTERVAL";              // × 転送間隔 INTERVAL=0
        public string Transprty { get; set; } = "TRANSPRTY";            // × 転送優先度 TRANSPRTY=50
        public string BlockLen { get; set; } = "BLOCKLEN";              // × 転送ブロック長 BLOCKLEN=4096
        public string BlockCnt { get; set; } = "BLOCKCNT";              // × 転送ブロック数 BLOCKCNT=3
        public string Shifttransact { get; set; } = "SHIFTTRANSACT";    // 〇 シフトコードの扱い SHIFTTRANSACT = Y
        public string MailId { get; set; } = "MAILID";                  // 〇 メール連携ID
        public string Password { get; set; } = "PASSWORD";              // 〇× 暗号キー

        //コンストラクタ
        public HulftSndDef() : base(HulftManageType.snd)
        {
            ClearRest();
        }
        public HulftSndDef(string type) : base(HulftManageType.snd)
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
        public HulftSndDef Clone()
        {
            return (HulftSndDef)MemberwiseClone();
        }

        //
        public List<string> getListValues()
        {
            var list = new List<string>
            {
                Id,
                SndFile,
                Comment,
                FileName,
                TransType,
                //FmtId,
                Comp,
                CompSize,
                //DeflateLevel,
                KjChnge,
                //CodeSet,
                //Clear,
                GrpId,
                //PrejobId,
                JobId,
                EjobId,
                //DbId,
                Interval,
                Transprty,
                BlockLen,
                BlockCnt,
                //Shifttransact,
                //MailId,
                //Password
            };
            //base.getValueArray();
            return list;
        }

        /*
       //選択したプロパティ値を配列で返すメソッド
       public override string[] getValueArray()
       {

           var list = new List<string>
           {
               Id,
               SndFile,
               Comment,
               FileName,
               TransType,
               //FmtId,
               Comp,
               CompSize,
               //DeflateLevel,
               KjChnge,
               //CodeSet,
               //Clear,
               GrpId,
               //PrejobId,
               JobId,
               EjobId,
               //DbId,
               Interval,
               Transprty,
               BlockLen,
               BlockCnt,
               //Shifttransact,
               //MailId,
               //Password
           };
           //base.getValueArray();


           return getListValues().ToArray();
           //return list.ToArray();
       }

       */


        //プロパティの初期値にクリアリセット
        public override void ClearRest()
        {
            //base.ClearRest();
            //ManagementType = HulftExportType.none; //親クラスのKeyID
            Id = "";
            SndFile = "";
            Comment = "";
            FileName = "";
            TransType = "";
            FmtId = "";
            Comp = "";
            CompSize = "";
            DeflateLevel = "";
            KjChnge = "";
            CodeSet = "";
            Clear = "";
            GrpId = "";
            PrejobId = "";
            JobId = "";
            EjobId = "";
            DbId = "";
            Interval = "";
            Transprty = "";
            BlockLen = "";
            BlockCnt = "";
            Shifttransact = "";
            MailId = "";
            Password = "";
        }

    }
}
