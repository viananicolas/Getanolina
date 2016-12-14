using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Android.App;
using Android.Widget;
using Android.OS;
using Getanolina.Extensions;
using Getanolina.Library.Model;
//using Getanolina.Library.Model;
//using Getanolina.Model.Model;
using Newtonsoft.Json;

namespace Getanolina
{
    [Activity(Label = "Getanolina", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            var x = new HttpClient();
            var b = await x.GetStringAsync("https://fipe-parallelum.rhcloud.com/api/v1/carros/marcas");
            var o = JsonConvert.DeserializeObject<List<Modelo>>(b);
            var marcaSpinner = FindViewById<Spinner>(Resource.Id.marcaSpinner);
            var marcaAdapter = new SpinAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, o);
            marcaSpinner.Adapter = marcaAdapter;
            //var marcaAdapter = new ArrayAdapter(this,Android.Resource.Layout.SimpleSpinnerItem,o);
            //marcaSpinner.Adapter = marcaAdapter;
            marcaSpinner.ItemSelected += (sender, args) =>
            {
                var a = marcaAdapter.GetItem(args.Position);
                //System.Diagnostics.Debug.WriteLine(a.nome);
            };
        }
    }
}

