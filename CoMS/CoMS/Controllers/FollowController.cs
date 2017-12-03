using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Resources;
using CoMS.Entities_Framework;
using CoMS.Untils;
using CoMS.Models;

namespace CoMS.Controllers
{
    public class FollowController : BaseController
    {
        private DB db = new DB();

        [HttpPost]
        [Route("api/Follow")]
        public HttpResponseMessage Follow(string FOLLOWED_UserName,string FOLLOWING_UserName, int conferenceId)
        {
            if(FOLLOWED_UserName == FOLLOWING_UserName)
            {
                return ResponseFail(StringResource.You_can_not_follow_yourself);
            }
            else
            {
                var account_followed = db.ACCOUNTs.SingleOrDefault(x => x.UserName == FOLLOWED_UserName);
                var account_following = db.ACCOUNTs.SingleOrDefault(x => x.UserName == FOLLOWING_UserName);
                var conference = db.CONFERENCEs.SingleOrDefault(x => x.CONFERENCE_ID == conferenceId);
                var isFollow = new FollowModel().CheckFollow(FOLLOWED_UserName, FOLLOWING_UserName, conferenceId);
                if (account_followed == null || account_following == null)
                {
                    return ResponseFail(StringResource.Account_does_not_exist);
                }
                else if (conference == null)
                {
                    return ResponseFail(StringResource.Conference_do_not_exist);
                }
                else if (isFollow)
                {
                    return ResponseSuccess(StringResource.Follow_is_exist);
                }
                else
                {
                    var follower = new FOLLOWER_RELATIONSHIP();
                    follower.FOLLOWED_UserName = FOLLOWED_UserName;
                    follower.FOLLOWED_CURRENT_LAST_NAME = account_followed.CURRENT_LAST_NAME;
                    follower.FOLLOWED_CURRENT_FIRST_NAME = account_followed.CURRENT_FIRST_NAME;
                    follower.FOLLOWED_CURRENT_MIDDLE_NAME = account_followed.CURRENT_MIDDLE_NAME;
                    follower.FOLLOWING_UserName = FOLLOWING_UserName;
                    follower.FOLLOWING_CURRENT_LAST_NAME = account_following.CURRENT_LAST_NAME;
                    follower.FOLLOWING_CURRENT_FIRST_NAME = account_following.CURRENT_FIRST_NAME;
                    follower.FOLLOWING_CURRENT_MIDDLE_NAME = account_following.CURRENT_MIDDLE_NAME;
                    follower.FROM_DATE = DateTime.Now;
                    follower.CONFERENCE_ID = conferenceId;
                    follower.CONFERENCE_NAME = conference.CONFERENCE_NAME;
                    follower.CONFERENCE_NAME_EN = conference.CONFERENCE_NAME_EN;

                    try
                    {
                        db.FOLLOWER_RELATIONSHIP.Add(follower);
                        db.SaveChanges();
                        return ResponseSuccess(StringResource.Success);
                    }
                    catch
                    {
                        return ResponseFail(StringResource.Can_not_follow);
                    }
                }
            }
        }


        [HttpPost]
        [Route("api/UnFollow")]
        public HttpResponseMessage UnFollow(string FOLLOWED_UserName, string FOLLOWING_UserName, int conferenceId)
        {
            try
            {
                var follower = db.FOLLOWER_RELATIONSHIP.Where(x => x.FOLLOWED_UserName == FOLLOWED_UserName && x.FOLLOWING_UserName == FOLLOWING_UserName && x.CONFERENCE_ID == conferenceId);
                db.FOLLOWER_RELATIONSHIP.RemoveRange(follower);
                db.SaveChanges();
                return ResponseSuccess(StringResource.Success);
            }
            catch
            {
                return ResponseFail(StringResource.Can_not_unfollow);
            }
        }

