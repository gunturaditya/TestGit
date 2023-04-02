using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseConnectivity
{
    public class DatabaseQuery : Abstrac<Region> // Class DatabseQuery sebagai untuk membuat fungsi semua method dan code
    {                                           
        string ConnectionString = "Data Source=LAPTOP-5T8LAEAU;Database=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;";
                                            // var Connection untuk ambil dan connec ke database sqlServer
        SqlConnection connection;
        public DatabaseQuery()
        {
            connection = new SqlConnection(ConnectionString);       //supaya setiap memanggil class DatabaseQuery langsung connec database
            connection.Open();
        }

        public void viewByid(int id) // method view table berdasarkan paramater int id
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = "viewtableRegionbyid"; // menggunakan Storeprecedure 
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
                        Console.WriteLine("ID " + "  " + " Region");
                        Console.WriteLine(reader[0] + "  " + reader[1]);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void delete(int id)  //method delete untuk menghapus data berdasarkan paramater id
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "delete from region where id=@id"; // query delete database
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
        
    }

        public void insert(Region obj)  // Method inser untuk memasukan data ke database dengan paramater class Region dengan var obj
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO region (name) VALUES (@name)"; //query database insert
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.Value = obj.name;
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

        public void update(Region obj) // method update database dengan paramater class Region 
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
           
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "updRegion"; // mengunakan procedure
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@id";
                pName.Value = obj.id;
                pName.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pName);

                SqlParameter pName1 = new SqlParameter();
                pName1.ParameterName = "@region";
                pName1.Value = obj.name;
                pName1.SqlDbType = SqlDbType.VarChar;

                command.Parameters.Add(pName1);

                int result = command.ExecuteNonQuery();
                transaction.Commit();
                if (result > 0)
                {
                    Console.WriteLine("Data berhasil diedit!");
                   
                }
                else
                {
                    Console.WriteLine("Data Gagal diEdit!");
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
        }

        public void view() // method menampilkan isi table di database
        {


            //Membuat instance untuk command
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM region"; // dengan quary database

            //Membuka koneksi
          
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

      
    }
}
