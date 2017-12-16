using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Resources;
using System.IO;
using Newtonsoft.Json;
using CoMS.Models;
using CoMS.Untils;
using CoMS.Entities_Framework;
using PagedList;

namespace CoMS.Controllers
{
    public class ChannelController : BaseController
    {
        private DB db = new DB();


        [HttpGet]
        [Route("api/ListFollowAndFollowMeAndAttendeeAndPresenter")]
        public HttpResponseMessage ListFollowAndFollowMeAndAttendeeAndPresenter(int personId, string userName, int conferenceId)
        {
            try
            {
                var followModel = new FollowModel();
                var channelModel = new ChannelModel();
                var listFollow = followModel.getListFollow(userName, conferenceId);
                var listFollowMe = followModel.getListFollowMe(userName, conferenceId);
                var listAttendee = channelModel.getListAttendee(personId, conferenceId);
                var listPresenter = channelModel.getListPresenter(personId, conferenceId);

                //Lọc ra những tài khoản giống nhau
                var result = new ListForNewChannel();
                result.ListFollow = listFollow;
                result.ListFollowMe = listFollowMe;
                result.ListAttendee = new List<Presenter>();
                result.ListPresenter = new List<Presenter>();

                foreach (Presenter attendee in listAttendee)
                {
                    if (result.ListFollow != null && result.ListFollowMe != null)
                    {
                        if (!result.ListFollow.Any(x => x.PERSON_ID == attendee.PERSON_ID) && !result.ListFollowMe.Any(x => x.PERSON_ID == attendee.PERSON_ID))
                        {
                            if (attendee.PERSON_ID != personId)
                            {
                                result.ListAttendee.Add(attendee);
                            }
                        }
                    }
                    else if (result.ListFollow != null && result.ListFollowMe == null)
                    {
                        if (!result.ListFollow.Any(x => x.PERSON_ID == attendee.PERSON_ID))
                        {
                            if (attendee.PERSON_ID != personId)
                            {
                                result.ListAttendee.Add(attendee);
                            }
                        }
                    }
                    else if (result.ListFollow == null && result.ListFollowMe != null)
                    {
                        if (!result.ListFollowMe.Any(x => x.PERSON_ID == attendee.PERSON_ID))
                        {
                            if (attendee.PERSON_ID != personId)
                            {
                                result.ListAttendee.Add(attendee);
                            }
                        }
                    }
                }

                foreach (Presenter presenter in listPresenter)
                {
                    if (result.ListFollow != null && result.ListFollowMe != null)
                    {
                        if (!result.ListFollow.Any(x => x.PERSON_ID == presenter.PERSON_ID) && !result.ListFollowMe.Any(x => x.PERSON_ID == presenter.PERSON_ID))
                        {
                            if (presenter.PERSON_ID != personId)
                            {
                                result.ListPresenter.Add(presenter);
                            }
                        }
                    }
                    else if (result.ListFollow != null && result.ListFollowMe == null)
                    {
                        if (!result.ListFollow.Any(x => x.PERSON_ID == presenter.PERSON_ID))
                        {
                            if (presenter.PERSON_ID != personId)
                            {
                                result.ListPresenter.Add(presenter);
                            }
                        }
                    }
                    else if (result.ListFollow == null && result.ListFollowMe != null)
                    {
                        if (!result.ListFollowMe.Any(x => x.PERSON_ID == presenter.PERSON_ID))
                        {
                            if (presenter.PERSON_ID != personId)
                            {
                                result.ListPresenter.Add(presenter);
                            }
                        }
                    }
                }

                return ResponseSuccess(StringResource.Success, result);
            }
            catch
            {
                return ResponseFail(StringResource.Get_list_for_new_channel_error);
            }
        }


