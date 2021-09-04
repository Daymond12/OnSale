using Microsoft.AspNetCore.Http;
using OnSale.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSale.Web.Models
{
    public class CategoryViewModel: Category
    {
        //yo no guardo imagenes en BD por eso está este viewModel
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
