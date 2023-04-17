using System;
using System.Collections.Generic;

#nullable disable

namespace Proj9.DAL.Entities
{
    public partial class PurchaseDetail
    {
        public long Id { get; set; }
        public long PurchaseMasterId { get; set; }
        public long ItemMasterId { get; set; }
        public int Qty { get; set; }
        public int PurRate { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ItemMaster ItemMaster { get; set; }
        public virtual PurchaseMaster PurchaseMaster { get; set; }
    }
}
