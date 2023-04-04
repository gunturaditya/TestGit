using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Interface;

namespace FinalProject.Repositories
{
    public class ProdukQuery : Abstrac<Produk>
    {
        String ConnectionString = "Data Source=LAPTOP-5T8LAEAU;Database=project_Final;Integrated Security=True;Connect Timeout=30;";
        SqlConnection connection;
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
                command.CommandText = "delete tbl_produk where id=@id"; //query database insert
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


        public void insert(Produk obj)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tbl_produk (id_Supplier,produk,harga,qty,TotalHarga) VALUES (@id_Supplier,@produk,@harga,@qty,@TotalHarga)"; //query database insert
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@id_Supplier";
                pName.Value = obj.id_Supplier;
                pName.SqlDbType = SqlDbType.Int;
                //Menambahkan parameter ke command
                command.Parameters.Add(pName);

                SqlParameter pNama2 = new SqlParameter();
                pNama2.ParameterName = "@produk";
                pNama2.Value = obj.produk;
                pNama2.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pNama2);

                SqlParameter pNama1 = new SqlParameter();
                pNama1.ParameterName = "@harga";
                pNama1.Value = obj.Harga;
                pNama1.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pNama1);

                SqlParameter pNama3 = new SqlParameter();
                pNama3.ParameterName = "@qty";
                pNama3.Value = obj.Qty;
                pNama3.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pNama3);

                SqlParameter pNama4 = new SqlParameter();
                pNama4.ParameterName = "@TotalHarga";
                pNama4.Value = obj.Harga * obj.Qty;
                pNama4.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pNama4);

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



        public void Search(string name)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_produk where produk like '%'+@name+'%'"; // dengan quary database

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
                    Console.WriteLine("=============================================================================================================");
                    Console.WriteLine("ID " + "     " + " Supplier" + "      " + "Produk" + "     " + "harga" + "     " + "QTY" + "     " + "Total Harga");
                    Console.WriteLine(reader[0] + "        " + reader[1] + "          " + reader[2] + "      " + reader[3] + "    " + reader[4] + "         " + reader[5]);
                    Console.WriteLine("===============================================================================================================");

                }
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
            reader.Close();
            connection.Close();
        }

        public void update(Produk obj, int id)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "update tbl_produk set id_supplier=@id_Supplier,produk=@produk,harga=@harga,qty=@qty,TotalHarga=@TotalHarga where id =@id"; //query database insert
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@id_Supplier";
                pName.Value = obj.id_Supplier;
                pName.SqlDbType = SqlDbType.Int;
                //Menambahkan parameter ke command
                command.Parameters.Add(pName);

                SqlParameter pNama2 = new SqlParameter();
                pNama2.ParameterName = "@produk";
                pNama2.Value = obj.produk;
                pNama2.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pNama2);

                SqlParameter pNama1 = new SqlParameter();
                pNama1.ParameterName = "@harga";
                pNama1.Value = obj.Harga;
                pNama1.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pNama1);

                SqlParameter pNama3 = new SqlParameter();
                pNama3.ParameterName = "@qty";
                pNama3.Value = obj.Qty;
                pNama3.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pNama3);

                SqlParameter pNama4 = new SqlParameter();
                pNama4.ParameterName = "@TotalHarga";
                pNama4.Value = obj.Harga * obj.Qty;
                pNama4.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pNama4);

                SqlParameter pNama5 = new SqlParameter();
                pNama5.ParameterName = "@id";
                pNama5.Value = id;
                pNama5.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pNama5);

                //Menjalankan command
                int result = command.ExecuteNonQuery();
                transaction.Commit();

                if (result > 0)
                {
                    Console.WriteLine("Data berhasil diedit");
                }
                else
                {
                    Console.WriteLine("Data gagal diedit!");
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
            command.CommandText = "select a.id,b.Supplier,a.produk,a.harga,a.qty,a.TotalHarga from tbl_produk a inner join tbl_supplier b on a.id_Supplier = b.id"; // dengan quary database

            //Membuka koneksi

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Console.WriteLine("=============================================================================================================");
                    Console.WriteLine("ID " + "     " + " Supplier" + "      " + "Produk" + "     " + "harga"+"     "+"QTY"+"     "+"Total Harga");
                    Console.WriteLine(reader[0] + "    " + reader[1] + "    " + reader[2] + "    " + reader[3] + "     " + reader[4]+"         " + reader[5]);
                    Console.WriteLine("===============================================================================================================");

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
