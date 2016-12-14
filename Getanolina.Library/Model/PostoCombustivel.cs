using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Getanolina.Library.Model
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