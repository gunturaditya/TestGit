using FinalProject.Interface;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class SupplierQuery : Abstrac<Supplier>
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
                command.CommandText = "delete tbl_supplier where id=@id"; //query database insert
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


        public void insert(Supplier obj)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tbl_supplier (Supplier,jenis,alamat) VALUES (@supplier,@jenis,@alamat)"; //query database insert
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@supplier";
                pName.Value = obj.supplier;
                pName.SqlDbType = SqlDbType.VarChar;
                //Menambahkan parameter ke command
                command.Parameters.Add(pName);

                SqlParameter pNama2 = new SqlParameter();
                pNama2.ParameterName = "@jenis";
                pNama2.Value = obj.Jenis;
                pNama2.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pNama2);

                SqlParameter pNama1 = new SqlParameter();
                pNama1.ParameterName = "@alamat";
                pNama1.Value = obj.Alamat;
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



        public void Search(string name)
        {
            throw new NotImplementedException();
        }

        public void update(Supplier obj, int id)
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "update tbl_supplier set Supplier = @supplier ,jenis =@jenis,alamat=@alamat where id=@id"; //query database update
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@supplier";
                pName.Value = obj.supplier;
                pName.SqlDbType = SqlDbType.VarChar;
                //Menambahkan parameter ke command
                command.Parameters.Add(pName);

                SqlParameter pNama2 = new SqlParameter();
                pNama2.ParameterName = "@alamat";
                pNama2.Value = obj.Alamat;
                pNama2.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pNama2);

                SqlParameter pNama1 = new SqlParameter();
                pNama1.ParameterName = "@jenis";
                pNama1.Value = obj.Jenis;
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
            List<Supplier> suppliers = null;
            using(SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from tbl_supplier", cn);
                SqlDataReader Reader = cmd.ExecuteReader();
                suppliers = getList<Supplier>(Reader);
            }
            if(suppliers != null)
            {
               foreach (Supplier supplier in suppliers)
                {
                    Console.WriteLine("====================");
                    Console.WriteLine("ID " + "  " + " Supplier" + "   " + "Jenis" + "  " + "Alamat");
                    Console.WriteLine(supplier.id+" "+supplier.supplier+" " + supplier.Jenis+" "+ supplier.Alamat);
                }
               
            }
        }
        public List<T> getList<T>(IDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
            {
                var type = typeof(T);
                T obj = (T)Activator.CreateInstance(type);
                foreach (var item in type.GetProperties())
                {
                    var itemType = item.PropertyType;
                    item.SetValue(obj, Convert.ChangeType(reader[item.Name].ToString(), itemType));

                }
                list.Add(obj);
            }
            return list;

        }
    }
}
