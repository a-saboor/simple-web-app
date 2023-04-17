using System;
using System.Collections.Generic;

#nullable disable

namespace Proj9.DAL.Entities
{
    public partial class ItemMaster
    {
        public ItemMaster()
        {
            PurchaseDetails = new HashSet<PurchaseDetail>();
            ReturnDetails = new HashSet<ReturnDetail>();
            SaleDetails = new HashSet<SaleDetail>();
        }

        public long Id { get; set; }
        public long ItemCat { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public decimal SaleRate { get; set; }
        public decimal PurRate { get; set; }
        public string UpdUser { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ItemCategory ItemCatNavigation { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual ICollection<ReturnDetail> ReturnDetails { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
