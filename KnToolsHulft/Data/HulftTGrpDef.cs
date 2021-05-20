﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsHulft.Data
{
    public class HulftTGrpDef : HulftDef
    {
        //ターゲットグループ管理設定
        public string Id { get; set; } = "GRPID";         // ID=LOOPBACK

        //プロパティ
        public string Grp { get; set; } = "GRP";            // × 転送グループID
        public string Comment { get; set; } = "COMMENT";    // 〇 コメント
        public string Server { get; set; } = "SERVER";    // 〇 コメント
        public List<string> ServerList;       // × ホスト名

        //コンストラクタ
        public HulftTGrpDef() : base(HulftManageType.tgrp)
        {
            ClearRest();
        }
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

        //クラスのコピークーロンを返すメソッド
        public HulftTGrpDef Clone()
        {
            return (HulftTGrpDef)MemberwiseClone();
        }

        //
        public List<string> getListValues()
        {
            var list = new List<string>
            {
                Id,
                Grp,
                Comment,
                Server
             };
            //base.getValueArray();
            return list;
        }
        public List<string> getListListValues()
        {
            var list = new List<string>
            {
                Id,
                Grp,
                Comment,
                string.Join(",",ServerList)
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

        public override void ClearRest()
        {
            //base.ClearRest();
            //ManagementType = HulftExportType.none; //親クラスのKeyID
            Id = "";
            Grp = "";
            Comment = "";
            ServerList = new List<string> { };
        }

    }
}