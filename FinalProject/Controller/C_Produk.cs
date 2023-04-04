using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Controller
{
    public class C_Produk
    {
        public void Insertdata()
        {
            Produk produk = new Produk();

            Console.WriteLine("Masukan idSupplier");
            produk.id_Supplier = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Produk");
            produk.produk = Console.ReadLine();
            Console.WriteLine("Masukan Harga");
            produk.Harga = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukan QTY");
            produk.Qty = Convert.ToInt32(Console.ReadLine());
            ProdukQuery query = new ProdukQuery();
            Console.Clear();
            query.insert(produk);
            viewData();

        }
        public void Updatedata()
        {
            viewData();
            Produk produk = new Produk();
            Console.WriteLine("Masukan id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukan idSupplier");
            produk.id_Supplier = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Produk");
            produk.produk = Console.ReadLine();
            Console.WriteLine("Masukan Harga");
            produk.Harga = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukan QTY");
            produk.Qty = Convert.ToInt32(Console.ReadLine());
            ProdukQuery query = new ProdukQuery();
            Console.Clear();
            query.update(produk,id);
            viewData();
        }
        public void Deletedata()
        {
            viewData();
            ProdukQuery query = new ProdukQuery();
            Console.WriteLine("Masukan id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            query.delete(id);
            viewData();
            
        }
        public void viewData() {
            ProdukQuery query = new ProdukQuery();
            query.View();
        }
        public void ProdukSearch() {

            Console.WriteLine("Masukan Produk");
            String name = Console.ReadLine();
            ProdukQuery query = new ProdukQuery();
            Console.Clear();
            query.Search(name);
        }
    }
}
