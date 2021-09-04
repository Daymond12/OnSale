using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnSale.Common.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }

        //relación con producto,una order detaill tiene un producto
        //un producto puede estar en muchas OrderDetais
        public Product Product { get; set; }

        public float Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public decimal Value => (decimal)Quantity * Price;
    }

}
