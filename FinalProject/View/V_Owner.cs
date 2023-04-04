using FinalProject.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.View
{
    public class V_Owner
    {
        C_Owner c_Owner;
        public V_Owner() {
            
        }
        public void printMenu()
        {
            Console.WriteLine("Selamat Datang Owner" + Environment.NewLine);
            Console.WriteLine("1.Owner  ");
            Console.WriteLine("2.Pegawai  ");
            Console.WriteLine("3.Master data ");
            Console.WriteLine("4.Logout");
            Console.WriteLine("Pilih Menu Anda !!");

            bool menuError = int.TryParse(Console.ReadLine(), out int pilihMenu);

            if (menuError == true)
            {
                if (pilihMenu == 1)
                {
                    Console.Clear();
                    Owner();
                   
                    
                }
                else if (pilihMenu == 2)
                {
                    Console.Clear();
                    C_Owner c_Owner = new C_Owner();
                    c_Owner.validasiPegawai();
                    printMenu();
                    
                }
                else if (pilihMenu == 3)
                {
                    Console.Clear();
                    Masterdata();
                  
                    
                }
                else if (pilihMenu == 4)
                {
                    Console.Clear();
                    V_Login v_Login = new V_Login();
                    v_Login.LoginUser();
                  
                }
                else
                {
                    Console.WriteLine("Menu Yang anda Pilih Tidak ada");
                    Console.Clear();
                    printMenu();
                }

                

            }
            else
            {
                Console.WriteLine(" Mohon Masukan Angka");
                Console.WriteLine("Klik Enter to menu");
                Console.ReadLine();
                Console.Clear();
                printMenu();
            }
        }

        public void Owner()
        {
            Console.WriteLine("Selamat Datang DiMenu Owner" + Environment.NewLine);
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
                    Console.Clear() ;
                    c_Owner = new C_Owner();
                    c_Owner.GetallOwner();
                    Console.WriteLine("klik enter " + Environment.NewLine);
                    Console.ReadLine();
                    Console.Clear();
                    Owner();


                }
                else if (pilihMenu == 2)
                {
                    Console.Clear();
                    c_Owner = new C_Owner();
                    c_Owner.InsertOwner();
                    Console.WriteLine("klik enter " + Environment.NewLine);
                    Console.ReadLine();
                    Console.Clear();
                    Owner();

                }
                else if (pilihMenu == 3)
                {
                    Console.Clear();
                    c_Owner = new C_Owner();
                    c_Owner.UpdateOwner();
                    Console.WriteLine("klik enter " + Environment.NewLine);
                    Console.ReadLine();
                    Console.Clear();
                    Owner();

                }
                else if (pilihMenu == 4)
                {
                    Console.Clear();
                    c_Owner = new C_Owner();
                    c_Owner.DeleteOwner();
                    Console.WriteLine("klik enter" + Environment.NewLine);
                    Console.ReadLine();
                    Console.Clear();
                    Owner();
                }
                else if (pilihMenu == 5)
                {
                    Console.Clear();
                    c_Owner = new C_Owner();
                    c_Owner.search();
                    Console.WriteLine("klik enter" + Environment.NewLine);
                    Console.ReadLine();
                    Console.Clear();
                    Owner();

                }
                else if (pilihMenu == 6)
                {
                    Console.Clear();
                    printMenu();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Menu Yang anda Pilih Tidak ada");
                    Owner();
                }

                Owner();

            }
            else
            {
                Console.WriteLine(" Mohon Masukan Angka");
                Console.WriteLine("Klik Enter to menu");
                Console.ReadLine();
                Console.Clear();
                Owner();
            }

        }

        public void Masterdata()
        {
            Console.WriteLine("Selamat Datang Di Menu Master data" + Environment.NewLine);
            Console.WriteLine("1.Supplier  ");
            Console.WriteLine("2.Produk  ");
            Console.WriteLine("3.StokMasuk ");
            Console.WriteLine("4.Back");
            Console.WriteLine("Pilih Menu Anda !!");

            bool menuError = int.TryParse(Console.ReadLine(), out int pilihMenu);

            if (menuError == true)
            {
                if (pilihMenu == 1)
                {
                    Console.Clear();
                    V_Supplier suppliers = new V_Supplier();
                    suppliers.supplier();


                }
                else if (pilihMenu == 2)
                {
                    Console.Clear();
                    V_Produk produk = new V_Produk();
                    produk.produk();

                }
                else if (pilihMenu == 3)
                {
                    Console.Clear();
                    V_Stok_Masuk v_Stok_Masuk = new V_Stok_Masuk();
                    v_Stok_Masuk.StokMasuk();

                }
                else if (pilihMenu == 4)
                {
                    Console.Clear();
                    printMenu();
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
