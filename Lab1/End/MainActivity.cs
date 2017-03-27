using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Lab1
{
    [Activity(Label = "Lab1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnRegistro;
        TextView textViewDev;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource and attach an event to it
            textViewDev = FindViewById<TextView>(Resource.Id.textViewDev);
            btnRegistro = FindViewById<Button>(Resource.Id.btnRegistro);

            btnRegistro.Click += BtnRegistro_Click;
        }

        private async void BtnRegistro_Click(object sender, EventArgs e)
        {
            textViewDev.Text = "Introduce tu nombre";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            XamarinDiplomado.ServiceHelper helper = new XamarinDiplomado.ServiceHelper();
            await helper.InsertarEntidad("lruval@outlook.com", "lab1", myDevice);
            btnRegistro.Text = "Gracias por completar el Lab1";
        }
    }
}

