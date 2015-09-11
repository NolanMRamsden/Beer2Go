using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Data.Models
{
    public class MemberShip
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberShipId { get; set; }

    }
}
