using System.ComponentModel.DataAnnotations;

namespace OnSale.Common.Request
{
    public class EmailRequest
    {
        [EmailAddress]
        [Required]
        //Esta propiedad va aquí debido al @ que conlleva la cadena correo
        //un @ no se puede mandar por querySting, se debe mandar por el body
        public string Email { get; set; }
    }
}
