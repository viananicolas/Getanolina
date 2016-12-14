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
    public class Motor
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string MoDescricao { get; set; }
        [OneToMany]
        public List<Combustivel> Combustiveis { get; set; }
    }
}