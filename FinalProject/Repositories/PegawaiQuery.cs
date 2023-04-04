using FinalProject.Interface;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class PegawaiQuery : Abstrac<Pegawai>
    {
        String ConnectionString = "Data Source=LAPTOP-5T8LAEAU;Database=project_Final;Integrated Security=True;Connect Timeout=30;";
        SqlConnection connection;
        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public void insert(Pegawai obj)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tbl_pegawai (Name,username,password,status) VALUES (@name,@username,@password,@status)"; //query database insert
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.Value = obj.Name;
                pName.SqlDbType = SqlDbType.VarChar;
                //Menambahkan parameter ke command
                command.Parameters.Add(pName);

                SqlParameter pNama2 = new SqlParameter();
                pNama2.ParameterName = "@password";
                pNama2.Value = obj.Password;
                pNama2.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pNama2);

                SqlParameter pNama1 = new SqlParameter();
                pNama1.ParameterName = "@username";
                pNama1.Value = obj.Username;
                pNama1.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pNama1);

                SqlParameter pNama3 = new SqlParameter();
                pNama3.ParameterName = "@status";
                pNama3.Value = 0;
                pNama3.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pNama3);


                //Menjalankan command
                int result = command.ExecuteNonQuery();
                transaction.Commit();

                if (result > 0)
                {
                    Console.WriteLine("berhasil buat akun!");
                }
                else
                {
                    Console.WriteLine("gagal buat akun!");
                }

                //Menutup koneksi
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        public bool Login(string username, string password)
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tbl_pegawai where username =@username and password = @password";

                SqlParameter pNama1 = new SqlParameter();
                pNama1.ParameterName = "@username";
                pNama1.Value = username;
                pNama1.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pNama1);

                SqlParameter pNama2 = new SqlParameter();
                pNama2.ParameterName = "@password";
                pNama2.Value = password;
                pNama2.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pNama2);


                using SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    if (reader[4].ToString() == "1")
                    {
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Tunggu Owner Validasi");
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
           
        }

        public void Search(string name)
        {
            throw new NotImplementedException();
        }

        public void update(Pegawai obj, int id)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "update tbl_pegawai set status=@status where id=@id"; //query database update
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@status";
                pName.Value = obj.Status;
                pName.SqlDbType = SqlDbType.Int;
                //Menambahkan parameter ke command
                command.Parameters.Add(pName);

                SqlParameter pNama3 = new SqlParameter();
                pNama3.ParameterName = "@id";
                pNama3.Value = id;
                pNama3.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pNama3);

                //Menjalankan command
                int result = command.ExecuteNonQuery();
                transaction.Commit();

                if (result > 0)
                {
                    Console.WriteLine("Data pegawai berhasil di validasi");
                }
                else
                {
                    Console.WriteLine("Data gagal divalidasi");
                }

                //Menutup koneksi
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        public void View()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_pegawai where status = 0"; // dengan quary database

            //Membuka koneksi

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Console.WriteLine("=========================================================");
                    Console.WriteLine("ID " + "  " + " Nama" + "   " + "Status");
                    Console.WriteLine(reader[0] + "    " + reader[1] + "         " + reader[4]);
                    Console.WriteLine("===========================================================");

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
