using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using WAU;
using WAU.Data;
using WAU.Model;
using System;

namespace WAU.Resources
{

    public class dialog_Login : DialogFragment
    {
        public User User { get; set; }
        private Button btnLogin { get; set; }
        private EditText mTxtUserName { get; set; }
        private EditText mTxtPassword { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_log_in, container, false);
            mTxtUserName = view.FindViewById<EditText>(Resource.Id.txtUserName);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            btnLogin = view.FindViewById<Button>(Resource.Id.btnDialogLogIn);
            btnLogin.Click += BtnLogin_Click;
            return view;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mTxtUserName.Text) && !string.IsNullOrEmpty(mTxtPassword.Text))
            {
                    new GetData(mTxtUserName.Text,mTxtPassword.Text).Execute(MongoLab.SelectWithQuery($"\"userName\":\"{mTxtUserName.Text}\",\"password\":\"{mTxtPassword.Text}\""));
            }
            else
            {
                Toast.MakeText(Application.Context, "Butun xanalari doldur deee", ToastLength.Short).Show();
            }
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.SwipeToDismiss); //Sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialogAnimation; //set the animation
        }
    }
}