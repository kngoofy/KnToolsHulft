using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsHulft.Data
{
    struct HulftStructSnd
    {
        //プロパティ
        public string Id { get; set; }                   // ID=LOOPBACK
        public string Sndfile { get; set; }         // SNDFILE=LOOPBACK
        public string Filename { get; set; }       // FILENAME=C:\HULFT\LOOPSND.txt
        public string Transtype { get; set; }      // TRANSTYPE=T
        public string Transprty { get; set; }      // TRANSPRTY=50
        public string Interval { get; set; }        // INTERVAL=0
        public string Blocklen { get; set; }        // BLOCKLEN=4096
        public string Blockcnt { get; set; }        // BLOCKCNT=3
        public string Comp { get; set; }            // COMP=N
        public string Grpid { get; set; }           //GRPID=LOOPBACK
        public string Kjchnge { get; set; }         //KJCHNGE =S
        public string Clear { get; set; }           //CLEAR = K
        public string Codeset { get; set; }         //CODESET =A
        public string Shifttransact { get; set; }   //SHIFTTRANSACT = Y

        //コンストラクター
        public HulftStructSnd(string a)
        {
            Id = "";
            Sndfile = "";
            Filename = "";
            Transtype = "";
            Transprty = "";
            Interval = "";
            Blocklen = "";
            Blockcnt = "";
            Comp = "";
            Grpid = "";
            Kjchnge = "";
            Clear = "";
            Codeset = "";
            Shifttransact = "";
        }

        //メソッド        
        public void RestCLear()
        {
            Shifttransact = "";
            Id = "";
            Sndfile = "";
            Filename = "";
            Transtype = "";
            Transprty = "";
            Interval = "";
            Blocklen = "";
            Blockcnt = "";
            Comp = "";
            Grpid = "";
            Kjchnge = "";
            Clear = "";
            Codeset = "";
        }

    }
}
