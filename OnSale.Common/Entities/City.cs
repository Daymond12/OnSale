using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnSale.Common.Entities
{
    public class City
    {
        public int Id { get; set; }

        [MaxLength (50, ErrorMessage ="the field {0} must contain less than {1} characters")]
        [Required]
        public string Name { get; set; }


        //Esta propiedad me serviá a mi para saber a que Departamento pertenece esta ciudad
        //NotMapped es para que no guarde ese campo ese campo en la BD, porque ya hay un DepartmentId
        [JsonIgnore]
        [NotMapped]
        public int IdDepartment { get; set; }

        //un departamento pertenece a una ciudad
         [JsonIgnore]
        public Department Department { get; set; }

    }

}
