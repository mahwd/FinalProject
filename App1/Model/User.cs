using Newtonsoft.Json;
using System.Collections.Generic;

namespace WAU.Model
{
    public class Id
    {
        [JsonProperty(PropertyName = "$oid")]
        public string id { get; set; }
    }

    public class User
    {
        public Id _id { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public List<MapRoute> maproutes { get; set; }
        public List<Id> followers { get; set; }
        public string UserToken { get; set; }
    }
   
    public class MapRoute
    {
        public string RouteName{ get; set; }
        public List<LatLngDTO> RouteWayPoints { get; set; }
        public List<Markers> statusIcons { get; set; }
    }
}