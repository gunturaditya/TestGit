using FinalProject.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.View
{
    public class V_Login
    {
        
        public void LoginUser()
        {
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register");
            bool menuError = int.TryParse(Console.ReadLine(), out int pilihMenu);

            if (menuError == true)
            {
                if (pilihMenu == 1)
                {
                   Console.Clear();
                    C_Login login = new C_Login();

                    login.Login();
                 
               
                }
                else if (pilihMenu == 2)
                {
                    Console.Clear();
                    C_Pegawai pegawai = new C_Pegawai();
                    pegawai.Registrasi();
                    LoginUser();
                    
                }
 
                else
                {
                    LoginUser();
                    Console.WriteLine("Menu Yang anda Pilih Tidak ada");
                  
                }

            }
            else
            {
                LoginUser();
                Console.WriteLine(" Mohon Masukan Angka");
                Console.WriteLine("Klik Enter to menu");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
