using System;
using System.Collections.Generic;

#nullable disable

namespace Proj9.DAL.Entities
{
    public partial class SaleDetail
    {
        public long Id { get; set; }
        public long SaleMasterId { get; set; }
        public long ItemMasterId { get; set; }
        public int Qty { get; set; }
        public int SaleRate { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ItemMaster ItemMaster { get; set; }
        public virtual SaleMaster SaleMaster { get; set; }
    }
}
