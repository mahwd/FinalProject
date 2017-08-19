using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Preferences;
using WAU.Model;

namespace WAU.Data
{
    public class AppPreferences
    {
        private ISharedPreferences mSharedPrefs;
        private ISharedPreferencesEditor mPrefsEditor;
        private Context mContext;

        private static String userId = "userId";

        public AppPreferences(Context context)
        {
            this.mContext = context;
            mSharedPrefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            mPrefsEditor = mSharedPrefs.Edit();
        }

        public void registerLog(Id userid)
        {
            mPrefsEditor.PutString(userId, userid.id);
            mPrefsEditor.Commit();
        }

        public string getAccessKey()
        {
            return mSharedPrefs.GetString(userId, "");
        }
    }
}