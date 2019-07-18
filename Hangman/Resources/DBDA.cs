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

namespace Hangman.Resources
{
    class DBDA : BaseAdapter<PlayerScore>
    {
        private readonly Activity context;
        private readonly List<PlayerScore> mItems;

        public DBDA(Activity context, List<PlayerScore> items)
        {
            this.mItems = items;
            this.context = context;
        }



        public override int Count
        {
            get { return mItems.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override PlayerScore this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var row = convertView;


            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.data_row, null, false);
            }

            TextView txtRowName = row.FindViewById<TextView>(Resource.Id.txtRowName);
            txtRowName.Text = mItems[position].Name;

            TextView txtRowScore = row.FindViewById<TextView>(Resource.Id.txtRowScore);
            txtRowScore.Text = mItems[position].Score.ToString();

            return row;


        }
    }
}