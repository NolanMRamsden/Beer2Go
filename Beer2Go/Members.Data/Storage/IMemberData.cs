using Members.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Data.Storage
{
    public interface IMemberData
    {
        Member GetMemberById(int memberId);
        int StoreMember(Member member);
        void CreateMemberShip(int memberId);
        void SetMemberLocation(int memberId, decimal latitude, decimal longitude);
    }
}