        [HttpPost]
        [Route("api/NewChannel")]
        public HttpResponseMessage NewChannel([FromBody]NewChannel channel)
        {
            try
            {
                var messageGroup = new MESSAGING_GROUP();
                var messageGroups = db.MESSAGING_GROUP.ToList();
                var conference = db.CONFERENCEs.SingleOrDefault(x => x.CONFERENCE_ID == channel.CONFERENCE_ID);
                if (conference == null)
                {
                    return ResponseFail(StringResource.Conference_do_not_exist);
                }
                else
                {
                    if (messageGroups.Count > 0)
                    {
                        messageGroup.MESSAGING_GROUP_ID = messageGroups.Last().MESSAGING_GROUP_ID + 1;
                    }
                    else
                    {
                        messageGroup.MESSAGING_GROUP_ID = 0;
                    }
                    messageGroup.MESSAGING_GROUP_NAME = channel.MESSAGING_GROUP_NAME;
                    messageGroup.MESSAGING_GROUP_NAME_EN = channel.MESSAGING_GROUP_NAME_EN;
                    messageGroup.AVATAR_PICTURE_FILENAME = channel.AVATAR_PICTURE_FILENAME;
                    messageGroup.CONFERENCE_ID = channel.CONFERENCE_ID;
                    messageGroup.CONFERENCE_NAME = conference.CONFERENCE_NAME;
                    messageGroup.CONFERENCE_NAME_EN = conference.CONFERENCE_NAME_EN;
                    messageGroup.PUBLIC_OR_PRIVATE_GROUP = channel.PUBLIC_OR_PRIVATE_GROUP;
                    messageGroup.CREATED_DATETIME = DateTime.Now;
                    messageGroup.CREATED_UserName = channel.CREATED_UserName;
                    db.MESSAGING_GROUP.Add(messageGroup);
                    db.SaveChanges();

                    foreach (MessageGroupMember item in channel.MEMBERS)
                    {
                        var member = new ACCOUNT_MESSAGING_GROUP_MEMBERSHIP();
                        member.UserName = item.UserName;
                        member.MESSAGING_GROUP_ID = messageGroup.MESSAGING_GROUP_ID;
                        member.START_DATETIME = DateTime.Now;
                        member.CREATED_UserName = channel.CREATED_UserName;
                        member.MESSAGING_GROUP_MODERATOR = item.UserName == channel.CREATED_UserName ? true : false;
                        member.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED = "GROUP ASSIGNED";
                        db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP.Add(member);
                        db.SaveChanges();
                    }

                    return ResponseSuccess(StringResource.Success, channel);
                }
            }
            catch
            {
                return ResponseFail(StringResource.Can_not_create_new_channel);
            }
        }

