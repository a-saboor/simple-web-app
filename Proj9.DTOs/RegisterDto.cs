using System;

namespace Proj9.DTOs
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] password { get; set; }
        public byte[] Salt { get; set; }
        public string Contact { get; set; }
        public string Mobile { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; } = false;
        public Nullable<DateTime> CreatedOn { get; set; } = Extras.TimeZone.GetLocalDateTime();
    }
}
