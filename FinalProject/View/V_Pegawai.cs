using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.View
{
    public class V_Pegawai
    {
        public void Masterdata()
        {
            Console.WriteLine("Selamat Datang Pegawai" + Environment.NewLine);
            Console.WriteLine("1.Stok Keluar  ");
            Console.WriteLine("2.Logout  ");
            Console.WriteLine("Pilih Menu Anda !!");

            bool menuError = int.TryParse(Console.ReadLine(), out int pilihMenu);

            if (menuError == true)
            {
                if (pilihMenu == 1)
                {
                    Console.Clear();
                  
                    V_Stok_Masuk v_Stok_Masuk = new V_Stok_Masuk();
                    v_Stok_Masuk.StokMasuk();


                }
                else if (pilihMenu == 2)
                {
                    Console.Clear();
                    V_Login v_Login = new V_Login();
                    v_Login.LoginUser();

                }

                else
                {
                    Console.WriteLine("Menu Yang anda Pilih Tidak ada");
                    Console.Clear();
                    Masterdata();
                }



            }
            else
            {
                Console.WriteLine(" Mohon Masukan Angka");
                Console.WriteLine("Klik Enter to menu");
                Console.ReadLine();
                Console.Clear();
                Masterdata();
            }
        }
    }
}
