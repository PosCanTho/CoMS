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
            }else if (isFollow)
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
        [Route("api/ListFollow")]
        public HttpResponseMessage ListFollow(string FOLLOWED_UserName, int conferenceId)
        {
            try
            {
                var followers = from f in db.FOLLOWER_RELATIONSHIP
                                join a in db.ACCOUNTs on f.FOLLOWING_UserName equals a.UserName
                                where f.FOLLOWED_UserName == FOLLOWED_UserName && f.CONFERENCE_ID == conferenceId
                                select new
                                {
                                    a.PERSON_ID,
                                    a.Image,

                                    f.FOLLOWING_UserName,
                                    f.FOLLOWING_CURRENT_FIRST_NAME,
                                    f.FOLLOWING_CURRENT_MIDDLE_NAME,
                                    f.FOLLOWING_CURRENT_LAST_NAME
                                };
                return ResponseSuccess(StringResource.Success, followers.Distinct().ToList());
            }
            catch
            {
                return ResponseFail(StringResource.Can_not_unfollow);
            }
        }

        [HttpGet]
        [Route("api/ListFollowMe")]
        public HttpResponseMessage ListFollowMe(string FOLLOWING_UserName, int conferenceId)
        {
            try
            {
                var followers = from f in db.FOLLOWER_RELATIONSHIP
                                join a in db.ACCOUNTs on f.FOLLOWING_UserName equals a.UserName
                                where f.FOLLOWING_UserName == FOLLOWING_UserName && f.CONFERENCE_ID == conferenceId
                                select new
                                {
                                    a.PERSON_ID,
                                    a.Image,

                                    f.FOLLOWED_UserName,
                                    f.FOLLOWED_CURRENT_FIRST_NAME,
                                    f.FOLLOWED_CURRENT_MIDDLE_NAME,
                                    f.FOLLOWED_CURRENT_LAST_NAME
                                };
                return ResponseSuccess(StringResource.Success, followers.Distinct().ToList());
            }
            catch
            {
                return ResponseFail(StringResource.Can_not_unfollow);
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
