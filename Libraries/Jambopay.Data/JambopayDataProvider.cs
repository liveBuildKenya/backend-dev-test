using Jambopay.Core;
using Jambopay.Core.Domain;
using Jambopay.Core.Infrastructure;
using Jambopay.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Jambopay.Data
{
    public class JambopayDataProvider : DbContext, IJambopayDataProvider
    {
        #region Ctor

        public JambopayDataProvider()
        {

        }

        public JambopayDataProvider(DbContextOptions<JambopayDataProvider> options) : base(options)
        {

        }

        #endregion

        #region Utilities

        /// <summary>
        /// Further configuration of the model
        /// </summary>
        /// <param name="modelBuilder">Builder being use to construct the context model</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string filePath = (new Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
            string[] segments = filePath.Split('/');
            filePath = "";

            for (int iterator = 0; iterator < segments.Length - 1; iterator++)
            {
                filePath += "/" + segments[iterator];
            }

            filePath = filePath.Substring(1);
            CommonHelper.DefaultFileProvider = new JambopayFileProvider(filePath);
            filePath = filePath + "/App_Data/dataSettings.json";

            var dataSettings = DataSettingsManager.LoadSettings(filePath);

            if (dataSettings.DataProvider == DataProviderType.SqlServer)
            {
                optionsBuilder.UseSqlServer(dataSettings.ConnectionString);
            }
        }

        #endregion

        #region Methods

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        #endregion
    }
}
