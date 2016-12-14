using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Getanolina.Library.Model;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Getanolina.Library.Model
{
    public class Posto
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string PosNome { get; set; }
        [ManyToMany(typeof(PostoCombustivel))]
        public List<Combustivel> Combustiveis { get; set; }
    }
}