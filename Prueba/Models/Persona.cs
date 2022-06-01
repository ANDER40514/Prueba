using System.ComponentModel.DataAnnotations;

namespace Prueba.Models
{
    public class Persona { 
         
            public int ID { get; set; }
 
            public string Nombre { get; set; } = string.Empty;

            [DataType(DataType.Date)]
            public DateTime FechaDeNacimiento { get; set; }
         
    }

}
