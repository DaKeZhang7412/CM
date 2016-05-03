using CM.Models;
using CM.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CM.Services
{
    public class MemberService
    {
        private IApplicationDbContext db;

        public MemberService(IApplicationDbContext dbContext)
        {
            db = dbContext;             
        }

        public void CreateMember(string name, string memberDHSNumber, string userId)
        {
            var member = new Member_information { Name = name, MemberDHSNumber = memberDHSNumber, ApplicationUserId = userId };
            db.Membership.Add(member);
            db.SaveChanges();
        }

        public void UpdateMemberInformation(int memberId)
        {
            var member = db.Membership.Where(c => c.Id == memberId).FirstOrDefault();
            member.Name = db.UpdateMemberInformations.Where(c =>c.MemberId == memberId).First().UpdatedName;
            db.SaveChanges();
        }
    }
}