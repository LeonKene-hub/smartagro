namespace SmartAgroAPI.Models;

/// <summary>
/// The category of the sensor, it shows the type of the farm
/// Ex: If the sensor's farm is a tuber farm
/// </summary>
public partial class Categoria
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
}
