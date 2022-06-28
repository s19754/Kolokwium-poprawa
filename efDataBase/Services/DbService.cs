using efDataBase.Models;
using efDataBase.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efDataBase.Services
{
    public class DbService : IDbService
    {
        private readonly s19754Context _context;

        public DbService(s19754Context context)
        {
            _context = context;
        }



        public async Task<IEnumerable<SomeKindOfTeam>> GetTeam(int idTeam)
        {
            return await _context.Teams.Where(e => e.TeamID == idTeam).Include(e => e.Memberships).Include(e => e.Organization)
                .Select(e => new SomeKindOfTeam
                {
                    TeamName = e.TeamName,
                    TeamDescription = e.TeamDescription,
                    Organization = new SomeKindOfOrganization {OrganizationName = e.Organization.OrganizationName },
                    {
                        TrackName = e.TrackName,
                        Duration = e.Duration
                    }).OrderBy(e => e.Duration).ToList()
                }).ToListAsync();
        }

        public async Task<bool> DoesMusicianExist(int idMusician)
        {
            var musician = await _context.Musician.Where(e => e.IdMusician == idMusician).FirstOrDefaultAsync();
            if (musician is null) return false;
            return true;
        }

        public async Task<bool> DoesMusicianCanBeRemowed(int idMusician)
        {

            var tracks = await _context.Musician.Where(e => e.IdMusician == idMusician)
                .Include(e => e.Musician_Tracks)
                .Where(c => c.Musician_Tracks.Any(i => i.Track.IdMusicAlbum != null))
                .ToListAsync();

            if (tracks.Count() == 0) return true;
            return false;
        }


        //public async Task<bool> DeleteMusician(int Musician)
        //{

        //    var tracks = await _context.Musician.Where(e => e.IdMusician == Musician)
        //        .Include(e => e.Musician_Tracks)
        //        .Where(c => c.Musician_Tracks.Any(i => i.Track.IdMusicAlbum != null))
        //        .ToListAsync();

        //    if (tracks.Count() == 0)
        //    {
        //        var musician = await _context.Musician.Where(e => e.IdMusician == Musician).FirstOrDefaultAsync();
        //       foreach(var item in musician.Musician_Tracks)
        //        {
        //            _context.Remove(item);
        //        }
        //        _context.Remove(musician);

        //        await _context.SaveChangesAsync();

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}




        //}
        //public async Task<bool> AddZamowienie(int klientID, AddZamowienie request)
        //{
        //    using (var tran = await _context.Database.BeginTransactionAsync())
        //    {
        //        var klient = await _context.Klienci.Where(e => e.IdKlient == klientID).FirstOrDefaultAsync();
        //        var pracownik = await _context.Pracownicy.Where(e => e.IdPracownik == 1).FirstOrDefaultAsync();
        //        var zamowienie = new Zamowienie
        //        {
        //            DataPrzyjecia = request.DataPrzyjecia,
        //            Uwagi = request.Uwagi,
        //            Klient = klient,
        //            Pracownik = pracownik
        //        };
        //        _context.Add(zamowienie);

        //        await _context.SaveChangesAsync();

        //        foreach (var item in request.WyrobyCukiernicze)
        //        {
        //            var wyrob = await _context.WyrobyCukiernicze.Where(e => e.Nazwa == item.Wyrob).FirstOrDefaultAsync();
        //            var zamowienieWyrobCukierniczy = new Zamowienie_WyrobCukierniczy
        //            {
        //                IdZamowienia = zamowienie.IdZamowienia,
        //                IdWyrobuCukierniczego = wyrob.IdWyrobuCukierniczego,
        //                Ilosc = item.Ilosc,
        //                Uwagi = item.Uwagi
        //            };
        //            _context.Add(zamowienieWyrobCukierniczy);
        //        }

        //        await _context.SaveChangesAsync();
        //        await tran.CommitAsync();
        //        return true;
        //    }
        //}

        //public async Task<bool> CheckWyroby(IEnumerable<SomeSortOfWyrobCukierniczy> wyroby)
        //{
        //    foreach (var item in wyroby)
        //    {
        //        var wyrob = await _context.WyrobyCukiernicze.Where(e => e.Nazwa == item.Wyrob).FirstOrDefaultAsync();
        //        if (wyrob is null) return false;
        //    }
        //    return true;
        //}

        //public async Task<bool> DoesAlbumExist(int idAlbum)
        //{
        //    var album = await _context.Albums.Where(e => e.IdAlbum == idAlbum).FirstOrDefaultAsync();
        //    if (album is null) return false;
        //    return true;
        //}

        //public async Task<IEnumerable<SomeSortOfZamowienie>> GetZamowienia()
        //{
        //    return await _context.Zamowienia
        //        .Select(e => new SomeSortOfZamowienie
        //        {
        //            DataPrzyjecia = e.DataPrzyjecia,
        //            DataRealizacji = e.DataRealizacji,
        //            Uwagi = e.Uwagi,
        //            Klient = new SomeSortOfOsoba
        //            {
        //                Imie = e.Klient.Imie,
        //                Nazwisko = e.Klient.Nazwisko
        //            },
        //            Pracownik = new SomeSortOfOsoba
        //            {
        //                Imie = e.Pracownik.Imie,
        //                Nazwisko = e.Pracownik.Nazwisko
        //            },
        //            WyrobyCukiernicze = e.Zamowienie_WyrobCukiernicze.Select(e => new SomeSortOfZamowienieWyrobCukierniczy
        //            {
        //                Nazwa = e.WyrobCukierniczy.Nazwa,
        //                CenaZaSzt = e.WyrobCukierniczy.CenaZaSzt,
        //                Typ = e.WyrobCukierniczy.Typ,
        //                Ilosc = e.Ilosc,
        //                Uwagi = e.Uwagi
        //            })
        //        }).ToListAsync();


        //}


    }
}
