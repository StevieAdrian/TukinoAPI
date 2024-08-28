namespace TukinoAPI.Model
{
  public class Anime
  {
    public int Id { get; set; }
    public string? Title { get; set; }
    public int? Episodes { get; set; }
    public string? Genre { get; set; }
    public string? Studio { get; set; }
    public string? Description { get; set; }
    public double? Rating { get; set; }
    public byte[]? Image { get; set; }
  }
  
}