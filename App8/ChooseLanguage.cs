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

namespace App8
{
    [Activity(Theme = "@android:style/Theme.NoTitleBar")]
    public class ChooseLanguage : Activity
    {
        RadioGroup radioGroup;
        Button checkbutton;
        RadioButton radioButton1;
        RadioButton radioButton2;
        RadioButton radioButton3;
        TextView textViewLang;
        Helperlanguage helperlanguage;

        IList<string> templish;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChooseLanguage);

            templish = Intent.GetStringArrayListExtra("settings");
            var lang = templish[0];
            helperlanguage = new App8.Helperlanguage(lang, this);

            checkbutton = FindViewById<Button>(Resource.Id.buttonChaked);
            radioButton1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            radioButton2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
            radioButton3 = FindViewById<RadioButton>(Resource.Id.radioButton3);
            radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            textViewLang = FindViewById<TextView>(Resource.Id.textViewLang);
            textViewLang.Text = helperlanguage.TextViewLang;

            checkbutton.Click += Checkbutton_Click;

            if (lang == "English")
            {
                radioGroup.Check(radioButton1.Id);
            }
            else if (lang == "Russian")
            {
                radioGroup.Check(radioButton2.Id);
            }
            else
            {
                radioGroup.Check(radioButton3.Id);
            }

            // Create your application here
        }

        private void Checkbutton_Click(object sender, EventArgs e)
        {
            Intent itent = new Android.Content.Intent((this), typeof(MainActivity));
            var temp = radioGroup.CheckedRadioButtonId;
            if (temp == radioButton1.Id)
            {
                Toast.MakeText(this, "English", ToastLength.Short).Show();
                templish[0] = "English";
                itent.PutStringArrayListExtra("settings", templish);
            }
            else if (temp == radioButton2.Id)
            {
                Toast.MakeText(this, "Russian", ToastLength.Short).Show();
                templish[0] = "Russian";
                itent.PutStringArrayListExtra("settings", templish);
            }
            else
            {
                Toast.MakeText(this, "Ukraine", ToastLength.Short).Show();
                templish[0] = "Ukraine";
                itent.PutStringArrayListExtra("settings", templish);
            }


            // itent.PutStringArrayListExtra("settings", list);

            StartActivity(itent);
        }
    }
}