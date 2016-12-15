using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net.Http;
using Android.App;
using Android.Widget;
using Android.OS;
using Getanolina.Extensions;
using Getanolina.Library.Model;
using Getanolina.Methods;
using ModernHttpClient;
//using Getanolina.Library.Model;
//using Getanolina.Model.Model;
using Newtonsoft.Json;

namespace Getanolina
{
    [Activity(Label = "Getanolina", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private HttpClient _httpClient;
        private string _json;
        private string _jsonModelo;
        public Modelo marca;
        private double alcool;
        private double gasolina;
        private double gnv;
        private double quilometragem;
        private double litragemMensal;
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            marca=new Modelo();
            _httpClient = new HttpClient(new NativeMessageHandler());
            _json = await _httpClient.GetStringAsync("https://fipe-parallelum.rhcloud.com/api/v1/carros/marcas");
            var marcas = JsonConvert.DeserializeObject<List<Modelo>>(_json);
            var marcaSpinner = FindViewById<Spinner>(Resource.Id.marcaSpinner);
            var modeloSpinner = FindViewById<Spinner>(Resource.Id.modeloSpinner);
            var anoSpinner = FindViewById<Spinner>(Resource.Id.anoSpinner);
            var marcaAdapter = new MarcaSpinAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, marcas);
            marcaSpinner.Adapter = marcaAdapter;
            marcaSpinner.ItemSelected += async (sender, args) =>
            {
                marca = marcaAdapter.GetItem(args.Position);
                _jsonModelo = await _httpClient.GetStringAsync("https://fipe-parallelum.rhcloud.com/api/v1/carros/marcas/"+ marca.codigo+"/modelos");
                var modelos = JsonConvert.DeserializeObject<RootObject>(_jsonModelo);
                var modeloAdapter = new MarcaSpinAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, modelos.modelos);
                modeloSpinner.Adapter = modeloAdapter;
                modeloSpinner.ItemSelected += async (o, eventArgs) =>
                {
                    try
                    {
                        var modelo = modeloAdapter.GetItem(eventArgs.Position);
                        //_json = await _httpClient.GetStringAsync("https://fipe-parallelum.rhcloud.com/api/v1/carros/marcas/" + marca.codigo + "/modelos/" + modelo.codigo + "/anos");
                        var http= new HttpClient(new NativeMessageHandler());
                        _json = await http.GetStringAsync(
                            $"https://fipe-parallelum.rhcloud.com/api/v1/carros/marcas/{marca.codigo}/modelos/{modelo.codigo}/anos");
                        System.Diagnostics.Debug.WriteLine("Olá: "+_httpClient.BaseAddress);
                        var anos = JsonConvert.DeserializeObject<List<Ano>>(_json);
                        var anoAdapter = new AnoSpinAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, anos);
                        anoSpinner.Adapter = anoAdapter;
                    }
                    catch (Exception e)
                    {

                        System.Diagnostics.Debug.WriteLine(e.ToString());
                    }
                };
            };
            var buttonCalcular = FindViewById<Button>(Resource.Id.buttonCalcular);
            buttonCalcular.Click += ButtonCalcular_Click;
        }

        private void ButtonCalcular_Click(object sender, EventArgs e)
        {
            var editTextKm = FindViewById<EditText>(Resource.Id.editTextKm);
            var editTextGasolina = FindViewById<EditText>(Resource.Id.editTextGasolina);
            var editTextAlcool = FindViewById<EditText>(Resource.Id.editTextAlcool);
            var editTextGNV = FindViewById<EditText>(Resource.Id.editTextGNV);
            var editTextKmLMensal = FindViewById<EditText>(Resource.Id.editTextKmMensal);
            Double.TryParse(editTextAlcool.Text, out alcool);
            Double.TryParse(editTextGasolina.Text, out gasolina);
            Double.TryParse(editTextGNV.Text, out gnv);
            Double.TryParse(editTextKm.Text, out quilometragem);
            Double.TryParse(editTextKmLMensal.Text, out litragemMensal);

            var a = FindViewById<TextView>(Resource.Id.editTextConGas);
            var b = FindViewById<TextView>(Resource.Id.editTextConAlco);
            var consumoComb = quilometragem / litragemMensal;
            var gastocombGas = consumoComb * gasolina;
            var gastocombAlco = consumoComb * alcool;
            var consumoGNV = quilometragem / 12.5;
            var gastoGNV = (quilometragem / 12.5) * gnv;
            var economiaGas = (gastocombGas) - (gastoGNV);
            var economiaAlco = (gastocombAlco) - (gastoGNV);
            //var payback = Instalacao / economia;
            var custoGasKm = gasolina / litragemMensal;
            var custoAlcoKm = alcool / litragemMensal;
            var custoGNVKm = gnv / 12.5;
            a.Text = gastocombGas.ToString(CultureInfo.CurrentCulture);
            b.Text = gastocombAlco.ToString(CultureInfo.CurrentCulture);

        }
    }
}

