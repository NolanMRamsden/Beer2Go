using Members.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Members.Data.Storage.MySql
{
    public class MySqlMembersData : IMemberData
    {
        String ConnectionString { get; set; }

        public MySqlMembersData(String connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException("connectionString");

            ConnectionString = connectionString;
            using (MySqlMembersDb Db = new MySqlMembersDb(ConnectionString))
            {
                if (!Db.Database.Exists() || !Db.Database.CompatibleWithModel(true))
                {
                    Db.Database.Delete();
                    Db.Database.Create();
                }
            }
        }

        public Member GetMemberById(int memberId)
        {
            using (MySqlMembersDb Db = new MySqlMembersDb(ConnectionString))
            {
                return Db.Members.Where(m => m.MemberId == memberId)
                                 .Include(m => m.Membership)
                                 .FirstOrDefault();
            }
        }

        public int StoreMember(Member member)
        {
            using (MySqlMembersDb Db = new MySqlMembersDb(ConnectionString))
            {
                Db.Members.Add(member);
                Db.SaveChanges();
            }
            return member.MemberId;
        }

        public void CreateMemberShip(int memberId)
        {
            var member = GetMemberById(memberId);
            if (member == null) return;
            using (MySqlMembersDb Db = new MySqlMembersDb(ConnectionString))
            {
                var membership = new MemberShip();
                Db.Memberships.Add(membership);
                Db.SaveChanges();
                Db.Members.Attach(member);
                member.Membership = membership;
                Db.SaveChanges();
            }
        }

        public void SetMemberLocation(int memberId, decimal latitude, decimal longitude)
        {
            var member = GetMemberById(memberId);
            if (member == null) return;
            using (MySqlMembersDb Db = new MySqlMembersDb(ConnectionString))
            {
                Db.Members.Attach(member);
                member.LastLongitude = longitude;
                member.LastLatitude = latitude;
                Db.Entry(member).Property("LastLongitude").IsModified = true;
                Db.Entry(member).Property("LastLatitude").IsModified = true;
                Db.SaveChanges();
            }
        }
    }
}
