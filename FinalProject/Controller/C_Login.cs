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
    public class C_Login
    {

        public void Login() 
        { 
      
        PegawaiQuery pegawaiQuery = new PegawaiQuery();
        OwnerQuery ownerQuery = new OwnerQuery();
        Pegawai pegawai = new Pegawai();
         Console.WriteLine("Masukan Username");
         String Username = Console.ReadLine();
         Console.WriteLine("Masukan Password");
        String Password = Console.ReadLine();

            if (pegawaiQuery.Login(Username,Password))
            {
                Console.Clear();
               V_Pegawai v_Pegawai = new V_Pegawai();
                v_Pegawai.Masterdata();
                
            }
            else if(ownerQuery.Login(Username,Password))
            {
                Console.Clear();
                V_Owner owner = new V_Owner();
                owner.printMenu();
               
            }
          
        }
    }
}
