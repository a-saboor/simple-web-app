using System;
using System.Collections.Generic;

#nullable disable

namespace Proj9.DAL.Entities
{
    public partial class Admin
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string Contact { get; set; }
        public string Mobile { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
