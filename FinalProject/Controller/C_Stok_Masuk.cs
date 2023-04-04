using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Controller
{
    public class C_Stok_Masuk
    {
        public void insertData()
        {
           Stok_MasukQuery stok_MasukQuery = new Stok_MasukQuery();
            Stok_Masuk stok_Masuk = new Stok_Masuk();


            Console.WriteLine("Masukan id Produk");
            stok_Masuk.id_produk = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Qty");
            stok_Masuk.qty = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("masukan tanggal");
            stok_Masuk.date = Console.ReadLine();

            stok_MasukQuery.insert(stok_Masuk);
        }

        public void viewData()
        {
            Stok_MasukQuery stok_MasukQuery = new Stok_MasukQuery();
            stok_MasukQuery.View();
        }

        public void deleteData()
        {
            Stok_MasukQuery stok_MasukQuery = new Stok_MasukQuery();
            Console.WriteLine("Masukan Id");
            int id = Convert.ToInt32(Console.ReadLine());

            stok_MasukQuery.delete(id);
        }

        public void viewDatabyID()
        {
            Stok_MasukQuery stok_MasukQuery = new Stok_MasukQuery();
            Console.WriteLine("Masukan Id");
            int id = Convert.ToInt32(Console.ReadLine());

            stok_MasukQuery.Search(id);
        }
    }
}
