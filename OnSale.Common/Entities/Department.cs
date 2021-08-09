using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnSale.Common.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "the field {0} must contain less than {1} characters")]
        [Required]
        public string Name { get; set; }

        //propiedad que me sirve para hacer la relación con ciudades
        public ICollection<City> Cities { get; set; }

        [DisplayName("Cities Number")]
        //para saber cuantas ciudades tiene un departamento creo una propiedad de solo lectura
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;


        //Esta propiedad me serviá a mi para saber a que País pertenece este Departamento
        //NotMapped es para que no guarde ese campo ese campo en la BD, porque ya hay un CountryId
        [JsonIgnore]
        [NotMapped]
        public int IdCountry { get; set; }

        //relacion mas fuerte para evitar borrado en cascada
        //un departamento pertenece a un pais
        [JsonIgnore]
        public Country Country { get; set; }

    }

}
