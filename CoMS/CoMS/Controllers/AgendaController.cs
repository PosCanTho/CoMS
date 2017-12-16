using CoMS.Entities_Framework;
using CoMS.Models;
using CoMS.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoMS.Controllers
{
    public class AgendaController : BaseController
    {
        private DB db = new DB();

        [HttpGet]
        [Route("api/SelectedAgenda")]
        public HttpResponseMessage SelectedAgenda(int conferenceId, string userName)
        {
            var listAgenda = new List<MyAgenda>();
            var selected = db.SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA.SingleOrDefault(x => x.CONFERENCE_ID == conferenceId && x.UserName == userName);

            if (selected == null)
            {
                var resultNew = new List<Agenda>();
                var listSessionNew = db.CONFERENCE_SESSION.Where(x => x.CONFERENCE_ID == conferenceId);
                foreach (var session in listSessionNew)
                {
                    var agenda = new Agenda();

                    agenda.CONFERENCE_SESSION_ID = session.CONFERENCE_SESSION_ID;
                    agenda.WALK_IN_OR_REGISTERED_SESSION = session.WALK_IN_OR_REGISTERED_SESSION;
                    agenda.CONFERENCE_SESSION_TOPIC_ID = session.CONFERENCE_SESSION_TOPIC_ID;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME = session.CONFERENCE_SESSION_TOPIC_NAME;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN = session.CONFERENCE_SESSION_TOPIC_NAME_EN;
                    agenda.CONFERENCE_SESSION_NAME = session.CONFERENCE_SESSION_NAME;
                    agenda.CONFERENCE_SESSION_NAME_EN = session.CONFERENCE_SESSION_NAME_EN;
                    agenda.CONFERENCE_ID = session.CONFERENCE_ID;
                    agenda.CONFERENCE_NAME = session.CONFERENCE_NAME;
                    agenda.CONFERENCE_NAME_EN = session.CONFERENCE_NAME_EN;
                    agenda.START_DATETIME = session.START_DATETIME;
                    agenda.END_DATETIME = session.END_DATETIME;
                    agenda.FACILITY_ID = session.FACILITY_ID;
                    agenda.FACILITY_NAME = session.FACILITY_NAME;
                    agenda.FACILITY_NAME_EN = session.FACILITY_NAME_EN;

                    agenda.SELECTED = false;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = "";

                    resultNew.Add(agenda);
                }

                if (resultNew != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, resultNew));
                }
                else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
            }

            else
            {
                if (selected.CONFERENCE_SESSION_ID_1 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_1;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_1;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_2 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_2;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_2;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_3 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_3;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_3;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_4 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_4;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_4;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_5 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_5;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_5;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_6 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_6;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_6;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_7 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_7;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_7;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_8 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_8;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_8;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_9 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_9;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_9;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_10 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_10;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_10;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_11 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_11;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_11;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_12 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_12;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_12;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_13 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_13;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_13;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_14 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_14;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_14;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_15 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_15;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_15;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_16 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_16;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_16;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_17 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_17;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_17;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_18 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_18;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_18;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_19 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_19;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_19;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_20 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_20;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_20;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_21 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_21;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_21;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_22 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_22;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_22;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_23 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_23;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_23;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_24 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_24;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_24;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_25 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_25;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_25;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_26 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_26;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_26;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_27 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_27;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_27;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_28 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_28;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_28;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_29 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_29;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_29;
                    listAgenda.Add(agenda);
                }
                if (selected.CONFERENCE_SESSION_ID_30 != null)
                {
                    var agenda = new MyAgenda();
                    agenda.CONFERENCE_SESSION_ID = selected.CONFERENCE_SESSION_ID_30;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_30;
                    listAgenda.Add(agenda);
                }

                Int32 index = 0;
                while (index < listAgenda.Count - 1)
                {
                    if (listAgenda[index].CONFERENCE_SESSION_ID == listAgenda[index + 1].CONFERENCE_SESSION_ID)
                        listAgenda.RemoveAt(index);
                    else
                        index++;
                }
                var result = new List<Agenda>();
                var listSession = db.CONFERENCE_SESSION.Where(x => x.CONFERENCE_ID == conferenceId);

                foreach (var session in listSession)
                {
                    if (listAgenda.Count > 0)
                    {
                        for (int i = 0; i < listAgenda.Count; i++)
                        {
                            var item = listAgenda[i];
                            if (session.CONFERENCE_SESSION_ID == item.CONFERENCE_SESSION_ID)
                            {
                                var agenda = new Agenda();
                                var acc = db.ACCOUNTs.SingleOrDefault(x => x.UserName == userName);

                                agenda.CONFERENCE_SESSION_ID = session.CONFERENCE_SESSION_ID;
                                agenda.WALK_IN_OR_REGISTERED_SESSION = session.WALK_IN_OR_REGISTERED_SESSION;
                                agenda.CONFERENCE_SESSION_TOPIC_ID = session.CONFERENCE_SESSION_TOPIC_ID;
                                agenda.CONFERENCE_SESSION_TOPIC_NAME = session.CONFERENCE_SESSION_TOPIC_NAME;
                                agenda.CONFERENCE_SESSION_TOPIC_NAME_EN = session.CONFERENCE_SESSION_TOPIC_NAME_EN;
                                agenda.CONFERENCE_SESSION_NAME = session.CONFERENCE_SESSION_NAME;
                                agenda.CONFERENCE_SESSION_NAME_EN = session.CONFERENCE_SESSION_NAME_EN;
                                agenda.CONFERENCE_ID = session.CONFERENCE_ID;
                                agenda.CONFERENCE_NAME = session.CONFERENCE_NAME;
                                agenda.CONFERENCE_NAME_EN = session.CONFERENCE_NAME_EN;
                                agenda.START_DATETIME = session.START_DATETIME;
                                agenda.END_DATETIME = session.END_DATETIME;
                                agenda.FACILITY_ID = session.FACILITY_ID;
                                agenda.FACILITY_NAME = session.FACILITY_NAME;
                                agenda.FACILITY_NAME_EN = session.FACILITY_NAME_EN;
                                agenda.DESCRIPTION = session.DESCRIPTION;
                                agenda.DESCRIPTION_EN = session.DESCRIPTION_EN;

                                agenda.SELECTED = true;
                                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = item.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                                agenda.PERSON_ID = acc.PERSON_ID;

                                result.Add(agenda);
                            }
                            else if (i == (listAgenda.Count - 1))
                            {
                                if (!result.Any(x => x.CONFERENCE_SESSION_ID == session.CONFERENCE_SESSION_ID))
                                {
                                    var agenda = new Agenda();

                                    agenda.CONFERENCE_SESSION_ID = session.CONFERENCE_SESSION_ID;
                                    agenda.WALK_IN_OR_REGISTERED_SESSION = session.WALK_IN_OR_REGISTERED_SESSION;
                                    agenda.CONFERENCE_SESSION_TOPIC_ID = session.CONFERENCE_SESSION_TOPIC_ID;
                                    agenda.CONFERENCE_SESSION_TOPIC_NAME = session.CONFERENCE_SESSION_TOPIC_NAME;
                                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN = session.CONFERENCE_SESSION_TOPIC_NAME_EN;
                                    agenda.CONFERENCE_SESSION_NAME = session.CONFERENCE_SESSION_NAME;
                                    agenda.CONFERENCE_SESSION_NAME_EN = session.CONFERENCE_SESSION_NAME_EN;
                                    agenda.CONFERENCE_ID = session.CONFERENCE_ID;
                                    agenda.CONFERENCE_NAME = session.CONFERENCE_NAME;
                                    agenda.CONFERENCE_NAME_EN = session.CONFERENCE_NAME_EN;
                                    agenda.START_DATETIME = session.START_DATETIME;
                                    agenda.END_DATETIME = session.END_DATETIME;
                                    agenda.FACILITY_ID = session.FACILITY_ID;
                                    agenda.FACILITY_NAME = session.FACILITY_NAME;
                                    agenda.FACILITY_NAME_EN = session.FACILITY_NAME_EN;

                                    agenda.SELECTED = false;
                                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = "";

                                    result.Add(agenda);
                                }
                            }
                        }
                    }
                    else
                    {
                        var agenda = new Agenda();

                        agenda.CONFERENCE_SESSION_ID = session.CONFERENCE_SESSION_ID;
                        agenda.WALK_IN_OR_REGISTERED_SESSION = session.WALK_IN_OR_REGISTERED_SESSION;
                        agenda.CONFERENCE_SESSION_TOPIC_ID = session.CONFERENCE_SESSION_TOPIC_ID;
                        agenda.CONFERENCE_SESSION_TOPIC_NAME = session.CONFERENCE_SESSION_TOPIC_NAME;
                        agenda.CONFERENCE_SESSION_TOPIC_NAME_EN = session.CONFERENCE_SESSION_TOPIC_NAME_EN;
                        agenda.CONFERENCE_SESSION_NAME = session.CONFERENCE_SESSION_NAME;
                        agenda.CONFERENCE_SESSION_NAME_EN = session.CONFERENCE_SESSION_NAME_EN;
                        agenda.CONFERENCE_ID = session.CONFERENCE_ID;
                        agenda.CONFERENCE_NAME = session.CONFERENCE_NAME;
                        agenda.CONFERENCE_NAME_EN = session.CONFERENCE_NAME_EN;
                        agenda.START_DATETIME = session.START_DATETIME;
                        agenda.END_DATETIME = session.END_DATETIME;
                        agenda.FACILITY_ID = session.FACILITY_ID;
                        agenda.FACILITY_NAME = session.FACILITY_NAME;
                        agenda.FACILITY_NAME_EN = session.FACILITY_NAME_EN;

                        agenda.SELECTED = false;
                        agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = "";

                        result.Add(agenda);
                    }
                }

                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result));
                }
                else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
            }
        }

        [HttpGet]
        [Route("api/SelectedAgendaWithUser")]
        public HttpResponseMessage SelectedAgendaWithUser(int conferenceId, string userName1, string userName2)
        {
            var listSession = db.CONFERENCE_SESSION.Where(x => x.CONFERENCE_ID == conferenceId);

            var listAgenda1 = new List<MyAgenda>();
            var selected1 = db.SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA.SingleOrDefault(x => x.CONFERENCE_ID == conferenceId && x.UserName == userName1);
            if (selected1 == null)
            {
                return ResponseSuccess(StringResource.Not_found);
            }
            if (selected1.CONFERENCE_SESSION_ID_1 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_1 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_1;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_1;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_2 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_2 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_2;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_2;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_3 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_3 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_3;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_3;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_4 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_4 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_4;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_4;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_5 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_5 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_5;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_5;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_6 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_6 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_6;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_6;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_7 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_7 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_7;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_7;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_8 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_8 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_8;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_8;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_9 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_9 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_9;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_9;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_10 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_10 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_10;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_10;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_11 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_11 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_11;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_11;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_12 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_12 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_12;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_12;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_13 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_12 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_13;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_13;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_14 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_14 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_14;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_14;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_15 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_15 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_15;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_15;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_16 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_16 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_16;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_16;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_17 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_17 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_17;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_17;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_18 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_18 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_18;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_18;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_19 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_19 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_19;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_19;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_20 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_20 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_20;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_20;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_21 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_21 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_21;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_21;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_22 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_22 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_22;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_22;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_23 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_23 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_23;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_23;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_24 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_24 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_24;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_24;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_25 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_25 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_25;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_25;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_26 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_26 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_26;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_26;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_27 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_27 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_27;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_27;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_28 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_28 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_28;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_28;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_29 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_29 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_29;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_29;
                listAgenda1.Add(agenda);
            }
            if (selected1.CONFERENCE_SESSION_ID_30 != null && selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_30 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected1.CONFERENCE_SESSION_ID_30;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_30;
                listAgenda1.Add(agenda);
            }

            Int32 index1 = 0;
            while (index1 < listAgenda1.Count - 1)
            {
                if (listAgenda1[index1].CONFERENCE_SESSION_ID == listAgenda1[index1 + 1].CONFERENCE_SESSION_ID)
                    listAgenda1.RemoveAt(index1);
                else
                    index1++;
            }
            var result1 = new List<Agenda>();

            foreach (var session in listSession)
            {
                for (int i = 0; i < listAgenda1.Count; i++)
                {
                    var item = listAgenda1[i];
                    if (session.CONFERENCE_SESSION_ID == item.CONFERENCE_SESSION_ID)
                    {
                        var agenda = new Agenda();
                        var acc = db.ACCOUNTs.SingleOrDefault(x => x.UserName == userName1);

                        agenda.CONFERENCE_SESSION_ID = session.CONFERENCE_SESSION_ID;
                        agenda.WALK_IN_OR_REGISTERED_SESSION = session.WALK_IN_OR_REGISTERED_SESSION;
                        agenda.CONFERENCE_SESSION_TOPIC_ID = session.CONFERENCE_SESSION_TOPIC_ID;
                        agenda.CONFERENCE_SESSION_TOPIC_NAME = session.CONFERENCE_SESSION_TOPIC_NAME;
                        agenda.CONFERENCE_SESSION_TOPIC_NAME_EN = session.CONFERENCE_SESSION_TOPIC_NAME_EN;
                        agenda.CONFERENCE_SESSION_NAME = session.CONFERENCE_SESSION_NAME;
                        agenda.CONFERENCE_SESSION_NAME_EN = session.CONFERENCE_SESSION_NAME_EN;
                        agenda.CONFERENCE_ID = session.CONFERENCE_ID;
                        agenda.CONFERENCE_NAME = session.CONFERENCE_NAME;
                        agenda.CONFERENCE_NAME_EN = session.CONFERENCE_NAME_EN;
                        agenda.START_DATETIME = session.START_DATETIME;
                        agenda.END_DATETIME = session.END_DATETIME;
                        agenda.FACILITY_ID = session.FACILITY_ID;
                        agenda.FACILITY_NAME = session.FACILITY_NAME;
                        agenda.FACILITY_NAME_EN = session.FACILITY_NAME_EN;
                        agenda.DESCRIPTION = session.DESCRIPTION;
                        agenda.DESCRIPTION_EN = session.DESCRIPTION_EN;

                        agenda.SELECTED = true;
                        agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = item.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        agenda.PERSON_ID = acc.PERSON_ID;

                        result1.Add(agenda);
                    }
                }
            }

            /////////////////////////////

            var listAgenda2 = new List<MyAgenda>();
            var selected2 = db.SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA.SingleOrDefault(x => x.CONFERENCE_ID == conferenceId && x.UserName == userName2);

            if (selected2 == null)
            {
                if (result1 != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result1));
                }
                else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
            }
            if (selected2.CONFERENCE_SESSION_ID_1 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_1 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_1;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_1;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_2 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_2 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_2;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_2;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_3 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_3 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_3;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_3;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_4 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_4 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_4;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_4;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_5 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_5 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_5;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_5;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_6 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_6 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_6;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_6;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_7 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_7 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_7;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_7;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_8 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_8 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_8;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_8;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_9 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_9 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_9;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_9;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_10 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_10 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_10;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_10;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_11 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_11 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_11;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_11;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_12 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_12 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_12;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_12;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_13 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_12 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_13;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_13;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_14 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_14 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_14;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_14;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_15 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_15 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_15;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_15;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_16 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_16 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_16;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_16;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_17 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_17 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_17;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_17;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_18 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_18 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_18;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_18;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_19 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_19 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_19;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_19;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_20 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_20 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_20;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_20;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_21 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_21 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_21;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_21;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_22 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_22 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_22;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_22;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_23 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_23 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_23;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_23;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_24 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_24 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_24;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_24;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_25 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_25 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_25;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_25;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_26 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_26 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_26;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_26;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_27 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_27 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_27;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_27;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_28 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_28 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_28;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_28;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_29 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_29 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_29;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_29;
                listAgenda2.Add(agenda);
            }
            if (selected2.CONFERENCE_SESSION_ID_30 != null && selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_30 != null)
            {
                var agenda = new MyAgenda();
                agenda.CONFERENCE_SESSION_ID = selected2.CONFERENCE_SESSION_ID_30;
                agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = selected2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_30;
                listAgenda2.Add(agenda);
            }

            Int32 index2 = 0;
            while (index2 < listAgenda2.Count - 1)
            {
                if (listAgenda2[index2].CONFERENCE_SESSION_ID == listAgenda2[index2 + 1].CONFERENCE_SESSION_ID)
                    listAgenda2.RemoveAt(index2);
                else
                    index2++;
            }
            var result2 = new List<Agenda>();

            foreach (var session in listSession)
            {
                for (int i = 0; i < listAgenda2.Count; i++)
                {
                    var item = listAgenda2[i];
                    if (session.CONFERENCE_SESSION_ID == item.CONFERENCE_SESSION_ID)
                    {
                        var agenda = new Agenda();
                        var acc = db.ACCOUNTs.SingleOrDefault(x => x.UserName == userName2);

                        agenda.CONFERENCE_SESSION_ID = session.CONFERENCE_SESSION_ID;
                        agenda.WALK_IN_OR_REGISTERED_SESSION = session.WALK_IN_OR_REGISTERED_SESSION;
                        agenda.CONFERENCE_SESSION_TOPIC_ID = session.CONFERENCE_SESSION_TOPIC_ID;
                        agenda.CONFERENCE_SESSION_TOPIC_NAME = session.CONFERENCE_SESSION_TOPIC_NAME;
                        agenda.CONFERENCE_SESSION_TOPIC_NAME_EN = session.CONFERENCE_SESSION_TOPIC_NAME_EN;
                        agenda.CONFERENCE_SESSION_NAME = session.CONFERENCE_SESSION_NAME;
                        agenda.CONFERENCE_SESSION_NAME_EN = session.CONFERENCE_SESSION_NAME_EN;
                        agenda.CONFERENCE_ID = session.CONFERENCE_ID;
                        agenda.CONFERENCE_NAME = session.CONFERENCE_NAME;
                        agenda.CONFERENCE_NAME_EN = session.CONFERENCE_NAME_EN;
                        agenda.START_DATETIME = session.START_DATETIME;
                        agenda.END_DATETIME = session.END_DATETIME;
                        agenda.FACILITY_ID = session.FACILITY_ID;
                        agenda.FACILITY_NAME = session.FACILITY_NAME;
                        agenda.FACILITY_NAME_EN = session.FACILITY_NAME_EN;
                        agenda.DESCRIPTION = session.DESCRIPTION;
                        agenda.DESCRIPTION_EN = session.DESCRIPTION_EN;

                        agenda.SELECTED = true;
                        agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = item.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        agenda.PERSON_ID = acc.PERSON_ID;

                        result2.Add(agenda);
                    }
                }
            }
            
            foreach (var rs1 in result1)
            {
                foreach (var rs2 in result2)
                {
                    if (rs2.CONFERENCE_SESSION_ID == rs1.CONFERENCE_SESSION_ID)
                    {
                        rs1.SELECTED = true;
                        rs1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = rs2.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        break;
                    } else
                    {
                        rs1.SELECTED = false;
                        rs1.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION = "";

                    }
                }
            }

                if (result1 != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(0, StringResource.Success, result1));
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, new ResponseData(404, StringResource.Username_or_password_incorrect, null)); }
        }

        [HttpPost]
        [Route("api/AddSelectedAgenda")]
        public HttpResponseMessage AddSelectedAgenda([FromBody]AddAgenda request)
        {
            try
            {
                var agenda = db.SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA.SingleOrDefault(x => x.CONFERENCE_ID == request.CONFERENCE_ID && x.UserName == request.USER_NAME);

                if (agenda == null)
                {
                    var conference = db.CONFERENCEs.SingleOrDefault(x => x.CONFERENCE_ID == request.CONFERENCE_ID);

                    SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA selected = new SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA
                    {
                        UserName = request.USER_NAME,
                        CONFERENCE_ID = request.CONFERENCE_ID,
                        CONFERENCE_NAME = conference.CONFERENCE_NAME,
                        CONFERENCE_NAME_EN = conference.CONFERENCE_NAME_EN,

                        CONFERENCE_SESSION_ID_1 = request.CONFERENCE_SESSION_ID,
                        CONFERENCE_SESSION_TOPIC_NAME_1 = request.CONFERENCE_SESSION_TOPIC_NAME,
                        CONFERENCE_SESSION_TOPIC_NAME_EN_1 = request.CONFERENCE_SESSION_TOPIC_NAME_EN,
                        CONFERENCE_SESSION_NAME_1 = request.CONFERENCE_SESSION_NAME,
                        CONFERENCE_SESSION_NAME_EN_1 = request.CONFERENCE_SESSION_NAME_EN,
                        START_DATETIME_1 = Convert.ToDateTime(request.START_DATETIME),
                        END_DATETIME_1 = Convert.ToDateTime(request.END_DATETIME),
                        FACILITY_ID_1 = request.FACILITY_ID,
                        FACILITY_NAME_1 = request.FACILITY_NAME,
                        FACILITY_NAME_EN_1 = request.FACILITY_NAME_EN,
                        MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_1 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION
                    };
                    db.SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA.Add(selected);
                    db.SaveChanges();

                    return ResponseSuccess(StringResource.Success, request);
                }
                else
                {
                    var id = request.CONFERENCE_SESSION_ID;
                    if (id == agenda.CONFERENCE_SESSION_ID_1 || id == agenda.CONFERENCE_SESSION_ID_2 || id == agenda.CONFERENCE_SESSION_ID_3 || id == agenda.CONFERENCE_SESSION_ID_4 || id == agenda.CONFERENCE_SESSION_ID_5 || id == agenda.CONFERENCE_SESSION_ID_6 || id == agenda.CONFERENCE_SESSION_ID_7 || id == agenda.CONFERENCE_SESSION_ID_8 || id == agenda.CONFERENCE_SESSION_ID_9 || id == agenda.CONFERENCE_SESSION_ID_10 || id == agenda.CONFERENCE_SESSION_ID_11 || id == agenda.CONFERENCE_SESSION_ID_12 || id == agenda.CONFERENCE_SESSION_ID_13 || id == agenda.CONFERENCE_SESSION_ID_14 || id == agenda.CONFERENCE_SESSION_ID_15 || id == agenda.CONFERENCE_SESSION_ID_16 || id == agenda.CONFERENCE_SESSION_ID_17 || id == agenda.CONFERENCE_SESSION_ID_18 || id == agenda.CONFERENCE_SESSION_ID_19 || id == agenda.CONFERENCE_SESSION_ID_20 || id == agenda.CONFERENCE_SESSION_ID_21 || id == agenda.CONFERENCE_SESSION_ID_22 || id == agenda.CONFERENCE_SESSION_ID_23 || id == agenda.CONFERENCE_SESSION_ID_24 || id == agenda.CONFERENCE_SESSION_ID_25 || id == agenda.CONFERENCE_SESSION_ID_26 || id == agenda.CONFERENCE_SESSION_ID_27 || id == agenda.CONFERENCE_SESSION_ID_28 || id == agenda.CONFERENCE_SESSION_ID_29 || id == agenda.CONFERENCE_SESSION_ID_30)
                    {
                        return ResponseFail(StringResource.Sorry_an_error_has_occurred);
                    }
                    else
                    {
                        if (agenda.CONFERENCE_SESSION_ID_1 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_1 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_1 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_1 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_1 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_1 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_1 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_1 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_1 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_1 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_1 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_1 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_2 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_2 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_2 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_2 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_2 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_2 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_2 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_2 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_2 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_2 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_2 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_2 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_3 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_3 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_3 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_3 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_3 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_3 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_3 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_3 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_3 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_3 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_3 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_3 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_4 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_4 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_4 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_4 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_4 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_4 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_4 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_4 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_4 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_4 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_4 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_4 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_5 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_5 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_5 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_5 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_5 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_5 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_5 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_5 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_5 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_5 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_5 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_5 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_6 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_6 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_6 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_6 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_6 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_6 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_6 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_6 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_6 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_6 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_6 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_6 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_7 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_7 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_7 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_7 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_7 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_7 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_7 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_7 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_7 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_7 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_7 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_7 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_8 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_8 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_8 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_8 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_8 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_8 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_8 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_8 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_8 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_8 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_8 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_8 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_9 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_9 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_9 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_9 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_9 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_9 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_9 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_9 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_9 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_9 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_9 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_9 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_10 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_10 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_10 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_10 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_10 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_10 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_10 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_10 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_10 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_10 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_10 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_10 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_11 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_11 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_11 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_11 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_11 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_11 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_11 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_11 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_11 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_11 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_11 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_11 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_12 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_12 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_12 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_12 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_12 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_12 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_12 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_12 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_12 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_12 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_12 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_12 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_13 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_13 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_13 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_13 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_13 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_13 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_13 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_13 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_13 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_13 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_13 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_13 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_14 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_14 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_14 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_14 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_14 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_14 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_14 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_14 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_14 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_14 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_14 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_14 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_15 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_15 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_15 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_15 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_15 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_15 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_15 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_15 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_15 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_15 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_15 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_15 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_16 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_16 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_16 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_16 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_16 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_16 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_16 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_16 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_16 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_16 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_16 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_16 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_17 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_17 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_17 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_17 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_17 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_17 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_17 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_17 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_17 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_17 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_17 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_17 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_18 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_18 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_18 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_18 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_18 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_18 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_18 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_18 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_18 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_18 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_18 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_18 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_19 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_19 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_19 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_19 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_19 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_19 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_19 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_19 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_19 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_19 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_19 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_19 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_20 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_20 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_20 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_20 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_20 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_20 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_20 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_20 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_20 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_20 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_20 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_20 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_21 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_21 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_21 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_21 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_21 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_21 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_21 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_21 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_21 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_21 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_21 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_21 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_22 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_22 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_22 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_22 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_22 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_22 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_22 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_22 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_22 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_22 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_22 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_22 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_23 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_23 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_23 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_23 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_23 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_23 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_23 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_23 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_23 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_23 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_23 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_23 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_24 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_24 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_24 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_24 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_24 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_24 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_24 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_24 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_24 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_24 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_24 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_24 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_25 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_25 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_25 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_25 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_25 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_25 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_25 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_25 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_25 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_25 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_25 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_25 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_26 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_26 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_26 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_26 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_26 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_26 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_26 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_26 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_26 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_26 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_26 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_26 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_27 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_27 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_27 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_27 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_27 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_27 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_27 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_27 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_27 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_27 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_27 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_27 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_28 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_28 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_28 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_28 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_28 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_28 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_28 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_28 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_28 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_28 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_28 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_28 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_29 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_29 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_29 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_29 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_29 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_29 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_29 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_29 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_29 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_29 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_29 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_29 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else if (agenda.CONFERENCE_SESSION_ID_30 == null)
                        {
                            agenda.CONFERENCE_SESSION_ID_30 = request.CONFERENCE_SESSION_ID;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_30 = request.CONFERENCE_SESSION_TOPIC_NAME;
                            agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_30 = request.CONFERENCE_SESSION_TOPIC_NAME_EN;
                            agenda.CONFERENCE_SESSION_NAME_30 = request.CONFERENCE_SESSION_NAME;
                            agenda.CONFERENCE_SESSION_NAME_EN_30 = request.CONFERENCE_SESSION_NAME_EN;
                            agenda.START_DATETIME_30 = Convert.ToDateTime(request.START_DATETIME);
                            agenda.END_DATETIME_30 = Convert.ToDateTime(request.END_DATETIME);
                            agenda.FACILITY_ID_30 = request.FACILITY_ID;
                            agenda.FACILITY_NAME_30 = request.FACILITY_NAME;
                            agenda.FACILITY_NAME_EN_30 = request.FACILITY_NAME_EN;
                            agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_30 = request.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION;
                        }
                        else
                        {
                            return ResponseFail(StringResource.Sorry_an_error_has_occurred);
                        }
                        db.SaveChanges();
                        return ResponseSuccess(StringResource.Success, request);
                    }
                }

            }
            catch
            {
                return ResponseFail(StringResource.Sorry_an_error_has_occurred);
            }
        }

        [HttpPost]
        [Route("api/RemoveSelectedAgenda")]
        public HttpResponseMessage RemoveSelectedAgenda([FromBody]RemoveAgenda request)
        {
            try
            {
                var agenda = db.SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA.SingleOrDefault(x => x.CONFERENCE_ID == request.CONFERENCE_ID && x.UserName == request.USER_NAME);
                var id = request.CONFERENCE_SESSION_ID;
                
                if (agenda.CONFERENCE_SESSION_ID_1 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_1 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_1 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_1 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_1 = null;
                    agenda.CONFERENCE_SESSION_NAME_1 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_1 = null;
                    agenda.START_DATETIME_1 = null;
                    agenda.END_DATETIME_1 = null;
                    agenda.FACILITY_ID_1 = null;
                    agenda.FACILITY_NAME_1 = null;
                    agenda.FACILITY_NAME_EN_1 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_1 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_2 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_2 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_2 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_2 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_2 = null;
                    agenda.CONFERENCE_SESSION_NAME_2 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_2 = null;
                    agenda.START_DATETIME_2 = null;
                    agenda.END_DATETIME_2 = null;
                    agenda.FACILITY_ID_2 = null;
                    agenda.FACILITY_NAME_2 = null;
                    agenda.FACILITY_NAME_EN_2 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_2 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_3 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_3 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_3 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_3 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_3 = null;
                    agenda.CONFERENCE_SESSION_NAME_3 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_3 = null;
                    agenda.START_DATETIME_3 = null;
                    agenda.END_DATETIME_3 = null;
                    agenda.FACILITY_ID_3 = null;
                    agenda.FACILITY_NAME_3 = null;
                    agenda.FACILITY_NAME_EN_3 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_3 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_4 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_4 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_4 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_4 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_4 = null;
                    agenda.CONFERENCE_SESSION_NAME_4 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_4 = null;
                    agenda.START_DATETIME_4 = null;
                    agenda.END_DATETIME_4 = null;
                    agenda.FACILITY_ID_4 = null;
                    agenda.FACILITY_NAME_4 = null;
                    agenda.FACILITY_NAME_EN_4 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_4 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_5 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_5 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_5 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_5 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_5 = null;
                    agenda.CONFERENCE_SESSION_NAME_5 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_5 = null;
                    agenda.START_DATETIME_5 = null;
                    agenda.END_DATETIME_5 = null;
                    agenda.FACILITY_ID_5 = null;
                    agenda.FACILITY_NAME_5 = null;
                    agenda.FACILITY_NAME_EN_5 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_5 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_6 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_6 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_6 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_6 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_6 = null;
                    agenda.CONFERENCE_SESSION_NAME_6 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_6 = null;
                    agenda.START_DATETIME_6 = null;
                    agenda.END_DATETIME_6 = null;
                    agenda.FACILITY_ID_6 = null;
                    agenda.FACILITY_NAME_6 = null;
                    agenda.FACILITY_NAME_EN_6 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_6 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_7 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_7 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_7 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_7 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_7 = null;
                    agenda.CONFERENCE_SESSION_NAME_7 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_7 = null;
                    agenda.START_DATETIME_7 = null;
                    agenda.END_DATETIME_7 = null;
                    agenda.FACILITY_ID_7 = null;
                    agenda.FACILITY_NAME_7 = null;
                    agenda.FACILITY_NAME_EN_7 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_7 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_8 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_8 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_8 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_8 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_8 = null;
                    agenda.CONFERENCE_SESSION_NAME_8 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_8 = null;
                    agenda.START_DATETIME_8 = null;
                    agenda.END_DATETIME_8 = null;
                    agenda.FACILITY_ID_8 = null;
                    agenda.FACILITY_NAME_8 = null;
                    agenda.FACILITY_NAME_EN_8 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_8 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_9 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_9 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_9 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_9 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_9 = null;
                    agenda.CONFERENCE_SESSION_NAME_9 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_9 = null;
                    agenda.START_DATETIME_9 = null;
                    agenda.END_DATETIME_9 = null;
                    agenda.FACILITY_ID_9 = null;
                    agenda.FACILITY_NAME_9 = null;
                    agenda.FACILITY_NAME_EN_9 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_9 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_10 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_10 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_10 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_10 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_10 = null;
                    agenda.CONFERENCE_SESSION_NAME_10 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_10 = null;
                    agenda.START_DATETIME_10 = null;
                    agenda.END_DATETIME_10 = null;
                    agenda.FACILITY_ID_10 = null;
                    agenda.FACILITY_NAME_10 = null;
                    agenda.FACILITY_NAME_EN_10 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_10 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_11 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_11 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_11 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_11 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_11 = null;
                    agenda.CONFERENCE_SESSION_NAME_11 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_11 = null;
                    agenda.START_DATETIME_11 = null;
                    agenda.END_DATETIME_11 = null;
                    agenda.FACILITY_ID_11 = null;
                    agenda.FACILITY_NAME_11 = null;
                    agenda.FACILITY_NAME_EN_11 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_11 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_12 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_12 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_12 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_12 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_12 = null;
                    agenda.CONFERENCE_SESSION_NAME_12 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_12 = null;
                    agenda.START_DATETIME_12 = null;
                    agenda.END_DATETIME_12 = null;
                    agenda.FACILITY_ID_12 = null;
                    agenda.FACILITY_NAME_12 = null;
                    agenda.FACILITY_NAME_EN_12 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_12 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_13 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_13 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_13 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_13 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_13 = null;
                    agenda.CONFERENCE_SESSION_NAME_13 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_13 = null;
                    agenda.START_DATETIME_13 = null;
                    agenda.END_DATETIME_13 = null;
                    agenda.FACILITY_ID_13 = null;
                    agenda.FACILITY_NAME_13 = null;
                    agenda.FACILITY_NAME_EN_13 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_13 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_14 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_14 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_14 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_14 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_14 = null;
                    agenda.CONFERENCE_SESSION_NAME_14 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_14 = null;
                    agenda.START_DATETIME_14 = null;
                    agenda.END_DATETIME_14 = null;
                    agenda.FACILITY_ID_14 = null;
                    agenda.FACILITY_NAME_14 = null;
                    agenda.FACILITY_NAME_EN_14 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_14 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_15 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_15 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_15 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_15 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_15 = null;
                    agenda.CONFERENCE_SESSION_NAME_15 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_15 = null;
                    agenda.START_DATETIME_15 = null;
                    agenda.END_DATETIME_15 = null;
                    agenda.FACILITY_ID_15 = null;
                    agenda.FACILITY_NAME_15 = null;
                    agenda.FACILITY_NAME_EN_15 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_15 = null;
                }
                else if(agenda.CONFERENCE_SESSION_ID_16 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_16 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_16 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_16 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_16 = null;
                    agenda.CONFERENCE_SESSION_NAME_16 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_16 = null;
                    agenda.START_DATETIME_16 = null;
                    agenda.END_DATETIME_16 = null;
                    agenda.FACILITY_ID_16 = null;
                    agenda.FACILITY_NAME_16 = null;
                    agenda.FACILITY_NAME_EN_16 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_16 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_17 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_17 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_17 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_17 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_17 = null;
                    agenda.CONFERENCE_SESSION_NAME_17 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_17 = null;
                    agenda.START_DATETIME_17 = null;
                    agenda.END_DATETIME_17 = null;
                    agenda.FACILITY_ID_17 = null;
                    agenda.FACILITY_NAME_17 = null;
                    agenda.FACILITY_NAME_EN_17 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_17 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_18 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_18 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_18 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_18 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_18 = null;
                    agenda.CONFERENCE_SESSION_NAME_18 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_18 = null;
                    agenda.START_DATETIME_18 = null;
                    agenda.END_DATETIME_18 = null;
                    agenda.FACILITY_ID_18 = null;
                    agenda.FACILITY_NAME_18 = null;
                    agenda.FACILITY_NAME_EN_18 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_18 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_19 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_19 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_19 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_19 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_19 = null;
                    agenda.CONFERENCE_SESSION_NAME_19 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_19 = null;
                    agenda.START_DATETIME_19 = null;
                    agenda.END_DATETIME_19 = null;
                    agenda.FACILITY_ID_19 = null;
                    agenda.FACILITY_NAME_19 = null;
                    agenda.FACILITY_NAME_EN_19 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_19 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_20 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_20 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_20 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_20 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_20 = null;
                    agenda.CONFERENCE_SESSION_NAME_20 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_20 = null;
                    agenda.START_DATETIME_20 = null;
                    agenda.END_DATETIME_20 = null;
                    agenda.FACILITY_ID_20 = null;
                    agenda.FACILITY_NAME_20 = null;
                    agenda.FACILITY_NAME_EN_20 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_20 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_21 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_21 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_21 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_21 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_21 = null;
                    agenda.CONFERENCE_SESSION_NAME_21 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_21 = null;
                    agenda.START_DATETIME_21 = null;
                    agenda.END_DATETIME_21 = null;
                    agenda.FACILITY_ID_21 = null;
                    agenda.FACILITY_NAME_21 = null;
                    agenda.FACILITY_NAME_EN_21 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_21 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_22 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_22 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_22 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_22 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_22 = null;
                    agenda.CONFERENCE_SESSION_NAME_22 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_22 = null;
                    agenda.START_DATETIME_22 = null;
                    agenda.END_DATETIME_22 = null;
                    agenda.FACILITY_ID_22 = null;
                    agenda.FACILITY_NAME_22 = null;
                    agenda.FACILITY_NAME_EN_22 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_22 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_23 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_23 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_23 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_23 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_23 = null;
                    agenda.CONFERENCE_SESSION_NAME_23 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_23 = null;
                    agenda.START_DATETIME_23 = null;
                    agenda.END_DATETIME_23 = null;
                    agenda.FACILITY_ID_23 = null;
                    agenda.FACILITY_NAME_23 = null;
                    agenda.FACILITY_NAME_EN_23 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_23 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_24 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_24 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_24 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_24 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_24 = null;
                    agenda.CONFERENCE_SESSION_NAME_24 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_24 = null;
                    agenda.START_DATETIME_24 = null;
                    agenda.END_DATETIME_24 = null;
                    agenda.FACILITY_ID_24 = null;
                    agenda.FACILITY_NAME_24 = null;
                    agenda.FACILITY_NAME_EN_24 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_24 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_25 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_25 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_25 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_25 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_25 = null;
                    agenda.CONFERENCE_SESSION_NAME_25 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_25 = null;
                    agenda.START_DATETIME_25 = null;
                    agenda.END_DATETIME_25 = null;
                    agenda.FACILITY_ID_25 = null;
                    agenda.FACILITY_NAME_25 = null;
                    agenda.FACILITY_NAME_EN_25 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_25 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_26 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_26 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_26 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_26 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_26 = null;
                    agenda.CONFERENCE_SESSION_NAME_26 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_26 = null;
                    agenda.START_DATETIME_26 = null;
                    agenda.END_DATETIME_26 = null;
                    agenda.FACILITY_ID_26 = null;
                    agenda.FACILITY_NAME_26 = null;
                    agenda.FACILITY_NAME_EN_26 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_26 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_27 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_27 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_27 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_27 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_27 = null;
                    agenda.CONFERENCE_SESSION_NAME_27 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_27 = null;
                    agenda.START_DATETIME_27 = null;
                    agenda.END_DATETIME_27 = null;
                    agenda.FACILITY_ID_27 = null;
                    agenda.FACILITY_NAME_27 = null;
                    agenda.FACILITY_NAME_EN_27 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_27 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_28 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_28 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_28 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_28 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_28 = null;
                    agenda.CONFERENCE_SESSION_NAME_28 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_28 = null;
                    agenda.START_DATETIME_28 = null;
                    agenda.END_DATETIME_28 = null;
                    agenda.FACILITY_ID_28 = null;
                    agenda.FACILITY_NAME_28 = null;
                    agenda.FACILITY_NAME_EN_28 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_28 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_29 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_29 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_29 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_29 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_29 = null;
                    agenda.CONFERENCE_SESSION_NAME_29 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_29 = null;
                    agenda.START_DATETIME_29 = null;
                    agenda.END_DATETIME_29 = null;
                    agenda.FACILITY_ID_29 = null;
                    agenda.FACILITY_NAME_29 = null;
                    agenda.FACILITY_NAME_EN_29 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_29 = null;
                }
                else if (agenda.CONFERENCE_SESSION_ID_30 == id && agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_30 == "SELF SELECTION")
                {
                    agenda.CONFERENCE_SESSION_ID_30 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_30 = null;
                    agenda.CONFERENCE_SESSION_TOPIC_NAME_EN_30 = null;
                    agenda.CONFERENCE_SESSION_NAME_30 = null;
                    agenda.CONFERENCE_SESSION_NAME_EN_30 = null;
                    agenda.START_DATETIME_30 = null;
                    agenda.END_DATETIME_30 = null;
                    agenda.FACILITY_ID_30 = null;
                    agenda.FACILITY_NAME_30 = null;
                    agenda.FACILITY_NAME_EN_30 = null;
                    agenda.MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_30 = null;
                }
                db.SaveChanges();
                return ResponseSuccess(StringResource.Success, request);
            }
            catch
            {
                return ResponseFail(StringResource.Sorry_an_error_has_occurred);
            }
        }

    }
    class MyAgenda
    {
        public decimal? CONFERENCE_SESSION_ID { get; set; }
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION { get; set; }
    }
    public class AddAgenda
    {
        public decimal CONFERENCE_ID { get; set; }
        public string USER_NAME { get; set; }
        public decimal CONFERENCE_SESSION_ID { get; set; }
        public string CONFERENCE_SESSION_TOPIC_NAME { get; set; }
        public string CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }
        public string CONFERENCE_SESSION_NAME { get; set; }
        public string CONFERENCE_SESSION_NAME_EN { get; set; }
        public string START_DATETIME { get; set; }
        public string END_DATETIME { get; set; }
        public decimal FACILITY_ID { get; set; }
        public string FACILITY_NAME { get; set; }
        public string FACILITY_NAME_EN { get; set; }
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION { get; set; }
    }

    public class RemoveAgenda
    {
        public decimal CONFERENCE_ID { get; set; }
        public string USER_NAME { get; set; }
        public decimal CONFERENCE_SESSION_ID { get; set; }
    }

    public class Agenda
    {
        public decimal CONFERENCE_SESSION_ID { get; set; }
        public string WALK_IN_OR_REGISTERED_SESSION { get; set; }
        public decimal? CONFERENCE_SESSION_TOPIC_ID { get; set; }
        public string CONFERENCE_SESSION_TOPIC_NAME { get; set; }
        public string CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }
        public string CONFERENCE_SESSION_NAME { get; set; }
        public string CONFERENCE_SESSION_NAME_EN { get; set; }
        public decimal CONFERENCE_ID { get; set; }
        public string CONFERENCE_NAME { get; set; }
        public string CONFERENCE_NAME_EN { get; set; }
        public DateTime? START_DATETIME { get; set; }
        public DateTime? END_DATETIME { get; set; }
        public decimal? FACILITY_ID { get; set; }
        public string FACILITY_NAME { get; set; }
        public string FACILITY_NAME_EN { get; set; }
        public string DESCRIPTION { get; set; }
        public string DESCRIPTION_EN { get; set; }

        public bool SELECTED { get; set; }
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION { get; set; }
        public decimal?  PERSON_ID { get; set; }
    }
}

