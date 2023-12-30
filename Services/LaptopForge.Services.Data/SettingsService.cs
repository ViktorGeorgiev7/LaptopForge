namespace LaptopForge.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LaptopForge.Data.Common.Repositories;
    using LaptopForge.Data.Models;
    using LaptopForge.Services.Mapping;

    public class SettingsService : ISettingsService
    {
        private readonly DeletableEntityRepository<Setting> settingsRepository;

        public SettingsService(DeletableEntityRepository<Setting> settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public int GetCount()
        {
            return this.settingsRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.settingsRepository.All().To<T>().ToList();
        }
    }
}
