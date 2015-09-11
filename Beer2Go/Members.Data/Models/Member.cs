using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Data.Models
{
    public class Member
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }

        [StringLength(20)]
        public String PhoneNumber { get; set; }

        [StringLength(50)]
        public String Name { get; set; }

        [Range(-180,180, ErrorMessage = "Latitude must be between -180 and 180")]
        public Decimal LastLatitude { get; set; }

        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public Decimal LastLongitude { get; set; }

        public virtual MemberShip Membership { get; set; }

    }
}
