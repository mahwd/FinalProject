using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using WAU;
using WAU.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WAU.Data
{ 
    public class GetData : AsyncTask<string, Java.Lang.Void, string>
    {
        private ProgressDialog pd = new ProgressDialog(Application.Context);
        public static List<User> UserList { get; set; }
        public static User _user { get; private set; }
        private string _userName { get; set; }
        private string _userPassword { get; set; }
        private Activity _activity { get; set; }

        protected override void OnPreExecute()
        {
            base.OnPreExecute();
            pd.Window.SetType(WindowManagerTypes.SystemOverlay);
            pd.SetTitle("Be Patient...");
            pd.Show();
        }
        protected override string RunInBackground(params string[] @params)
        {
            string stream = null;
            string urlString = @params[0];
            HTTPDataHandler http = new HTTPDataHandler();
            stream = http.GetHTTPData(urlString);
            return stream;
        }

        protected override void OnPostExecute(string result)
        {
            base.OnPostExecute(result);

            Bundle bundle = new Bundle();

            try
            {
                UserList = JsonConvert.DeserializeObject<List<User>>(result);
                if (UserList.Count == 1)
                     _user = UserList[0];
                if (_userName == _user.userName && _userPassword == _user.password)
                {
                    Toast.MakeText(Application.Context, $"Wellcome { _user.name} ", ToastLength.Long).Show();
                    Intent intent = new Intent(Application.Context, typeof(MainActivity));
                    LoginScreen.loginScreen.StartActivity(intent);
                }
                else if (_userName != _user.userName && _userPassword != _user.password ) {
                    Toast.MakeText(Application.Context, $"Incorrect username or password", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, $"Problem occured, please check your internet connection", ToastLength.Long).Show();
            }
            pd.Dismiss();
        }

        public GetData(string username,string pass)
        {
            _userName = username;
            _userPassword = pass;
        }

        public GetData(){}
    }
}