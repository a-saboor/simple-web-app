using System;
using System.Collections.Generic;

#nullable disable

namespace Proj9.DAL.Entities
{
    public partial class ReturnMaster
    {
        public ReturnMaster()
        {
            ReturnDetails = new HashSet<ReturnDetail>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal TotalAmt { get; set; }
        public string UpdUser { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<ReturnDetail> ReturnDetails { get; set; }
    }
}
