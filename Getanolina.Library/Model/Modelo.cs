using System.Collections.Generic;

namespace Getanolina.Library.Model
{
    public class Modelo
    {
        public string nome { get; set; }
        public int codigo { get; set; }

        public void SetId(int id)
        {
            this.codigo = id;
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
        public void SetId(string id)
        {
            this.codigo = id;
        }

        public string GetId()
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

    public class RootObject
    {
        public List<Modelo> modelos { get; set; }
        public List<Ano> anos { get; set; }
    }
}