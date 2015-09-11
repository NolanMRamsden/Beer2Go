using Members.Contracts.Models;
using Members.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Members.Service.DataBoundary
{
    public static class MemberComposer
    {
        public static MemberDto DtoFromMember(Member member)
        {
            if (member == null) return null;

            return new MemberDto()
            {
                MemberId = member.MemberId,
                Name = member.Name,
                LastLatitude = member.LastLatitude,
                LastLongitude = member.LastLongitude,
                PhoneNumber = member.PhoneNumber,
                Membership = member.Membership == null ? null : new MemberShipDto()
                {
                    MemberShipId = member.Membership.MemberShipId
                }
            };
        }

        public static Member MemberFromDto(MemberDto dto)
        {
            if (dto == null) return null;

            return new Member()
            {
                MemberId = dto.MemberId,
                Name = dto.Name,
                LastLatitude = dto.LastLatitude,
                LastLongitude = dto.LastLongitude,
                PhoneNumber = dto.PhoneNumber,
                Membership = dto.Membership == null ? null : new MemberShip()
                {
                    MemberShipId = dto.Membership.MemberShipId
                }
            };
        }
    }
}