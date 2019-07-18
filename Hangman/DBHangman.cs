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
using Hangman.Resources;

namespace Hangman
{
    [Activity(Label = "DBHangman")] // DATABASE CONNECTION AND DATABASE NAME//
    public class DBHangman : Activity
    {

        List<Resources.PlayerScore> myList;
        private Button btnDeleteEntry;
        private Spinner spinnerEditDB;
        private Button btnEditDBMainMenu;
        //int Id;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainDB);
            DBConnection myConnectionClass = new DBConnection();
            myList = myConnectionClass.ViewAll();

            btnEditDBMainMenu = FindViewById<Button>(Resource.Id.btnEditDBMainMenu);
            btnEditDBMainMenu.Click += btnEditDBMainMenu_Click;
            spinnerEditDB = FindViewById<Spinner>(Resource.Id.spinnereditDB);
            global::Hangman.Resources.DBDA da = new Resources.DBDA(this, myList);

            spinnerEditDB.Adapter = da;

            spinnerEditDB.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerEditDB_ItemSelected);

            btnDeleteEntry = FindViewById<Button>(Resource.Id.btnDeleteEntry);
            btnDeleteEntry.Click += btnDeleteEntry_Click;
            btnDeleteEntry.Enabled = false;
        }
        private void btnEditDBMainMenu_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
            Finish();
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            var cc = new DBConnection();
            cc.DeletePlayer(HomeScreen.Id);
            myList = cc.ViewAll();


            var da = new Resources.DBDA(this, myList);

            spinnerEditDB.Adapter = da;
        }

        private void spinnerEditDB_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {


            Spinner spinner = (Spinner)sender;
            HomeScreen.Id = this.myList.ElementAt(e.Position).Id;
            btnDeleteEntry.Enabled = true;

        }
    }
}