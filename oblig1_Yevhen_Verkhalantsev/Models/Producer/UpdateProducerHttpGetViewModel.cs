using oblig1_Yevhen_Verkhalantsev.Database.Entities;

namespace oblig1_Yevhen_Verkhalantsev.Models.Producer;

public class UpdateProducerHttpGetViewModel
{
    public ProducerEntity Producer { get; set; }
    public bool IsError { get; set; }
    public string ErrorMessage { get; set; }
}