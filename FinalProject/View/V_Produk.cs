using FinalProject.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.View
{
    public class V_Produk
    {
        public void produk()
        {
            Console.WriteLine("Selamat Datang DiMenu Produk" + Environment.NewLine);
            Console.WriteLine("1.View");
            Console.WriteLine("2.Add");
            Console.WriteLine("3.Edit");
            Console.WriteLine("4.Delete");
            Console.WriteLine("5.Search");
            Console.WriteLine("6.Back");
            bool menuError = int.TryParse(Console.ReadLine(), out int pilihMenu);

            if (menuError == true)
            {
                if (pilihMenu == 1)
                {
                    Console.Clear();
                   C_Produk produks  = new C_Produk();
                    produks.viewData();
                    Console.WriteLine("Tekan Enter");
                    Console.ReadLine();
                    Console.Clear();
                    produk();

                }
                else if (pilihMenu == 2)
                {
                    Console.Clear();
                    C_Produk produks = new C_Produk();
                    produks.Insertdata();
                    Console.WriteLine("Tekan Enter");
                    Console.ReadLine();
                    Console.Clear();
                    produk();


                }
                else if (pilihMenu == 3)
                {
                    Console.Clear();
                    C_Produk produks = new C_Produk();
                    produks.Updatedata();
                    Console.WriteLine("Tekan Enter");
                    Console.ReadLine();
                    Console.Clear();
                    produk();


                }
                else if (pilihMenu == 4)
                {
                    Console.Clear();
                    C_Produk produks = new C_Produk();
                    produks.Deletedata();
                    Console.WriteLine("Tekan Enter");
                    Console.ReadLine();
                    Console.Clear();
                    produk();

                }
                else if (pilihMenu == 5)
                {
                    Console.Clear();
                    C_Produk produks = new C_Produk();
                    produks.ProdukSearch();
                    Console.WriteLine("Tekan Enter");
                    Console.ReadLine();
                    Console.Clear();
                    produk();


                }
                else if (pilihMenu == 6)
                {
                    Console.Clear();
                       V_Owner v_Owner = new V_Owner();
                    v_Owner.Masterdata();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Menu Yang anda Pilih Tidak ada");
                    produk();
                }

                produk();

            }
            else
            {
                Console.WriteLine(" Mohon Masukan Angka");
                Console.WriteLine("Klik Enter to menu");
                Console.ReadLine();
                Console.Clear();
                produk();
            }

        }
    }
}
