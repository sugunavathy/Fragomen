using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopSphere.Models
{
    public class order_items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int item_id { get; set; }
        public int order_id { get; set; }
        public string product_name { get; set; } = string.Empty;
        public int quantity { get; set; }
        public string state { get;  set; } = "Draft";
    }
}
