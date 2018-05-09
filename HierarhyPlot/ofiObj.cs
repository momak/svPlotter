using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarhyPlot
{
    public class ofiObj
    {
        public string e_kod { get; set; }

        public decimal PocSostojba { get; set; }

        public decimal SteknuvanjeSO { get; set; }

        public decimal NamaluvanjeSO { get; set; }

        public decimal PromeniKR { get; set; }

        public decimal PromeniC { get; set; }

        public decimal PromeniO { get; set; }

        public decimal KrajSostojba { get; set; }

        public void Sum(ofiObj childObj)
        {
            PocSostojba += childObj.PocSostojba;
            SteknuvanjeSO += childObj.SteknuvanjeSO;
            NamaluvanjeSO += childObj.NamaluvanjeSO;
            PromeniKR += childObj.PromeniKR;
            PromeniC += childObj.PromeniC;
            PromeniO += childObj.PromeniO;
            KrajSostojba += childObj.KrajSostojba;
        }

        public override string ToString()
        {
            return $"{e_kod}, {PocSostojba}, {SteknuvanjeSO}, {NamaluvanjeSO}, {PromeniKR}, {PromeniC}, {PromeniO}, {KrajSostojba}";
        }
    }
}
