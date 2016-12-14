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
using SQLiteNetExtensions.Attributes;

namespace Getanolina.Model.Model
{
    public class Veiculo
    {
        public string Id { get; set; }
        public string Modelo { get; set; }
        public string AnoModelo { get; set; }
        public string AnoFabricacao { get; set; }
        [OneToOne]
        public Motor Motor { get; set; }
    }
}