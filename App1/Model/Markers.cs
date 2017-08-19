using Android.Gms.Maps.Model;
using System.Collections.Generic;
using System.Linq;

namespace WAU.Model
{
    public class Markers
    {
        private MarkerOptions markerOptions { get; set; }
        private BitmapDescriptor Icon { get; set; }
        private LatLngDTO markerLocation { get; set; }
        private string title { get; set; }
        private string snippet { get; set; }


        public Markers(MarkerOptions mo)
        {
            markerOptions = mo;
            Icon = mo.Icon;
            markerLocation = LatLngDTO.ToLatLngDTO(mo.Position);
            title = mo.Title;
            snippet = mo.Snippet;
        }

        private static MarkerOptions ToMarkerOptions(Markers mark)
        {
            if (mark == null)
                return null;
            else
                return new MarkerOptions().SetIcon(mark.Icon).SetPosition(LatLngDTO.ToLatLng(mark.markerLocation)).SetTitle(mark.title).SetSnippet(mark.snippet);
        }
        private static Markers ToMarkers(MarkerOptions mo)
        {
            if (mo == null)
                return null;
            else
                return new Markers(mo);
        }
        public static List<MarkerOptions> ToMarkerOptionsList(List<Markers> markers)
        {
            if (markers == null)
                return null;
            else
                return markers.Select(a => ToMarkerOptions(a)).ToList();
        }
        public static List<Markers> ToMarkersList(List<MarkerOptions> moList)
        {
            if (moList == null)
                return null;
            else
                return moList.Select(a => ToMarkers(a)).ToList();
        }
    }
}