using System;
using System.Collections.Generic;

#nullable disable

namespace Proj9.DAL.Entities
{
    public partial class PurchaseMaster
    {
        public PurchaseMaster()
        {
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal TotalAmt { get; set; }
        public string UpdUser { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
