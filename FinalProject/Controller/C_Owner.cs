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
    public class C_Owner
    {
      
        
        public C_Owner() { 
        
        
        }

        public void GetallOwner()
        {
           
            OwnerQuery ownerQuery = new OwnerQuery();

            ownerQuery.View();
            

        }

        public void InsertOwner()
        {

            OwnerQuery ownerQuery = new OwnerQuery();
            Owner owner = new Owner();

            Console.WriteLine("Masukan Nama");
            owner.Name = Console.ReadLine();

            Console.WriteLine("Masukan Username");
            owner.Username = Console.ReadLine();
            Console.WriteLine("Masukan Password");
            owner.Password = Console.ReadLine();

            ownerQuery.insert(owner);

        }

        public void UpdateOwner()
        {
            OwnerQuery ownerQuery = new OwnerQuery();
            Owner owner = new Owner();

            GetallOwner();
            Console.WriteLine("Masukan id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukan Nama");
            owner.Name = Console.ReadLine();
            Console.WriteLine("Masukan Username");
            owner.Username = Console.ReadLine();
            Console.WriteLine("Masukan Password");
            owner.Password = Console.ReadLine();
            ownerQuery.update(owner,id);
        }
        public void DeleteOwner()
        {
            GetallOwner();
            OwnerQuery ownerQuery = new OwnerQuery();
            Console.WriteLine("Masukan id");
            int id = Convert.ToInt32(Console.ReadLine());
            ownerQuery.delete(id);
        }

        public void search()
        {
            OwnerQuery ownerQuery = new OwnerQuery();
            Console.WriteLine("Masukan username");
            string username = Console.ReadLine();
            ownerQuery.Search(username);
        }

        public void validasiPegawai()
        {
            PegawaiQuery pegawaiQuery = new PegawaiQuery();
            pegawaiQuery.View();
            Pegawai pegawai = new Pegawai();

            Console.WriteLine("masukan id");
            int id = Convert.ToInt32(Console.ReadLine());
            pegawai.Status = 1;

            pegawaiQuery.update(pegawai,id);
   
        }

 
    }

}
