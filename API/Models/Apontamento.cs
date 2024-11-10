using System.ComponentModel.DataAnnotations;

namespace API.Models
{
  public class Apontamento
  {
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public DateTime Data { get; set; }
    public int EscritorioId { get; set; }
    public required Usuario Usuario { get; set; }

  }
}