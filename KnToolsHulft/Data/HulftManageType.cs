using System;
using System.Collections.Generic;

namespace KnToolsHulft.Data
{
    //HULFT 管理情報のタイプ
    public enum HulftManageType
    {
        none,
        snd,
        rcv,
        hst,
        tgrp,
        //job, fmt, mfmt, sch, trg
    }

}
/*
 -i { snd | rcv | job | hst | tgrp | fmt | mfmt | sch | trg }
エクスポート管理情報指定パラメータ
以下の管理情報をエクスポートすることができます。

    snd : 配信管理情報
    rcv : 集信管理情報
    job : ジョブ起動情報
    hst : 詳細ホスト情報
    tgrp : 転送グループ情報
    fmt : フォーマット情報
    mfmt : マルチフォーマット情報
    sch : スケジュール情報
    trg : ファイルトリガ情報

*/