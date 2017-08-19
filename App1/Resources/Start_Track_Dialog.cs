//using System;
//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Views;
//using Android.Widget;
//using App1;

//namespace App1.Resources
//{
//    public class Start_Track_Dialog:DialogFragment 
//    {
//        private Button btnStart { get; set; }
//        private EditText edtRouteName { get; set; }
//        public string RouteName { get; set; }
//        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
//        {

//            base.OnCreateView(inflater, container, savedInstanceState);
//            var view = inflater.Inflate(Resource.Layout.dialog_start_tracking,container,false);
//            btnStart = view.FindViewById<Button>(Resource.Id.btnStart);
//            edtRouteName = view.FindViewById<EditText>(Resource.Id.txtRouteName);
//            btnStart.Click += BtnStart_Click;
//            return view;
//        }

//        private void BtnStart_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(edtRouteName.Text))
//                RouteName = "Default";
//            else
//                RouteName = edtRouteName.Text;
//            Intent intent = new Intent(Application.Context,typeof(MainActivity));
            
//            this.Dismiss();
//        }

//        public override void OnActivityCreated(Bundle savedInstanceState)
//        {
//            Dialog.Window.RequestFeature(WindowFeatures.SwipeToDismiss); //Sets the title bar to invisible
//            base.OnActivityCreated(savedInstanceState);
//            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialogAnimation; //set the animation
//        }
//    }
//}