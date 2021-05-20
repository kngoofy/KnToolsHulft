using System.Collections.Generic;

namespace KnToolsHulft.Data
{

    //HULFT 管理情報のBaseクラス
    public class HulftDef
    {
        //プロパティ
        public string SystemName { get; set; } = "";                                //システム名 
        public HulftManageType ManagementType { get; set; } = HulftManageType.none; // 管理タイプ
        public string KeyId { get; set; } = "";                                     // HULFT-KeyID                                                            

        //コンストラクタ
        public HulftDef()
        {
            ClearRest();
            ManagementType = HulftManageType.none;
        }
        public HulftDef(HulftManageType type)
        {
            ManagementType = type;
        }

        /*
        //選択したプロパティ値を配列で返すメソッド
        public virtual string[] getValueArray()
        {
            var list = new List<string>
            {
                 SystemName
                ,ManagementType.ToString()
                ,KeyId
        };
            return list.ToArray();
        }
        */

        public List<string> getListValues()
        {
            var list = new List<string>
            {
                SystemName
                ,ManagementType.ToString()
                ,KeyId
            };
            return list;

        }

        //選択したプロパティ値を配列で返すメソッド
        public string[] getValueArray()
        {
            return getListValues().ToArray();
        }

        //メンバのクリアリセットするメソッド
        public virtual void ClearRest()
        {
            SystemName = "";
            ManagementType = HulftManageType.none;
            KeyId = "";
        }

        /*
        //クラスのコピークーロンを返すメソッド
        public HulftSndDef Clone()
        {
            return (HulftSndDef)MemberwiseClone();
        }
        */
    }
}
