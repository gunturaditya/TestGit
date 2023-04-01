using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    public interface Abstrac <T> // Interface Abstrac berguna untuk override semua method di setiap class yg pakai interface
    {                              // Abstrac dengan variabel sementara T
        public void insert(T obj);
        public void update(T obj);
        public void delete(int id);

        public void viewByid(int id);
        public void view();
    }
}
