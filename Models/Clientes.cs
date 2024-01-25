using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPrioridades.Models;

public class Cliente
{
    [Key]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Este Campo es Obligatorio")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "Este Campo es Obligatorio")]
    public int Telefono { get; set; }

    [Required(ErrorMessage = "Este Campo es Obligatorio")]
    public int Celular { get; set; }

    [Required(ErrorMessage = "Este Campo es Obligatorio")]
    public int Rnc { get; set; }

    [Required(ErrorMessage = "Este Campo es Obligatorio")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Este Campo es Obligatorio")]
    public string Direccion { get; set; }

  

}
