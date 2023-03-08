using System;
using System.Collections.Generic;
using Alura.SubastaOnline.WebApp.Models;
using Alura.SubastaOnline.WebApp.Data;

namespace Alura.SubastaOnline.WebApp.Seeding
{
    public static class DatabaseGenerator
    {
        public static void Seed()
        {
            using (var ctx = new AppDbContext())
            {
                if (ctx.Database.EnsureCreated())
                {
                    var generator = new SubastaRandomGenerator(new Random());
                    var subastas = new List<Subasta>();
                    for (var i = 1; i <= 200; i++)
                    {
                        subastas.Add(generator.NuevaSubasta);
                    }
                    ctx.Subastas.AddRange(subastas);
                    ctx.SaveChanges();
                }
            }
        }
    }
}