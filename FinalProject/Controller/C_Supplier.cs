using FinalProject.Models;
using FinalProject.Repositories;
using FinalProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Controller
{
    public class C_Supplier
    {
        public void ViewData()
        {
            SupplierQuery query = new SupplierQuery();
            query.View();
        }

        public void insert()
        {
            Supplier suppliers = new Supplier();
            Console.WriteLine("Masukan Supplier");
            suppliers.supplier = Console.ReadLine();
            Console.WriteLine("Masukan Jenis");
            suppliers.Jenis = Console.ReadLine();
            Console.WriteLine("Masukan Alamat");
            suppliers.Alamat = Console.ReadLine();

            SupplierQuery query = new SupplierQuery();
            query.insert(suppliers);
            ViewData();
        }

        public void update()
        {
            ViewData();
            Supplier suppliers = new Supplier();
            Console.WriteLine("Masukan id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukan Supplier");
            suppliers.supplier = Console.ReadLine();
            Console.WriteLine("Masukan Jenis");
            suppliers.Jenis = Console.ReadLine();
            Console.WriteLine("Masukan Alamat");
            suppliers.Alamat = Console.ReadLine();

            SupplierQuery query = new SupplierQuery();
            query.update(suppliers,id);
            ViewData();
        }

        public void Delete()
        {
            ViewData();
            Console.WriteLine("Masukan id");
            int id = Convert.ToInt32(Console.ReadLine());
            SupplierQuery query = new SupplierQuery();
            query.delete(id);
            ViewData();

        }
    }
}
