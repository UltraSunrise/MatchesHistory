using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CreateHeroesTables.Data;
using CreateHeroesTables.Data.Entities;
using MatchesHistory.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CreateHeroesTables
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string json = string.Empty;

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end")
                    break;

                json += line;
            }

            List<Hero> heroes = JsonConvert.DeserializeObject<RootObject>(json).Heroes;

            using (var db = new MatchesHistoryDbContext())
            {
                foreach (Hero currentHero in heroes)
                {
                    string imageFull = string.Format("C:\\Users\\User\\Desktop\\DotaProject\\HeroesFull\\{0}_full.png", currentHero.Name);

                    var currentImageFull = Image.FromFile(imageFull);

                    currentHero.ImageFull = ImageToByteArray(currentImageFull);

                    string imageOver = string.Format("C:\\Users\\User\\Desktop\\DotaProject\\HeroesOver\\{0}_hphover.png", currentHero.Name);

                    var currentImageOver = Image.FromFile(imageOver);

                    currentHero.ImageOver = ImageToByteArray(currentImageOver);

                    db.Heroes.Add(currentHero);
                }

                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT SomeDotes.dbo.Heroes ON;");
                db.SaveChanges();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT SomeDotes.dbo.Heroes OFF;");
            }
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
