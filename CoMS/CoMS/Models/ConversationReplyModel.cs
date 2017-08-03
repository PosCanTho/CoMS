using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;
using PagedList;


namespace CoMS.Models
{
    public class ConversationReplyModel
    {
        private MYDB myDB;
        public ConversationReplyModel()
        {
            myDB = new MYDB();
        }

        public CONVERSATION_REPLY GetConversationById(decimal id)
        {
            return myDB.CONVERSATION_REPLY.Find(id);
        }

        public bool AddMessage(CONVERSATION_REPLY conversationReply)
        {
            try
            {
                var result = myDB.CONVERSATION_REPLY.Add(conversationReply);
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CONVERSATION_REPLY> ListMessage(decimal personIdFrom, decimal personIdTo, int page = 1, int pageSize = 10)
        {
            var listConversation = myDB.CONVERSATION_REPLY.Where(c => ((c.PERSON_ID_FROM == personIdFrom && c.PERSON_ID_TO == personIdTo) || (c.PERSON_ID_FROM == personIdTo && c.PERSON_ID_TO == personIdFrom)) && (c.PERSON_ID_DELETE != personIdFrom));
            return listConversation.OrderByDescending(c => c.TIME).ToPagedList(page, pageSize).ToList();
        }

        public List<CONVERSATION_REPLY> ListAllMessage(decimal personIdFrom, decimal personIdTo)
        {
            var listConversation = myDB.CONVERSATION_REPLY.Where(c => ((c.PERSON_ID_FROM == personIdFrom && c.PERSON_ID_TO == personIdTo) || (c.PERSON_ID_FROM == personIdTo && c.PERSON_ID_TO == personIdFrom)));
            return listConversation.ToList();
        }

        public bool UpdatePersonIdDelete(CONVERSATION_REPLY conversationReply)
        {
            try
            {
                var conversation = GetConversationById(conversationReply.CONVERSATION_REPLY_ID);
                conversation.CONVERSATION_REPLY_ID = conversationReply.CONVERSATION_REPLY_ID;
                conversation.MESSAGE = conversationReply.MESSAGE;
                conversation.TIME = conversationReply.TIME;
                conversation.PERSON_ID_FROM = conversationReply.PERSON_ID_FROM;
                conversation.PERSON_ID_TO = conversationReply.PERSON_ID_TO;
                conversation.PERSON_ID_DELETE = conversationReply.PERSON_ID_DELETE;
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteConversationReply(decimal conversationReplyId)
        {
            try
            {
                myDB.CONVERSATION_REPLY.Remove(GetConversationById(conversationReplyId));
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CONVERSATION_REPLY> ListConversation(decimal personId)
        {
            var listConversation = myDB.CONVERSATION_REPLY.Where(c => c.PERSON_ID_TO == personId || c.PERSON_ID_FROM == personId).ToList();
            var list = from c in listConversation group c by new { c.PERSON_ID_FROM, c.PERSON_ID_TO} into l select new CONVERSATION_REPLY { PERSON_ID_FROM = l.Key.PERSON_ID_FROM, PERSON_ID_TO = l.Key.PERSON_ID_TO};
            return list.ToList();
        }

        public CONVERSATION_REPLY GetConversationReplyLast(decimal personIdFrom, decimal personIdTo)
        {
            var c = ListAllMessage( personIdFrom,  personIdTo).Last();
            return c;
        }
    }
}