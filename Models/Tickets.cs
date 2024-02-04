using System.ComponentModel.DataAnnotations;

namespace RegistroPrioridades.Models;

public class Tickets
{
    [Key]
    public int TicketId { get; set; }

    public DateTime Fecha { get; set; }

    public int ClienteId { get; set; }

    public int PrioridadId { get; set; }

    public int SistemaId { get; set; }

    [Required(ErrorMessage = "Solicitado es requerido")]
    public string? SolicitadoPor { get; set; }

    [Required(ErrorMessage = "El Asunto es requerido")]
    public string? Asunto { get; set; }

    [Required(ErrorMessage = "La descripción es requerida")]
    public string? Descripcion { get; set; }

}

