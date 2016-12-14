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
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Getanolina.Model.Model
{
    public class Combustivel
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string ComNome { get; set; }
        public string ComObservacao { get; set; }
        public double ComPreco { get; set; }
        [ManyToMany(typeof(PostoCombustivel))]
        public List<Posto> Postos { get; set; }
    }
}