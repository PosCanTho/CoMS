using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;

namespace CoMS.Models
{
    public class ConferenceMapModel
    {
        private MYDB db;
        public ConferenceMapModel()
        {
            db = new MYDB();
        }

        public object ListConfereceMap(decimal conferenceId)
        {
            return db.Conference_Map.Where(x => x.CONFERENCE_ID == conferenceId).Select(x => new { x.CONFERENCE_MAP_ID, x.CONFERENCE_ID, x.CONFERENCE_NAME, x.CONFERENCE_NAME_EN, x.IMAGE, x.DESCRIPTION }).ToList();
        }

        public object ListConferenceLocation(decimal conferenceMapId)
        {
            return db.Conference_Location.Where(x => x.CONFERENCE_MAP_ID == conferenceMapId).Select(x => new { x.CONFERENCE_LOCATION_ID, x.CONFERENCE_MAP_ID, x.LOCATION_LAT, x.LOCATION_LONG, x.DESCRIPTION }).ToList();
        }
    }
}