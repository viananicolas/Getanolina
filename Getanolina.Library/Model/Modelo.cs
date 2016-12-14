using System.Collections.Generic;

namespace Getanolina.Library.Model
{
    public class Modelo
    {
        private int _codigo;
        private string _nome;
        public string nome { get; set; }
        public int codigo { get; set; }

        public Modelo()
        {
            this._nome = "";
            this._codigo = 0;
        }
        public void SetId(int id)
        {
            this._codigo = id;
        }

        public int GetId()
        {
            return this.codigo;
        }

        public void SetName(string name)
        {
            this.nome = name;
        }

        public string GetName()
        {
            return this.nome;
        }
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