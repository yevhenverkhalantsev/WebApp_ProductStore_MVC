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

    public ICollection<ProducerEntity> GetAll()
    {
        return _producerRepository.GetAll().ToList();
    }

    public async Task<ResponseService<ProducerEntity>> GetById(long id)
    {
        ProducerEntity producer = await _producerRepository.GetById(id);
        if (producer == null)
        {
            return ResponseService<ProducerEntity>.Error("Don't exist with current id");
        }

        return ResponseService<ProducerEntity>.Ok(producer);
    }

    public async Task<ResponseService> Update(UpdateProducerHttpPostModel vm)
    {
        ProducerEntity producerEntity = await _producerRepository.GetById(vm.Id);
        if (producerEntity == null)
        {
            return ResponseService.Error("Bad producers id");
        }

        producerEntity.Name = vm.Name;
        producerEntity.Description = vm.Description;
        producerEntity.Adress = vm.Address;

        try
        {
            await _producerRepository.Update(producerEntity);
        }
        catch (Exception e)
        {
            return ResponseService.Error(e.Message);
        }

        return ResponseService.Ok();
    }
}