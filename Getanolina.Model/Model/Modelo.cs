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

namespace Getanolina.Model.Model
{
    public class Modelo
    {
        public string nome { get; set; }
        public int codigo { get; set; }
    }

    public class Ano
    {
        public string nome { get; set; }
        public string codigo { get; set; }
    }

    public class RootObject
    {
        public List<Modelo> modelos { get; set; }
        public List<Ano> anos { get; set; }
    }
}