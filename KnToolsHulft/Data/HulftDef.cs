using System.Collections.Generic;

namespace KnToolsHulft.Data
{
    /// <summary>
    /// HULFT 管理情報のBaseクラス 
    /// </summary>

    public class HulftDef
    {
        //プロパティ
        protected string SystemName { get; set; } = "";                                // システム名 
        protected HulftManageType ManagementType { get; set; } = HulftManageType.none; // 管理タイプ
        protected string KeyId { get; set; } = "";                                     // HULFT-KeyID                                                            

        /// <summary>
        /// コンストラクタ 引数なし
        /// </summary>
        public HulftDef()
        {
            ClearRest();
            ManagementType = HulftManageType.none;
        }

        /// <summary>
        /// コンストラクタ 第一引数あり
        /// </summary>
        /// <param name="type">HULFTの管理タイプ enum </param>
        public HulftDef(HulftManageType type)
        {
            ManagementType = type;
        }

        /// <summary>
        /// クラスのプロパティからStringのListを組み立てて返すメソッド
        /// </summary>
        /// <returns>stringのList</returns>
        public virtual List<string> GetListValues()
        {
            var list = new List<string>
            {
                 SystemName
                ,ManagementType.ToString()
                ,KeyId
            };
            return list;
        }

        /// <summary>
        /// 選択したプロパティ値をstringの配列で返すメソッド
        /// </summary>
        /// <returns>stringの配列</returns>
        //public string[] GetValueArray()
        public virtual string[] GetValueArray()
        {
            return GetListValues().ToArray();
        }

        /// <summary>
        /// クラスのプロパティを初期値にクリアリセットするメソッド
        /// </summary>
        public virtual void ClearRest()
        {
            SystemName = "";
            ManagementType = HulftManageType.none;
            KeyId = "";
        }

        ///// <summary>
        ///// クラスのコピークーロンを返すメソッド
        ///// </summary>
        ///// <returns></returns>
        //public virtual HulftDef Clone()
        //{
        //    return (HulftSndDef)MemberwiseClone();
        //}

    }
}
