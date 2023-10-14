using oblig1_Yevhen_Verkhalantsev.Database.Entities;

namespace oblig1_Yevhen_Verkhalantsev.Models.Producer;

public class ProducersListHttpGetViewModel
{

   public ProducersListHttpGetViewModel()
   {
      Producers = new List<ProducerEntity>();
   }
   
   public ICollection<ProducerEntity> Producers { get; set; }
}