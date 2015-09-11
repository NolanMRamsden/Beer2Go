using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Contracts.Models
{
    public class MemberDto
    {
        public int MemberId { get; set; }

        [Required]
        [Phone]
        public String PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        [Range(-180, 180, ErrorMessage = "Latitude must be between -180 and 180")]
        public Decimal LastLatitude { get; set; }

        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public Decimal LastLongitude { get; set; }

        public MemberShipDto Membership { get; set; }
    }
}