        [HttpGet]
        [Route("api/ListFollowing")]
        public HttpResponseMessage ListFollowing(string FOLLOWED_UserName, int conferenceId)
        {
            try
            {
                var model = new AccountModel();
                var followers = (from f in db.FOLLOWER_RELATIONSHIP
                                 join a in db.ACCOUNTs on f.FOLLOWING_UserName equals a.UserName
                                 where f.FOLLOWED_UserName == FOLLOWED_UserName && f.CONFERENCE_ID == conferenceId select new { f, a })
                                .AsEnumerable()
                                .OrderByDescending(x => x.f.FROM_DATE)
                                .Select(x => new
                                {
                                    x.a.PERSON_ID,
                                    Image = model.GetUserByUserName(x.f.FOLLOWING_UserName).Image,

                                    x.f.FOLLOWING_UserName,
                                    x.f.FOLLOWING_CURRENT_FIRST_NAME,
                                    x.f.FOLLOWING_CURRENT_MIDDLE_NAME,
                                    x.f.FOLLOWING_CURRENT_LAST_NAME,
                                    CURRENT_HOME_ORGANIZATION_NAME = model.GetUserByUserName(x.f.FOLLOWING_UserName).CURRENT_HOME_ORGANIZATION_NAME,
                                    CURRENT_HOME_ORGANIZATION_NAME_EN = model.GetUserByUserName(x.f.FOLLOWING_UserName).CURRENT_HOME_ORGANIZATION_NAME_EN
                                });
                return ResponseSuccess(StringResource.Success, followers.Distinct().ToList());
            }
            catch
            {
                return ResponseFail(StringResource.Can_not_get_list_following);
            }
        }

        [HttpGet]
        [Route("api/ListFollowingOfAttendee")]
        public HttpResponseMessage ListFollowingOfAttendee(string userLogin, string FOLLOWED_UserName, int conferenceId)
        {
            try
            {
                var model = new AccountModel();
                var followers = (from f in db.FOLLOWER_RELATIONSHIP
                                join a in db.ACCOUNTs on f.FOLLOWING_UserName equals a.UserName
                                where f.FOLLOWED_UserName == FOLLOWED_UserName && f.CONFERENCE_ID == conferenceId
                                 select new {f,a})
                                .AsEnumerable()
                                .OrderByDescending(x => x.f.FROM_DATE)
                                .Select(x => new
                                {
                                    x.a.PERSON_ID,
                                    Image = model.GetUserByUserName(x.f.FOLLOWING_UserName).Image,

                                    x.f.FOLLOWING_UserName,
                                    x.f.FOLLOWING_CURRENT_FIRST_NAME,
                                    x.f.FOLLOWING_CURRENT_MIDDLE_NAME,
                                    x.f.FOLLOWING_CURRENT_LAST_NAME,
                                    IS_FOLLOW = new FollowModel().CheckFollow(userLogin, x.f.FOLLOWING_UserName, conferenceId),
                                    CURRENT_HOME_ORGANIZATION_NAME = model.GetUserByUserName(x.f.FOLLOWING_UserName).CURRENT_HOME_ORGANIZATION_NAME,
                                    CURRENT_HOME_ORGANIZATION_NAME_EN = model.GetUserByUserName(x.f.FOLLOWING_UserName).CURRENT_HOME_ORGANIZATION_NAME_EN
                                });
                return ResponseSuccess(StringResource.Success, followers.Distinct().ToList());
            }
            catch
            {
                return ResponseFail(StringResource.Can_not_get_list_following);
            }
        }

