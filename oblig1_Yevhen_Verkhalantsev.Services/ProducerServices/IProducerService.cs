using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.Services.ProducerServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.Response;

namespace oblig1_Yevhen_Verkhalantsev.Services.ProducerServices;

public interface IProducerService
{
    Task<ResponseService> Create(CreateProducerHttpPostModel createProducerHttpPostModel);

    ICollection<ProducerEntity> GetAll();

    Task<ResponseService<ProducerEntity>> GetById(long id);

    Task<ResponseService> Update(UpdateProducerHttpPostModel vm);

}