using FinalProject.Controller;
using FinalProject.Models;
using FinalProject.Repositories;
using FinalProject.View;

namespace FinalProject;

    class Program
{
    static void Main(string[] args)
    {
        /*    V_Owner v_Owner = new V_Owner();

          v_Owner.printMenu();*/

        V_Login v_Login = new V_Login();
        v_Login.LoginUser();

        /* C_Supplier Supplier = new C_Supplier();
            Supplier.Delete();*/

        /* Stok_MasukQuery stok_KeluarQuery = new Stok_MasukQuery();
         Console.WriteLine(stok_KeluarQuery.getQty(1));*/





    }
}
