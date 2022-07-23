﻿using ArmenianChairDogsitting.Business.Exceptions;
using ArmenianChairDogsitting.Business.Interfaces;
using ArmenianChairDogsitting.Business.ExceptionsStorage;
using ArmenianChairDogsitting.Data.Entities;
using ArmenianChairDogsitting.Data.Repositories.Interfaces;

namespace ArmenianChairDogsitting.Business.Services;

public class SitterService : ISitterService
{
    ISitterRepository _sitterRepository;

    public SitterService(ISitterRepository sitterRepository)
    {
        _sitterRepository = sitterRepository;
    }

    public int Add(Sitter sitter) => _sitterRepository.Add(sitter);

    public Sitter? GetById(int id) => _sitterRepository.GetById(id);

    public List<Sitter> GetSitters() => _sitterRepository.GetSitters();

    public void RemoveById(int id)
    {
        var sitter = _sitterRepository.GetById(id);

        if (sitter == null)
            throw new NotFoundException($"{ExceptionMessage.ChoosenSitterDoesNotExist}{id}");

        sitter.IsDeleted = true;

        _sitterRepository.RemoveOrRestoreById(sitter);
    }
    
    public void RestoreById(int id)
    {
        var sitter = _sitterRepository.GetById(id);

        if (sitter == null)
            throw new NotFoundException($"{ExceptionMessage.ChoosenSitterDoesNotExist}{id}");

        sitter.IsDeleted = false;

        _sitterRepository.RemoveOrRestoreById(sitter);
    }

    public void Update(Sitter sitterForUpdate, int id)
    {
        var sitter = _sitterRepository.GetById(id);

        if (sitter == null)
            throw new NotFoundException($"{ExceptionMessage.ChoosenSitterDoesNotExist}{id}");

        sitter.Name = sitterForUpdate.Name;
        sitter.LastName = sitterForUpdate.LastName;
        sitter.Phone = sitterForUpdate.Phone;
        sitter.Age = sitterForUpdate.Age;
        sitter.Experience = sitterForUpdate.Experience;
        sitter.Sex = sitterForUpdate.Sex;
        sitter.Description = sitterForUpdate.Description;

        _sitterRepository.Update(sitter);
    }

    public void UpdatePassword(int id, Sitter passwordSitterForUpadate)
    {
        var sitter = _sitterRepository.GetById(id);

        if (sitter == null)
            throw new NotFoundException($"{ExceptionMessage.ChoosenSitterDoesNotExist}{id}");

        sitter.Password = passwordSitterForUpadate.Password;

        _sitterRepository.UpdatePassword(sitter);
    }

    public void UpdatePriceCatalog(int id, List<PriceCatalog> priceCatalog)
    {
        var sitter = _sitterRepository.GetById(id);

        if (sitter == null)
            throw new NotFoundException($"{ExceptionMessage.ChoosenSitterDoesNotExist}{id}");

        sitter.PricesCatalog = priceCatalog;

        _sitterRepository.UpdatePriceCatalog(sitter);
    }
}