using Microsoft.EntityFrameworkCore;
using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.EntityFramework.Repository;
using oblig1_Yevhen_Verkhalantsev.Services.ProducerServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.Response;

namespace oblig1_Yevhen_Verkhalantsev.Services.ProducerServices;

public class ProducerService : IProducerService

{
    private readonly IGenericRepository<ProducerEntity> _producerRepository;

    public ProducerService(IGenericRepository<ProducerEntity> repository)
    {
        _producerRepository = repository;
    }

    public async Task<ResponseService> Create(CreateProducerHttpPostModel createProducerHttpPostModel)
    {
        ProducerEntity dbRecord = new ProducerEntity()
        {
            Name = createProducerHttpPostModel.Name,
            Description = createProducerHttpPostModel.Description,
            Adress = createProducerHttpPostModel.Address
        };

        try
        {
            await _producerRepository.Create(dbRecord);
        }
        catch (Exception ex)
        {
            return ResponseService.Error(ex.Message);
        }

        return ResponseService.Ok();
    }

    public async Task<ICollection<ProducerEntity>> GetAll()
    {
        return await _producerRepository.GetAll().ToListAsync();
    }
}