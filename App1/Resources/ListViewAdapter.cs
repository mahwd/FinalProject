using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using WAU.Model;
using WAU.Data;

namespace WAU.Resources
{
    class ListViewAdapter : BaseAdapter
    {
        private List<User> _users { get; set; }
        private User _user { get; set; }
        private Context _context { get; set; }



        public ListViewAdapter(Context context, List<User> users)
        {
            _context = context;
            _users = users;
        }

        public override int Count
        {
            get
            {
                if (GetData.UserList == null)
                    return 0;
                else
                    return GetData.UserList.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            _users = GetData.UserList;
            LayoutInflater inflater = (LayoutInflater)_context.GetSystemService(Context.LayoutInflaterService);
            var view = inflater.Inflate(Resource.Layout.listUsersTemplate,null);
            var edtName = view.FindViewById<TextView>(Resource.Id.txtName);
            var edtAge = view.FindViewById<TextView>(Resource.Id.txtAge);
            var edtMapRouteName = view.FindViewById<TextView>(Resource.Id.txtMapRouteName);
            var edtCount = view.FindViewById<TextView>(Resource.Id.txtCount);
            edtName.Text = _users[position].name;
            edtAge.Text = _users[position].age.ToString();
            //edtMapRouteName.Text = _users[position].maproutes.Routename;
            //edtCount.Text = _users[position].maproutes.RouteWayPoints.ToString();
                
            return view;
        }
    }
}