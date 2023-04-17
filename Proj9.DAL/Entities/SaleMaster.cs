using System;
using System.Collections.Generic;

#nullable disable

namespace Proj9.DAL.Entities
{
    public partial class SaleMaster
    {
        public SaleMaster()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal TotalAmt { get; set; }
        public string UpdUser { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
