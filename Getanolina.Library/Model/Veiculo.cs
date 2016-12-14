using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLiteNetExtensions.Attributes;

namespace Getanolina.Library.Model
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