        [HttpGet]
        [Route("api/ListFollowers")]
        public HttpResponseMessage ListFollowers(string FOLLOWING_UserName, int conferenceId)
        {
            try
            {
                var model = new AccountModel();
                var followers = (from f in db.FOLLOWER_RELATIONSHIP
                                join a in db.ACCOUNTs on f.FOLLOWING_UserName equals a.UserName
                                where f.FOLLOWING_UserName == FOLLOWING_UserName && f.CONFERENCE_ID == conferenceId
                                select new { f, a})
                                .AsEnumerable()
                                .OrderByDescending(x => x.f.FROM_DATE)
                                .Select(x => new
                                {
                                    PERSON_ID = model.GetUserByUserName(x.f.FOLLOWED_UserName).PERSON_ID,
                                    Image = model.GetUserByUserName(x.f.FOLLOWED_UserName).Image,

                                    x.f.FOLLOWED_UserName,
                                    x.f.FOLLOWED_CURRENT_FIRST_NAME,
                                    x.f.FOLLOWED_CURRENT_MIDDLE_NAME,
                                    x.f.FOLLOWED_CURRENT_LAST_NAME,
                                    IS_FOLLOW = new FollowModel().CheckFollow(FOLLOWING_UserName, x.f.FOLLOWED_UserName, conferenceId),
                                    CURRENT_HOME_ORGANIZATION_NAME = model.GetUserByUserName(x.f.FOLLOWING_UserName).CURRENT_HOME_ORGANIZATION_NAME,
                                    CURRENT_HOME_ORGANIZATION_NAME_EN = model.GetUserByUserName(x.f.FOLLOWING_UserName).CURRENT_HOME_ORGANIZATION_NAME_EN
                                });
                return ResponseSuccess(StringResource.Success, followers.Distinct().ToList());
            }
            catch
            {
                return ResponseFail(StringResource.Can_not_get_list_followers);
            }
        }

        [HttpGet]
        [Route("api/ListFollowersOfAttendee")]
        public HttpResponseMessage ListFollowersOfAttendee(string userLogin, string FOLLOWING_UserName, int conferenceId)
        {
            try
            {
                var model = new AccountModel();
                var followers = (from f in db.FOLLOWER_RELATIONSHIP
                                join a in db.ACCOUNTs on f.FOLLOWING_UserName equals a.UserName
                                where f.FOLLOWING_UserName == FOLLOWING_UserName && f.CONFERENCE_ID == conferenceId
                                 select new { f, a })
                                .AsEnumerable()
                                .OrderByDescending(x => x.f.FROM_DATE)
                                .Select(x => new
                                {
                                    PERSON_ID = model.GetUserByUserName(x.f.FOLLOWED_UserName).PERSON_ID,
                                    Image = model.GetUserByUserName(x.f.FOLLOWED_UserName).Image,

                                    x.f.FOLLOWED_UserName,
                                    x.f.FOLLOWED_CURRENT_FIRST_NAME,
                                    x.f.FOLLOWED_CURRENT_MIDDLE_NAME,
                                    x.f.FOLLOWED_CURRENT_LAST_NAME,
                                    IS_FOLLOW = new FollowModel().CheckFollow(userLogin, x.f.FOLLOWED_UserName, conferenceId),
                                    CURRENT_HOME_ORGANIZATION_NAME = model.GetUserByUserName(x.f.FOLLOWING_UserName).CURRENT_HOME_ORGANIZATION_NAME,
                                    CURRENT_HOME_ORGANIZATION_NAME_EN = model.GetUserByUserName(x.f.FOLLOWING_UserName).CURRENT_HOME_ORGANIZATION_NAME_EN
                                });
                return ResponseSuccess(StringResource.Success, followers.Distinct().ToList());
            }
            catch
            {
                return ResponseFail(StringResource.Can_not_get_list_followers);
            }
        }

        [HttpPost]
        [Route("api/CheckFollow")]
        public HttpResponseMessage CheckFollow(string FOLLOWED_UserName, string FOLLOWING_UserName, int conferenceId)
        {
            try
            {
                var follower = db.FOLLOWER_RELATIONSHIP.Where(x => x.FOLLOWED_UserName == FOLLOWED_UserName && x.FOLLOWING_UserName == FOLLOWING_UserName && x.CONFERENCE_ID == conferenceId).ToList();
                if (follower.Count > 0)
                {
                    return ResponseSuccess(StringResource.Success);
                }
                else
                {
                    return ResponseFail(StringResource.Not_found);
                }
            }
            catch
            {
                return ResponseFail(StringResource.Not_found);
            }
        }
    }

    
}
