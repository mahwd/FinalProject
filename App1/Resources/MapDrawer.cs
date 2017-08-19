using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using WAU;
using WAU.Data;
using WAU.Model;
using System.Collections.Generic;
using System.Linq;

namespace WAU.Resources
{
    public class MapDrawer
    {
        private Marker marker { get; set; }
        private MarkerOptions userMarker { get; set; }
        private List<Polyline> _cachedPolyline { get; set; } 
        private PolylineOptions _currentPolylineOptions { get; set; }


        public void PlaceUserMarker(LatLng markerPos,GoogleMap map)
        {
            marker?.Remove();
            marker = map.AddMarker(userMarker.SetPosition(markerPos));
        }


        public void PlaceRoute(List<LatLngDTO> CoordinateList,GoogleMap map)
        {
            ClearMap();
            _cachedPolyline.Add(map.AddPolyline(_currentPolylineOptions.Add(LatLngDTO.ToLatLngList(CoordinateList).ToArray())));
        }


        public void ClearMap()
        {
            _currentPolylineOptions.Points.Clear();
            foreach (var item in _cachedPolyline)
            {
                item.Remove();
            }
        }


        private void InitializeOptions()
        {
            userMarker = new MarkerOptions().SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.mapMarker)).SetTitle(GetData._user.name).SetSnippet(GetData._user.email);
            _cachedPolyline = new List<Polyline>();
            _currentPolylineOptions = new PolylineOptions().InvokeColor(Color.Green).InvokeWidth(10);
        }
        public MapDrawer()
        {
            InitializeOptions();
        }

        public void SetPolylineOptions(PolylineOptions po)
        {
            _currentPolylineOptions = po;
        }
    }
}