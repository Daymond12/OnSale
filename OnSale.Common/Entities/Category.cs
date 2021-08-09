using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnSale.Common.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "the field {0} must contain less than {1} characters")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths
        //Modelo que viene sin imagen
        //si la imagen viene vacia ?noimage : container

        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://https://localhost:44355/images/noimage.png"
            : $"http://127.0.0.1:10000/devstoreaccount1/categories/{ImageId}";

    }
}
