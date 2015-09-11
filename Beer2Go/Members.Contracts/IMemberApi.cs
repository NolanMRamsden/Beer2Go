using Members.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Contracts
{
    public interface IMemberApi
    {
        MemberDto GetMemberById(int memberId);
        int StoreMember(MemberDto member);
        void CreateMemberShip(int memberId);
        void SetMemberLocation(int memberId, decimal latitude, decimal longitude);
    }
}
