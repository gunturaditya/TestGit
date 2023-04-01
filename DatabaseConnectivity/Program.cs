using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

namespace DatabaseConnectivity;

class Program
{
    static string ConnectionString = "Data Source=LAPTOP-5T8LAEAU;Database=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;";

    static SqlConnection connection;

    static void Main(string[] args)
    {

        DatabaseQuery query = new DatabaseQuery();     // class DatabaseQuery dengan objek query
        query.view();                               //  object query dengan method untuk menampilkan data

        Region region = new Region();
       Console.WriteLine("masukan Region");
        region.name = Console.ReadLine();       //  object query dengan method untuk menyimpan data berdasarkan paramater
        Console.Clear();                        //  set region.name dari class region
        query.insert(region);
        query.view();


        Console.WriteLine("Masukan Id");
        region.id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("masukan Region");            // object query dengan method untuk update data berdasarkan paramater
        region.name = Console.ReadLine();               // set region.id dan region.name dari class region
        Console.Clear();
        query.update(region);
        query.view();

        Console.WriteLine("Masukan Id");
        int id = Convert.ToInt32(Console.ReadLine());   // object query dengan method untuk delete berdasarkan paramater id
        query.delete(id);

        Console.WriteLine("Masukan Id");
        int id1 = Convert.ToInt32(Console.ReadLine());  //object query dengan method untuk find berdasarkan paramater id
        query.viewByid(id1);




        /*connection = new SqlConnection(ConnectionString);
        connection.Open();
        Console.WriteLine("Berhasil di buka");*/
        // GetAllRegion();
        //InsertRegion("Cahya Asia");
        //  GetAllbyId(2);
        /*   Console.WriteLine("masukan Id");
            int id = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine("masukan region");
                var name = Console.ReadLine();*/
        // Console.Clear();
        //updateDataRegion(id, name);
        //DeleteRegion(id);


        // region.name = "ASIA tenggara";
        /*        Console.WriteLine("Masukan Id");
                region.id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Masukan Region");*/


        //  region.id = Convert.ToInt32(Console.ReadLine());


        // query.insert(region);
    }
    

   /* public static void GetAllRegion()            // membuat method view,update,insert dan delete di 1 class Main 
    {
        connection = new SqlConnection(ConnectionString);

        //Membuat instance untuk command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM region";

        //Membuka koneksi
        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("====================");
                Console.WriteLine("ID " + " " + " Region");
                Console.WriteLine(reader[0] + "    " + reader[1]);
                Console.WriteLine("====================");
            }
        }
        else
        {
            Console.WriteLine("Data not found!");
        }
        reader.Close();
        connection.Close();
    }

    // GETBYID : REGION (Command)

    public static void GetAllbyId(int id)
    {
        connection = new SqlConnection(ConnectionString);
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "viewtableRegionbyid";
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();

            SqlParameter Pname = new SqlParameter();
            Pname.ParameterName = "@regionid";
            Pname.Value = id;
            Pname.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(Pname);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("====================");
                    Console.WriteLine("ID "+"  "+" Region");
                    Console.WriteLine(reader[0]+"  "+ reader[1]);
                    Console.WriteLine("====================");

                }
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
            reader.Close();
            connection.Close();
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    // INSERT : REGION (Transaction)
    public static void InsertRegion(string name)
    {
        connection = new SqlConnection(ConnectionString);

        //Membuka koneksi
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            //Membuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO region (name) VALUES (@name)";
            command.Transaction = transaction;

            //Membuat parameter
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar;

            //Menambahkan parameter ke command
            command.Parameters.Add(pName);

            //Menjalankan command
            int result = command.ExecuteNonQuery();
            transaction.Commit();

            if (result > 0)
            {
                Console.WriteLine("Data berhasil ditambahkan!");
            }
            else
            {
                Console.WriteLine("Data gagal ditambahkan!");
            }

            //Menutup koneksi
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }
    }
    // UPDATE : REGION (Transaction)
    public static void updateDataRegion(int id,String region)
    {
       
        connection = new SqlConnection(ConnectionString);
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
       
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "update region set name = @name where id = @id";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName= "@id";
            pName.Value = id;
            pName.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pName);

            SqlParameter pName1 = new SqlParameter();
            pName1.ParameterName = "@name";
            pName1.Value = region;
            pName1.SqlDbType= SqlDbType.VarChar;

            command.Parameters.Add(pName1);

            int result = command.ExecuteNonQuery();
            transaction.Commit();
            if(result > 0)
            {
                Console.WriteLine("Data berhasil diedit!");
                GetAllRegion();
            }
            else
            {
                Console.WriteLine("Data Gagal diEdit!");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }
        

    }

    // DELETE : REGION (Transaction)
    public static void DeleteRegion(int id)
    {
        connection = new SqlConnection(ConnectionString);
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "delete from region where id=@id";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@id";
            pName.Value = id;
            pName.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pName);


            int result = command.ExecuteNonQuery();
            transaction.Commit();
            if (result > 0)
            {
                Console.WriteLine("Data berhasil didelete!");
                GetAllRegion();
            }
            else
            {
                Console.WriteLine("Data Gagal didelete!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }
    }*/

}

    
