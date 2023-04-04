using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Controller
{
    public class C_Pegawai
    {

        public void Registrasi()
        {
            PegawaiQuery pegawaiQuery = new PegawaiQuery();
            Pegawai pegawai = new Pegawai();

            Console.WriteLine("Masukan Nama");
            pegawai.Name = Console.ReadLine();

            Console.WriteLine("Masukan Username");
            pegawai.Username = Console.ReadLine();
            Console.WriteLine("Masukan Password");
            pegawai.Password = Console.ReadLine();
         

            pegawaiQuery.insert(pegawai);
        }
    }
}