        [HttpPost]
        [Route("api/ListChannel")]
        public HttpResponseMessage ListChannel(string userName, int conferenceId, int page, int pageSize)
        {
            var result = new AccountMessagingGroupMemberModel().getListOfUserName(userName);
            var listChannel = new List<Group>();
            foreach (ACCOUNT_MESSAGING_GROUP_MEMBERSHIP item in result)
            {
                var groups = db.MESSAGING_GROUP.Where(x => (x.MESSAGING_GROUP_ID == item.MESSAGING_GROUP_ID || x.PUBLIC_OR_PRIVATE_GROUP == "PUBLIC GROUP" || x.CREATED_UserName == userName) && x.CONFERENCE_ID == conferenceId && (x.DELETED == null || x.DELETED == false)).OrderByDescending(x => x.CREATED_DATETIME).ToPagedList(page, pageSize);
                foreach (MESSAGING_GROUP messageGroup in groups)
                {
                    var members = from g in db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP
                                  join a in db.ACCOUNTs on g.UserName equals a.UserName
                                  where g.MESSAGING_GROUP_ID == messageGroup.MESSAGING_GROUP_ID && (g.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP ASSIGNED" || g.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED == "GROUP JOIN REQUEST APPROVED")
                                  && (g.DELETED == false || g.DELETED == null)
                                  select new
                                  {
                                      a.Image,
                                      a.CURRENT_FIRST_NAME,
                                      a.CURRENT_LAST_NAME,
                                      a.CURRENT_MIDDLE_NAME,

                                      g.UserName,
                                      g.MESSAGING_GROUP_ID,
                                      g.START_DATETIME,
                                      g.MESSAGING_GROUP_MODERATOR,
                                      g.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED,
                                      g.NOTE,
                                      g.NOTE_EN,
                                      g.CREATED_UserName,
                                      g.DELETED
                                  };
                    if (members != null)
                    {
                        var group = new Group();
                        group.MESSAGING_GROUP_ID = messageGroup.MESSAGING_GROUP_ID;
                        group.MESSAGING_GROUP_NAME = messageGroup.MESSAGING_GROUP_NAME;
                        group.MESSAGING_GROUP_NAME_EN = messageGroup.MESSAGING_GROUP_NAME_EN;
                        group.AVATAR_PICTURE_FILENAME = messageGroup.AVATAR_PICTURE_FILENAME;
                        group.CREATED_DATETIME = messageGroup.CREATED_DATETIME;
                        group.CREATED_UserName = messageGroup.CREATED_UserName;
                        group.MEMBERS = members.ToList();
                        if (!listChannel.Any(x => x.MESSAGING_GROUP_ID == group.MESSAGING_GROUP_ID))
                        {
                            listChannel.Add(group);
                        }
                    }
                }
            }
            return ResponseSuccess(StringResource.Success, listChannel);
        }

        [HttpPost]
        [Route("api/ListMyChannel")]
        public HttpResponseMessage ListMyChannel(string userName, int conferenceId, int page, int pageSize)
        {
            try
            {
                var groups = db.MESSAGING_GROUP.Where(x => x.CREATED_UserName == userName && x.CONFERENCE_ID == conferenceId && (x.DELETED == null || x.DELETED == false)).OrderByDescending(x => x.CREATED_DATETIME).ToPagedList(page, pageSize);
                var listChannel = new List<Group>();
                foreach (MESSAGING_GROUP item in groups)
                {
                    var members = from g in db.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP
                                  join a in db.ACCOUNTs on g.UserName equals a.UserName
                                  where g.MESSAGING_GROUP_ID == item.MESSAGING_GROUP_ID
                                  select new
                                  {
                                      a.Image,
                                      a.CURRENT_FIRST_NAME,
                                      a.CURRENT_LAST_NAME,
                                      a.CURRENT_MIDDLE_NAME,

                                      g.UserName,
                                      g.MESSAGING_GROUP_ID,
                                      g.START_DATETIME,
                                      g.MESSAGING_GROUP_MODERATOR,
                                      g.GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED,
                                      g.NOTE,
                                      g.NOTE_EN,
                                      g.CREATED_UserName,
                                      g.DELETED
                                  };
                    if (members != null)
                    {
                        var group = new Group();
                        group.MESSAGING_GROUP_ID = item.MESSAGING_GROUP_ID;
                        group.MESSAGING_GROUP_NAME = item.MESSAGING_GROUP_NAME;
                        group.MESSAGING_GROUP_NAME_EN = item.MESSAGING_GROUP_NAME_EN;
                        group.AVATAR_PICTURE_FILENAME = item.AVATAR_PICTURE_FILENAME;
                        group.CREATED_DATETIME = item.CREATED_DATETIME;
                        group.CREATED_UserName = item.CREATED_UserName;
                        group.MEMBERS = members.ToList();
                        listChannel.Add(group);
                    }
                }
                return ResponseSuccess(StringResource.Success, listChannel);
            }
            catch
            {
                return ResponseFail(StringResource.Load_my_channel_error);
            }
        }

        [HttpPost]
        [Route("api/DeleteChannel")]
        public HttpResponseMessage DeleteChannel(string userName, int MESSAGING_GROUP_ID, int CONFERENCE_ID)
        {
            var group = db.MESSAGING_GROUP.SingleOrDefault(x => x.MESSAGING_GROUP_ID == MESSAGING_GROUP_ID && x.CONFERENCE_ID == CONFERENCE_ID && x.CREATED_UserName == userName);
            if (group == null)
            {
                return ResponseFail(StringResource.Message_group_do_not_exist);
            }
            else
            {
                group.DELETED = true;
                group.DELETED_DATETIME = DateTime.Now;
                group.DELETED_UserName = userName;
                db.SaveChanges();
                return ResponseSuccess(StringResource.Success);
            }
        }

    }

    public class ListForNewChannel
    {
        public List<Follow> ListFollow { get; set; }
        public List<Follow> ListFollowMe { get; set; }
        public List<Presenter> ListAttendee { get; set; }
        public List<Presenter> ListPresenter { get; set; }
    }

    public class NewChannel
    {
        public string CREATED_UserName { get; set; }
        public string AVATAR_PICTURE_FILENAME { get; set; }
        public string MESSAGING_GROUP_NAME { get; set; }
        public string MESSAGING_GROUP_NAME_EN { get; set; }
        public decimal CONFERENCE_ID { get; set; }
        public string PUBLIC_OR_PRIVATE_GROUP { get; set; }
        public List<MessageGroupMember> MEMBERS { get; set; }
    }

    public class MessageGroupMember
    {
        public string UserName { get; set; }
        public string NOTE { get; set; }
    }

    public class Group
    {
        public decimal MESSAGING_GROUP_ID { get; set; }
        public string MESSAGING_GROUP_NAME { get; set; }
        public string MESSAGING_GROUP_NAME_EN { get; set; }
        public string AVATAR_PICTURE_FILENAME { get; set; }
        public string CREATED_UserName { get; set; }
        public DateTime? CREATED_DATETIME { get; set; }
        public object MEMBERS { get; set; }
    }
}
