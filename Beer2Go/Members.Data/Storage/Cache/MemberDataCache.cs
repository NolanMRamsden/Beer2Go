using Members.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Data.Storage.Cache
{
    public class MemberDataCache : IMemberData
    {
        public IMemberData DataStore { get; set; }

        Dictionary<int, Member> MembersCache;
        Dictionary<int, MemberShip> MemberShipCache;

        public MemberDataCache(IMemberData dataStore)
        {
            DataStore = dataStore;
            MembersCache = new Dictionary<int, Member>();
            MemberShipCache = new Dictionary<int, MemberShip>();
        }

        public Member GetMemberById(int memberId)
        {
            if(MembersCache.ContainsKey(memberId))
                return MembersCache[memberId];
            var member = DataStore.GetMemberById(memberId);
            if (member != null)
            {
                MembersCache.Add(member.MemberId, member);
            }

            return member;
        }

        public int StoreMember(Member member)
        {
            DataStore.StoreMember(member);
            MembersCache.Add(member.MemberId, member);

            return member.MemberId;
        }

        public void CreateMemberShip(int memberId)
        {
            DataStore.CreateMemberShip(memberId);
            MemberShip memberShip = DataStore.GetMemberById(memberId).Membership;
            MembersCache[memberId].Membership = memberShip;
            MemberShipCache.Add(memberId, memberShip);
        }

        public void SetMemberLocation(int memberId, decimal latitude, decimal longitude)
        {
            DataStore.SetMemberLocation(memberId, latitude, longitude);
            if(MembersCache.ContainsKey(memberId))
            {
                var member = MembersCache[memberId];
                member.LastLatitude = latitude;
                member.LastLongitude = longitude;
            }
        }
    }
}
