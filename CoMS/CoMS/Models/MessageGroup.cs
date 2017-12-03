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
    public class MessageGroup
    {
        private DB db;
        public MessageGroup()
        {
            db = new DB();
        }

        public List<MESSAGING_GROUP> getListMessageGroup(string userName)
        {
            var groups = (from m in db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP
                          join g in db.MESSAGING_GROUP on m.MESSAGING_GROUP_ID equals g.MESSAGING_GROUP_ID
                          where m.UserName == userName select new {m,g})
                         .AsEnumerable()
                         .ToList()
                         .Select(x => new MESSAGING_GROUP
                         {
                             MESSAGING_GROUP_ID = x.g.MESSAGING_GROUP_ID,
                             AVATAR_PICTURE = x.g.AVATAR_PICTURE,
                             AVATAR_PICTURE_FILENAME = x.g.AVATAR_PICTURE_FILENAME,
                             MESSAGING_GROUP_NAME = x.g.MESSAGING_GROUP_NAME,
                             MESSAGING_GROUP_NAME_EN = x.g.MESSAGING_GROUP_NAME_EN,
                             CONFERENCE_ID = x.g.CONFERENCE_ID,
                             CONFERENCE_NAME = x.g.CONFERENCE_NAME,
                             CONFERENCE_NAME_EN = x.g.CONFERENCE_NAME_EN,
                             PUBLIC_OR_PRIVATE_GROUP = x.g.PUBLIC_OR_PRIVATE_GROUP,
                             START_DATETIME = x.g.START_DATETIME,
                             END_DATETIME = x.g.END_DATETIME,
                             DESCRIPTION = x.g.DESCRIPTION,
                             DESCRIPTION_EN = x.g.DESCRIPTION_EN,
                             CREATED_UserName = x.g.CREATED_UserName,
                             CREATED_DATETIME = x.g.CREATED_DATETIME,
                             DELETED = x.g.DELETED,
                             DELETED_SCRIPT = x.g.DELETED_SCRIPT,
                             DELETED_UserName = x.g.DELETED_UserName
                         });
            return groups.ToList();
        }
    }
}