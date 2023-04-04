using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Produk 
    {
        public int Id { get; set; }

        public int id_Supplier { get; set; }
        public string produk { get; set; }
        public int Harga { get; set; }

        public int Qty { get; set; }

        public int TotalHarga { get; set; }

    }
}
