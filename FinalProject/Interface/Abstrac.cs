using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Interface
{
    public interface Abstrac <T>
    {
        public void Search(String name);
        void update(T obj,int id);
        public void delete ( int id );

        public void insert(T obj);

        public void View();

        
        
    }
}
