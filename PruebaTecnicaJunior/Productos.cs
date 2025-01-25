using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PruebaTecnicaJunior
{
    //Creo el objeto que voy a usar, para guardar los produtos
    public class Productos
    {
        public Guid Id { get; set; }
        public string ?Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public List<Productos> ProductList { get; set; }

        public Productos() { ProductList = new List<Productos>(); }
        public Productos(Guid id, string name, decimal price, DateTime dateCreate) 
        {
            Id = id;
            Name = name;
            Price = price;
            DateCreate = dateCreate;
            ProductList = new List<Productos>();
        }
    }
}
