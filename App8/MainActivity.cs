using Android.App;
using Android.Widget;
using Android.OS;
using static App8.Resource;
using System;
using Android.Content.Res;
using Android.Content;

namespace App8
{
    [Activity(MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {

        static System.Collections.Generic.IList<string> list = new System.Collections.Generic.List<string> { "English" };
        Button button1;
        Button ButtonLang;
        Helperlanguage helperlanguage;



        protected override void OnSaveInstanceState(Bundle outState)
        {
            
            outState.PutInt("click_count", 1);

            // always call the base implementation!
            base.OnSaveInstanceState(outState);
        }
        protected override void OnCreate(Bundle bundle)
        {
            if(bundle == null)
            {
                bundle = new Bundle();
            }
            base.OnCreate(bundle);
            OnSaveInstanceState(bundle);

            var lang = Intent.GetStringArrayListExtra("settings");
            if (lang != null)
            {
                // Intent.PutStringArrayListExtra("settings", temp1);
                list = lang;
            }
 
            helperlanguage = new Helperlanguage(list[0], this);
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            SetContentView(Resource.Layout.Main);
            button1 = FindViewById<Button>(Resource.Id.button1);
            ButtonLang = FindViewById<Button>(Resource.Id.buttonLang);
            button1.Text = helperlanguage.StartGame;
            ButtonLang.Text = helperlanguage.ChooseLanguage;

          //  button1.Background = new ColorStateList()
            Helperlanguage g = new Helperlanguage("English", this);



            button1.Click += delegate (object sender, EventArgs e)
            {

                var itent = new Android.Content.Intent((this), typeof(StartGame));
                var temp = Intent.GetStringArrayListExtra("settings");
                if (temp != null)
                {
                    itent.PutStringArrayListExtra("settings", temp);
                    list = temp;
                }
                else
                {
                    itent.PutStringArrayListExtra("settings", list);
                }
                StartActivity(itent);
                
            };

            ButtonLang.Click += delegate (object sender, EventArgs e)
            {
                Intent itent = new Android.Content.Intent((this), typeof(ChooseLanguage));
                itent.PutStringArrayListExtra("settings", list);
                StartActivity(itent);

            };




        }

        //protected override void OnStart()
        //{
        //    // Handle when your app starts
        //}

        ////protected override void OnSleep()
        ////{
        ////    // Handle when your app sleeps
        ////}

        //protected override void OnResume()
        //{
        //    // Handle when your app resumes
        //}

    }
}

