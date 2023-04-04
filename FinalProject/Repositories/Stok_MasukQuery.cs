using FinalProject.Interface;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalProject.Repositories
{
    public class Stok_MasukQuery : Abstrac<Stok_Masuk>
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
                command.CommandText = "delete tbl_stok_masuk where id=@id"; //query database insert
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

        public void insert(Stok_Masuk obj)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tbl_stok_masuk (id_produk,qty,tanggal) VALUES (@id_produk,@qty,@tanggal)"; //query database insert
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@id_produk";
                pName.Value = obj.id_produk;
                pName.SqlDbType = SqlDbType.Int;
                //Menambahkan parameter ke command
                command.Parameters.Add(pName);

                SqlParameter pNama2 = new SqlParameter();
                pNama2.ParameterName = "@qty";
                pNama2.Value = obj.qty;
                pNama2.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pNama2);

                SqlParameter pNama1 = new SqlParameter();
                pNama1.ParameterName = "@tanggal";
                pNama1.Value = obj.date;
                pNama1.SqlDbType = SqlDbType.Date;
                command.Parameters.Add(pNama1);
                //Menjalankan command
               
                var Qtyproduk = getQty(obj.id_produk);

                if (Qtyproduk >= obj.qty)
                {
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
                }
                else
                {
                    Console.WriteLine("qty produk kurang");
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
            throw new NotImplementedException();
        }

        public void update(Stok_Masuk obj, int id)
        {
            throw new NotImplementedException();
        }

        public void View()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_stok_masuk"; // dengan quary database

            //Membuka koneksi

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Console.WriteLine("=========================================================");
                    Console.WriteLine("ID " + "  " + " Produk" + "   " + "QTY" + "       " + "DATE");
                    Console.WriteLine(reader[0] + "    " + reader[1] + "         " + reader[2] + "        " + reader[3]);
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

        public int getQty(int id)
        {
            var qty = 0;
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT qty FROM tbl_produk where id=@id"; // dengan quary database

            //Membuka koneksi
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@id";
            pName.Value = id;
            pName.SqlDbType = SqlDbType.Int;
            //Menambahkan parameter ke command
            command.Parameters.Add(pName);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                   qty = reader.GetInt32(qty);

                }
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
            reader.Close();
            connection.Close();
            return qty;

        
        }

        public void Search(int id)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_produk where id=@id"; // dengan quary database

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@id";
            pName.Value = id;
            pName.SqlDbType = SqlDbType.Int;
            //Menambahkan parameter ke command
            command.Parameters.Add(pName);

            //Membuka koneksi

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    Console.WriteLine("=========================================================");
                    Console.WriteLine("ID " + "  " + " Produk" + "   " + "QTY" + "       " + "DATE");
                    Console.WriteLine(reader[0] + "    " + reader[1] + "         " + reader[2] + "        " + reader[3]);
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
