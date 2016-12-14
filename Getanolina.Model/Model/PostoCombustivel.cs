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
    public class PostoCombustivel
    {
        [PrimaryKey]
        public string Id { get; set; }
        [ForeignKey(typeof(Posto))]
        public string PostoId { get; set; }
        [ForeignKey(typeof(Combustivel))]
        public string CombustivelId { get; set; }
    }
}