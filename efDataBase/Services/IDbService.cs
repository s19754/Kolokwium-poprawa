using efDataBase.Models;
using efDataBase.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efDataBase.Services
{
    public interface IDbService
    {
        Task<bool> DoesAlbumExist(int idAlbum);
        Task<IEnumerable<SomeKindOfAlbum>> GetAlbum(int idAlbum);
        Task<bool> DeleteMusician(int id);
        Task<bool> DoesMusicianExist(int idMusician);
        Task<bool> DoesMusicianCanBeRemowed(int idMusician);
        //Task<bool> AddZamowienie(int klientID, AddZamowienie request);
        //Task<bool> CheckWyroby(IEnumerable<SomeSortOfWyrobCukierniczy> wyroby);

    }
}
