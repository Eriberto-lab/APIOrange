public class Escritorio
{
  public int Id { get; set; }
  public string NomeEscritorio { get; set; } // "São Paulo" ou "Santos"
  public DayOfWeek DataDisponivel { get; set; } // Ex.: Tuesday para São Paulo, Thursday para Santos
  public TimeSpan HoraInicio { get; set; } = new TimeSpan(9, 0, 0);
  public TimeSpan HoraFim { get; set; } = new TimeSpan(18, 0, 0);
}
