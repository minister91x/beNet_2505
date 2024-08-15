using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DTO
{
    public class Product
    {
        [Key]
        public int ProdductID { get; set; }
        public string ProdductName { get; set; }
        public int Price { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CreatedUser { get; set; }
    }

    public class ProductGetListRequestData
    {
        public string? ProdductName { get; set; }
    }
}
