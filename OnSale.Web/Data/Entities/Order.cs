using OnSale.Common.Entities;
using OnSale.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSale.Web.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        //relacion con usuario, un usuario puede crear muchas ordenes
        public User User { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [Display(Name = "Date Sent")]
        public DateTime? DateSent { get; set; }

        [Display(Name = "Date Confirmed")]
        public DateTime? DateConfirmed { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        //relacion con OrderDetails, tiene una colección de OrderDetails
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public int Lines => OrderDetails == null ? 0 : OrderDetails.Count;//cuantos productos

        public float Quantity => OrderDetails == null ? 0 : OrderDetails.Sum(od => od.Quantity);//cantidad pedida

        public decimal Value => OrderDetails == null ? 0 : OrderDetails.Sum(od => od.Value);
    }

}
