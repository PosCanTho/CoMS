using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Resources;
using System.IO;
using Newtonsoft.Json;
using CoMS.Models;
using CoMS.Untils;
using CoMS.Entities_Framework;
using PagedList;

namespace CoMS.Models
{
    public class AccountMessagingGroupMemberModel
    {
        private DB db;
        public AccountMessagingGroupMemberModel()
        {
            db = new DB();
        }

        public object getListJoinChannel(string userName, int MESSAGING_GROUP_ID)
        {
            var account = new AccountModel();
            var list = db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP.Where(x => x.CREATED_UserName == userName && x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP JOIN REQUEST" && x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID && (x.DELETED == false || x.DELETED == null))
                .ToList()
                .AsEnumerable()
                .Select(x => new  {
                       UserName = x.UserName,
                       Image = new AccountModel().GetUserByUserName(x.UserName).Image,
                       MESSAGING_GROUP_ID = x.MESSAGING_GROUP_ID,
                       START_DATETIME = x.START_DATETIME,
                       END_DATETIME = x.END_DATETIME,
                       MESSAGING_GROUP_MODERATOR = x.MESSAGING_GROUP_MODERATOR,
                       MESSAGING_GROUP_MODERATOR_SCRIPT = x.MESSAGING_GROUP_MODERATOR_SCRIPT,
                       GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED = x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED,
                       GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED_SCRIPT = x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED_SCRIPT,
                       NOTE = x.NOTE,
                       NOTE_EN = x.NOTE_EN,
                       CREATED_UserName = x.CREATED_UserName,
                       DELETED = x.DELETED,
                       DELETED_SCRIPT = x.DELETED_SCRIPT,
                       DELETED_UserName = x.DELETED_UserName,
                       FULL_NAME = Utils.GetFullName(account.GetUserByUserName(x.UserName).CURRENT_FIRST_NAME, account.GetUserByUserName(x.UserName).CURRENT_MIDDLE_NAME, account.GetUserByUserName(x.UserName).CURRENT_LAST_NAME),
                       ORGANIZATION = account.GetUserByUserName(x.UserName).CURRENT_HOME_ORGANIZATION_NAME,
                       ORGANIZATION_EN = account.GetUserByUserName(x.UserName).CURRENT_HOME_ORGANIZATION_NAME_EN
                });
            return list.ToList();
        }

        public List<ACCOUNT_MESSAGING_GROUP_MEMBERSHIP> getListOfUserName(string userName)
        {
            var result = db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP.Where(m => m.UserName == userName || m.CREATED_UserName == userName)
               .Where(x => x.DELETED == false || x.DELETED == null)
               .Where(x => x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP ASSIGNED" || x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP JOIN REQUEST APPROVED")
               .ToList()
               .Select(x => new ACCOUNT_MESSAGING_GROUP_MEMBERSHIP
               {
                   UserName = x.UserName,
                   MESSAGING_GROUP_ID = x.MESSAGING_GROUP_ID,
                   START_DATETIME = x.START_DATETIME,
                   END_DATETIME = x.END_DATETIME,
                   MESSAGING_GROUP_MODERATOR = x.MESSAGING_GROUP_MODERATOR,
                   GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED = x.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED,
                   NOTE = x.NOTE,
                   NOTE_EN = x.NOTE_EN,
                   CREATED_UserName = x.CREATED_UserName,
                   DELETED = x.DELETED,
                   DELETED_UserName = x.DELETED_UserName
               }).Distinct().ToList();
            return result;
        }

    }
}