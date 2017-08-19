using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using WAU.Data;
using WAU.Model;
using System;
using System.Collections.Generic;

namespace WAU.Resources
{
    public class DialogSave:DialogFragment
    {

        private EditText edtRouteName { get; set; }
        private Button btnSaveRoute{ get; set; }
        public static string RouteName{ get; set; }
        private User _user { get; set; }
        private List<LatLngDTO> _cachedRoute { get; set; }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_save_route,null);

            edtRouteName = view.FindViewById<EditText>(Resource.Id.RouteName);
            btnSaveRoute = view.FindViewById<Button>(Resource.Id.btnDialogSave);

            RouteName = edtRouteName.Text;
            btnSaveRoute.Click += BtnSaveRoute_Click;

            return view;
        }

        private void BtnSaveRoute_Click(object sender, EventArgs e)
        {
            _user.maproutes.Add(new MapRoute()
            {
                RouteName = edtRouteName.Text,
                RouteWayPoints = _cachedRoute,
                statusIcons = null  //helelik
            });

            try
            {
                new PutData(_user).Execute(MongoLab.SelectWithQuery($"\"userName\":\"{_user.userName}\""));
                Toast.MakeText(Application.Context, "Your route saved", ToastLength.Short).Show();
                this.Dismiss();
            }
            catch 
            {
                Toast.MakeText(Application.Context, "Problem occured", ToastLength.Short).Show();
            }

        }

        public DialogSave(User user,List<LatLngDTO> lst)
        {
            _user = user;
            _cachedRoute = lst;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.SwipeToDismiss); //Sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialogAnimation; //set the animation
        }
    }
}