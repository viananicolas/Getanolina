using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Getanolina.Library.Model
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