using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System;

namespace Hangman
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class Home : AppCompatActivity
    {
        private Button btnNewGameScreen;
        private Button btnHighScores;
        private Button btnEditDB;
        private Button btnQuit;
        private TextView res;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_first);
            //BUTTONS FOR EACH WORK//
            res = FindViewById<TextView>(Resource.Id.txtres);
            btnNewGameScreen = FindViewById<Button>(Resource.Id.btnNewGameScreen);
            btnNewGameScreen.Click += (object sender, EventArgs e) => {
                btnNewGameScreen_Click(sender,e);
            };

            btnHighScores = FindViewById<Button>(Resource.Id.btnHighScores);
            btnHighScores.Click += (object sender, EventArgs e) => {
                btnHighScores_Click(sender, e);
            }; 

            btnEditDB = FindViewById<Button>(Resource.Id.btnEditDB);
            btnEditDB.Click += (object sender, EventArgs e) => {
                btnEditDB_Click(sender, e);
            };
            btnQuit = FindViewById<Button>(Resource.Id.btnQuit);
            btnQuit.Click += (object sender, EventArgs e) => {
                btnQuit_Click(sender, e);
            };
        }
     
        private void btnQuit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnEditDB_Click(object sender, EventArgs e)
        {
            //res.SetText(Resource.String.press);   
            StartActivity(typeof(DBHangman));
            Finish();
        }
        private void btnHighScores_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Scores));
            Finish();
        }

        private void btnNewGameScreen_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Player));
            Finish();
        }
        
        //public override void OnBackPressed()
        //{
        //    private Signal FragmentActivity activity;
        //    base.OnBackPressed();
            
        //}
    }

}