using Microsoft.EntityFrameworkCore;
using System;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Seeds
{
    public class SeedController:IDisposable
    {
        private readonly ModelBuilder ModelBuilder;
        public SeedController(ModelBuilder builder)
        {
            ModelBuilder = builder;
        }
        public void Dispose()
        {
            //Need to do anything for disposing the variables, currently it is not needed
        }

        internal void Execute()
        {
            UserSeeder.Execute(ModelBuilder);
        }
    }
}
