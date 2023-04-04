using FinalProject.Interface;
using FinalProject.Models;
using FinalProject.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FinalProject.Repositories
{
    public class OwnerQuery : Abstrac<Owner>
    {
       
        String ConnectionString = "Data Source=LAPTOP-5T8LAEAU;Database=project_Final;Integrated Security=True;Connect Timeout=30;";
        SqlConnection connection;
        public void Search(String name)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_owner where username like '%'+@name+'%'"; // dengan quary database

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar;
            //Menambahkan parameter ke command
            command.Parameters.Add(pName);

            //Membuka koneksi

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("====================");
                    Console.WriteLine("ID " + "  " + " Name" + "   " + "Username" + "  " + "Password");
                    Console.WriteLine(reader[0] + "    " + reader[1] + "    " + reader[2] + "    " + reader[3]);
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

        public void delete(int id)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "delete tbl_owner where id=@id"; //query database insert
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@id";
                pName.Value = id;
                pName.SqlDbType = SqlDbType.Int;
                //Menambahkan parameter ke command
                command.Parameters.Add(pName);


                //Menjalankan command
                int result = command.ExecuteNonQuery();
                transaction.Commit();

                if (result > 0)
                {
                    Console.WriteLine("Data berhasil diDelete!");
                }
                else
                {
                    Console.WriteLine("Data gagal diDelete!");
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

        public void insert(Owner obj)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tbl_owner (Name,username,password) VALUES (@name,@username,@password)"; //query database insert
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

        public void update(Owner obj,int id)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "update tbl_owner set Name = @name ,username =@username,password=@password where id=@id"; //query database update
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
                pNama3.ParameterName = "@id";
                pNama3.Value = id;
                pNama3.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pNama3);

                //Menjalankan command
                int result = command.ExecuteNonQuery();
                transaction.Commit();

                if (result > 0)
                {
                    Console.WriteLine("Data berhasil diEdit");
                }
                else
                {
                    Console.WriteLine("Data gagal diEdit!");
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
            command.CommandText = "SELECT * FROM tbl_owner"; // dengan quary database

            //Membuka koneksi

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Console.WriteLine("====================");
                    Console.WriteLine("ID " + "  " + " Name" + "   " + "Username" + "  " + "Password");
                    Console.WriteLine(reader[0] + "    " + reader[1] + "    " + reader[2] + "    " + reader[3]);
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

        public bool Login(String username,String password)
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tbl_owner where username =@username and password=@password";

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

                if (reader.Read())
                {
                    return true;
                }
             else {
                    Console.WriteLine(" Tekan Enter");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Gagal Login");
                 V_Login v_Login = new V_Login();
                    v_Login.LoginUser();
                        
                  }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
         return false;

        }
    }
}
