using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using WAU.Model;
using WAU.Data;
using System.Collections.Generic;

namespace WAU.Resources
{
    class dialog_SignUp : DialogFragment
    {
        public User User { get; set; }
        private EditText mTxtFirstName;
        private EditText mTxtEmail;
        private EditText mTxtSurname;
        private EditText mTxtAge;
        private EditText mTxtPassword;
        private EditText mTxtUserName;
        private Button mBtnSignUp;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            mTxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mTxtEmail =  view.FindViewById<EditText>(Resource.Id.txtEmail);
            mTxtSurname =  view.FindViewById<EditText>(Resource.Id.txtSurName);
            mTxtAge =  view.FindViewById<EditText>(Resource.Id.txtAge);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mTxtUserName = view.FindViewById<EditText>(Resource.Id.txtUserName);            
            mBtnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogSignUp);
            mBtnSignUp.Click += mBtnSignUp_Click;

            return view;
        }

        private void mBtnSignUp_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mTxtUserName.Text) && !string.IsNullOrEmpty(mTxtFirstName.Text) && !string.IsNullOrEmpty(mTxtEmail.Text) && !string.IsNullOrEmpty(mTxtPassword.Text) && !string.IsNullOrEmpty(mTxtSurname.Text) && !string.IsNullOrEmpty(mTxtAge.Text))
            {
                User = new User()
                {
                    name = mTxtFirstName.Text,
                    age = int.Parse(mTxtAge.Text),
                    email = mTxtEmail.Text,
                    surName = mTxtSurname.Text,
                    password = mTxtPassword.Text,
                    userName = mTxtUserName.Text,
                    maproutes = new List<MapRoute>(),
                    UserToken = TokenGenerator.Generate()
                };
                new PostData(User).Execute(MongoLab.GetAddressAPI());
                Toast.MakeText(Application.Context, "Qeydiyyatdan Ugurla kecdiniz", ToastLength.Short).Show();
                this.Dismiss();
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_Login logInDialog = new dialog_Login();
                logInDialog.Show(transaction, "dialog fragment");
            }
            else
            {
                Toast.MakeText(Application.Context, "Butun xanalari doldur da", ToastLength.Short).Show();
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