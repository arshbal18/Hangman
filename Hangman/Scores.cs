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
    [Activity(Label = "Scores")] //DATABASE FOR SCORES FOR EACH PLAYER//
    public class Scores : Activity
    {
        List<Resources.PlayerScore> myList;
        private DBConnection myConnectionClass;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Scores);

            myConnectionClass = new DBConnection();
            myList = myConnectionClass.ViewAll();
            Button btnHighScoresBack = FindViewById<Button>
                (Resource.Id.btnHighScoresBack);

            btnHighScoresBack.Click += btnHighScoresBack_Click;

            // Display the player names and high scores 
            ListView HighScoresListView = FindViewById<ListView>(Resource.Id.HighScoresListView);
            HighScoresListView.Adapter = new DBDA(this, myList);
        }

        private void btnHighScoresBack_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
            Finish();
        }
    }
}