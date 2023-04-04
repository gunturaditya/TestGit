using FinalProject.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.View
{
    public class V_Stok_Masuk
    {
        public void StokMasuk()
        {
            Console.WriteLine("Selamat Datang DiMenu Stok Masuk" + Environment.NewLine);
            Console.WriteLine("1.View");
            Console.WriteLine("2.Add");
            Console.WriteLine("3.Delete");
            Console.WriteLine("4.Search");
            Console.WriteLine("5.Back");
            bool menuError = int.TryParse(Console.ReadLine(), out int pilihMenu);

            if (menuError == true)
            {
                if (pilihMenu == 1)
                {
                    Console.Clear();
                    C_Stok_Masuk stok_Masuk = new C_Stok_Masuk();
                    stok_Masuk.viewData();
                    Console.WriteLine("Tekan Enter");
                    Console.ReadLine();
                    Console.Clear();
                    StokMasuk();

                }
                else if (pilihMenu == 2)
                {
                    Console.Clear();
                    C_Stok_Masuk stok_Masuk = new C_Stok_Masuk();
                    stok_Masuk.insertData();
                    Console.WriteLine("Tekan Enter");
                    Console.ReadLine();
                    Console.Clear();
                    StokMasuk();


                }
                else if (pilihMenu == 3)
                {
                    Console.Clear();
                    C_Stok_Masuk stok_Masuk = new C_Stok_Masuk();
                    stok_Masuk.deleteData();
                    Console.WriteLine("Tekan Enter");
                    Console.ReadLine();
                    Console.Clear();
                    StokMasuk();


                }
                else if (pilihMenu == 4)
                {
                    Console.Clear();
                    C_Stok_Masuk stok_Masuk = new C_Stok_Masuk();
                    stok_Masuk.viewDatabyID();
                    Console.WriteLine("Tekan Enter");
                    Console.ReadLine();
                    Console.Clear();
                    StokMasuk();

                }

                else if (pilihMenu == 5)
                {
                    Console.Clear();
                    V_Owner v_Owner = new V_Owner();
                    v_Owner.Masterdata();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Menu Yang anda Pilih Tidak ada");
                    StokMasuk();
                }

                StokMasuk();

            }
            else
            {
                Console.WriteLine(" Mohon Masukan Angka");
                Console.WriteLine("Klik Enter to menu");
                Console.ReadLine();
                StokMasuk();
            }

        }
    }
}
