using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Data.Storage.Runtime
{
    public class RuntimeMemberData : IMemberData
    {
        public RuntimeMemberData()
        {
            throw new NotImplementedException();
        }

        public Models.Member GetMemberById(int memberId)
        {
            throw new NotImplementedException();
        }

        public int StoreMember(Models.Member member)
        {
            throw new NotImplementedException();
        }

        public void CreateMemberShip(int memberId)
        {
            throw new NotImplementedException();
        }

        public void SetMemberLocation(int memberId, decimal latitude, decimal longitude)
        {
            throw new NotImplementedException();
        }
    }
}
