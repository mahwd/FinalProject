using Android.App;
using Android.OS;
using Android.Gms.Maps;
using Android.Locations;
using System;
using Android.Runtime;
using WAU.Resources;
using Android.Gms.Maps.Model;
using Android.Content;
using System.Collections.Generic;
using WAU.Model;
using WAU.Data;
using Android.Widget;
using Android.Views;

namespace WAU
{
    [Activity(Label = "WAU", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : Activity,IOnMapReadyCallback, ILocationListener
    {
        public static Dictionary<string,string> ActivityPocket { get; set; }
        GoogleMap gmap { get; set; }
        static MainActivity _activity { get; set; }
        static User _user { get; set; }
        cameraMover cam { get; set; }
        private LocationManager _locationManager { get; set; }
        private string _provider { get; set; }
        private List<LatLngDTO> _waypoints { get; set; }
        private List<LatLngDTO> _cachedRoute { get; set; }
        private List<Markers> _statusIcons { get; set; }
        private MapDrawer drawer { get; set; }
        private LatLng currentPosition { get; set; }
        private Switch trackSwitch { get; set; }
        public bool isTracking { get; set; }
        public ImageButton tab1Button { get; private set; }
        public ImageButton tab2Button { get; private set; }
        public ImageButton tab3Button { get; private set; }
        public TextView headingText { get; private set; }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Toast.MakeText(this, "back", ToastLength.Short).Show();
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            gmap = googleMap;
            gmap.UiSettings.CompassEnabled = false;
            gmap.UiSettings.ZoomControlsEnabled = false;
            gmap.UiSettings.TiltGesturesEnabled = false;
            gmap.UiSettings.RotateGesturesEnabled = false;
            cam = new cameraMover();
            drawer = new MapDrawer();
            cam.Move(new LatLng(39,41),2,gmap);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);

            // map initiliazing
            setMap();

            _user = GetData._user;
            
            //  Instanciating data lists
            _waypoints = new List<LatLngDTO>();
            _statusIcons = new List<Markers>();
            _cachedRoute = new List<LatLngDTO>();



            // Tracking Switch
            trackSwitch = FindViewById<Switch>(Resource.Id.trackSwitch);
            trackSwitch.CheckedChange += TrackSwitch_CheckedChange;


            // Clear Button 
            FindViewById<Button>(Resource.Id.btnClear).Click += delegate 
            {
                drawer.ClearMap();
                _waypoints.Clear();
            };

        }



        public override void OnBackPressed()
        {
            base.OnBackPressed();
            Toast.MakeText(this,"back",ToastLength.Short).Show(); 
        }

        private void TrackSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
                isTracking = true;
            else
            {
                isTracking = false;
                _cachedRoute?.Clear();
                _cachedRoute = _waypoints;
                
            }
            if (!isTracking)
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSave saveDialog = new DialogSave(GetData._user, _waypoints);
                saveDialog.Show(transaction, "dialog fragment");  
            }
            //else if(_cachedRoute.Count <= 5)
            //{
            //    Toast.MakeText(this,"your route is too small",ToastLength.Long).Show();
            //}
        }

        #region    Map fragment initializiation

        private void setMap()
        {
            if (gmap == null)
            {
                var map = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.gMap);
                map.GetMapAsync(this);
                _locationManager = (LocationManager)GetSystemService(Context.LocationService);
                var criteria = new Criteria();
                criteria.PowerRequirement = Power.High;
                criteria.Accuracy = Accuracy.Coarse;
                criteria.SpeedAccuracy = Accuracy.Medium;
                _provider = _locationManager.GetBestProvider(criteria, true);
                Location location = _locationManager.GetLastKnownLocation(_provider);
                if (_locationManager.IsProviderEnabled(_provider))
                {
                    _locationManager.RequestLocationUpdates(_provider, 2000, 1, this);
                }
                else
                {
                    new Android.Support.V7.App.AlertDialog.Builder(this).SetMessage("Location Service isn't enabled!").Show();
                }
            }
        }
        #endregion

        public void OnLocationChanged(Location location)
        {
            currentPosition = new LatLng(location.Latitude,location.Longitude);

            // adding marker current location
            drawer.PlaceUserMarker(currentPosition,gmap);
            
            //move camera to current position
            cam.MoveAnimated(currentPosition, 18, gmap);

            if (isTracking)
            {
                // adding current location to _waypoints List
                _waypoints.Add(LatLngDTO.ToLatLngDTO(currentPosition));
                drawer.PlaceRoute(_waypoints, gmap);
            }
            else
            {
                
            }
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
        }
    }
}

