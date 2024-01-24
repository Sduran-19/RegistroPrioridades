using System.ComponentModel.DataAnnotations;

namespace RegistroPrioridades.Models;

public class Prioridades
{
    [Key]
    public int PrioridadId { get; set; }

    [Required(ErrorMessage = "Este Campo es Obligatorio")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Este Campo es Obligatorio")]
    public string DiasCompromiso { get; set; }


}
