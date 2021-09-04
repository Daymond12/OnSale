using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnSale.Common.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

    [Display(Name = "Image")]
    public Guid ImageId { get; set; }

    //TODO: Pending to put the correct paths
    [Display(Name = "Image")]
    public string ImageFullPath => ImageId == Guid.Empty
        ? $"https://https://localhost:44355/images/noimage.png"
        : $"http://127.0.0.1:10000/devstoreaccount1/products/{ImageId}";

    }
}
