using PruebaTecnicaJunior;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
//Instacion la clase del objeto y creo la lista que será la coleccion donde estaran los productos.

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("WELCOME\n");
        List<Productos> ProductList = new List<Productos>();
        var newProductList = addproduct(ProductList);
        int selection;
     
        do
        {
            do
            {
                Console.WriteLine("\nWhat would you like to do \n" +
                "press 1 ------------> add product \n" +
                "press 2 ------------> list product \n" +
                "press 3 ------------> removed product \n" +
                "press 4 ------------> get product \n" +
                "press 5 ------------> end the program \n");
                selection = Convert.ToInt16(Console.ReadLine());
                if (selection < 1 || selection > 5) { Console.WriteLine("chose 1,2,3,4 or 5 as a option\n"); }
            } while (selection < 1 || selection > 5);

            switch (selection)
            {
                case 1:
                    addproduct(newProductList);
                    break;
                case 2:
                    showProducts(newProductList);
                    break;
                case 3:
                    RemoveProduct(newProductList);
                    break;
                case 4:
                    GetProductByName(newProductList);
                    break;
                case 5:
                    Console.WriteLine("See you\n");
                    break;
            }
        } while (selection != 5);
    }

    public static List<Productos> addproduct(List<Productos> ProductList) 
    {
        //Variables a usar
        Guid id; string ?name, AuxPrice, respuesta; decimal price;
        do
        {
            Productos Productos = new Productos();
            //AdId
            id = Guid.NewGuid();

            //adName
            do
            {
                Console.WriteLine("add the name");
                name = Console.ReadLine();
                if (name == null || name.Length > 50)
                {
                    Console.WriteLine("name to long or is not valid\n");
                }
            } while (name == null || name.Length > 50);

            //adPrice
            do
            {
                Console.WriteLine("ad a valid number price");
                AuxPrice = Console.ReadLine();
                if (decimal.TryParse(AuxPrice, out decimal num))
                {
                    price = num;
                    break;
                }
                else
                {
                    Console.WriteLine("the current value is not valid please try again.\n");
                };
            } while (true);

            //se asigana primero al objeto y despues se ingresan a la lista
            Productos.Id = id;
            Productos.Name = name;
            Productos.Price = price;
            Productos.DateCreate = DateTime.Now;

            //Agregar a la lista.
            ProductList.Add(Productos);

            //Pregunta si desea ingresar    
            do
            {
                Console.WriteLine("Desea Ingresar más datos (S/N)");
                respuesta = Console.ReadLine().ToUpper();

                if (respuesta != "S" && respuesta != "N")
                {
                    Console.WriteLine("Respuesta no válida. Por favor ingrese 'S' o 'N'.\n");
                }
            } while (respuesta != "S" && respuesta != "N");


        } while (respuesta == "S");
        showProducts(ProductList);

        return ProductList;
    }
    public static void GetProductByName(List<Productos> ListProd)
    {
        Console.WriteLine("write a name\n");
        var name = Console.ReadLine();
        var product = ListProd.FirstOrDefault(n => n.Name == name);

        if (product == null)
        {
            Console.WriteLine($"The list does not contain a product with the name '{name}'.\n");
        }
        else
        {
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Date: {product.DateCreate}\n");
        }
    }
    public static void RemoveProduct(List<Productos> ListProd)
    {
        Console.WriteLine("write a name");
        var name = Console.ReadLine();
        var product = ListProd.FirstOrDefault(n => n.Name == name);

        if (product == null)
        {
            Console.WriteLine($"The list does not contain a product with the name '{name}'.\n");
        }
        else
        {
            ListProd.Remove(product);
            showProducts(ListProd);
            Console.WriteLine("Product Was Deleted\n");
        }
    }
    public static void showProducts(List<Productos> ListProd) 
    {
        foreach (var product in ListProd)
        {
            Console.WriteLine($"Id {product.Id},Name  {product.Name},Price  {product.Price},Date  {product.DateCreate}\n");
        }
    }
}