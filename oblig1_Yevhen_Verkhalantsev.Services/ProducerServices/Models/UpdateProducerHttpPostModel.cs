namespace oblig1_Yevhen_Verkhalantsev.Services.ProducerServices.Models;

public class UpdateProducerHttpPostModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
}