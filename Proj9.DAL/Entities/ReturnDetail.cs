using System;
using System.Collections.Generic;

#nullable disable

namespace Proj9.DAL.Entities
{
    public partial class ReturnDetail
    {
        public long Id { get; set; }
        public long ReturnMasterId { get; set; }
        public long ItemMasterId { get; set; }
        public int Qty { get; set; }
        public int PurRate { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ItemMaster ItemMaster { get; set; }
        public virtual ReturnMaster ReturnMaster { get; set; }
    }
}
