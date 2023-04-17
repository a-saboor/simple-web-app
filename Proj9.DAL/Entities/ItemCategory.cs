using System;
using System.Collections.Generic;

#nullable disable

namespace Proj9.DAL.Entities
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            ItemMasters = new HashSet<ItemMaster>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<ItemMaster> ItemMasters { get; set; }
    }
}
