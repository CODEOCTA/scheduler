using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmailScheduler.Model
{
    class Tbl_Admin
    {
        [Key]
        public int admin_id { get; set; }
        public string admin_name { get; set; }
        public string admin_contact { get; set; }
        public string admin_image { get; set; }
        public string admin_email { get; set; }
        public string admin_password { get; set; }

        //public string otp { get; set; }

    }
}
