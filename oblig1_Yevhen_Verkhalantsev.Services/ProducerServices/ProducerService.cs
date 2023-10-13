using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.EntityFramework.Repository;

namespace oblig1_Yevhen_Verkhalantsev.Services.ProducerServices;

public class ProducerService: IProducerService

{
    private readonly IGenericRepository<ProducerEntity> _producerRepository;

    public ProducerService(IGenericRepository<ProducerEntity> repository)
    {
        _producerRepository = repository;
    }
}