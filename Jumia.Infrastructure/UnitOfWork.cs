﻿using Jumia.Application.Contract;
using Jumia.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly JumiaContext _jumiaContext;
        private readonly ILogger _logger;       // Assuming you have a logging mechanism
        private Hashtable _repositories;

        public UnitOfWork(JumiaContext jumiaContext, ILoggerFactory loggerFactory)
        {
            _jumiaContext = jumiaContext;
            _logger = loggerFactory.CreateLogger("UnitOfWorkLogs");
            _repositories = new Hashtable();
        }

        public ICategoryRepository CategoryRepository => GetRepository<ICategoryRepository, CategoryRepository>();
        public IOrderItemsRepository OrderItemsRepository => GetRepository<IOrderItemsRepository, OrderItemRepository>();
        public IOrderRepository OrderRepository => GetRepository<IOrderRepository, OrderRepository>();
        public IProductRepository ProductRepository => GetRepository<IProductRepository, ProductRepository>();
        public IReviewRepository ReviewRepository => GetRepository<IReviewRepository, ReviewRepository>();
        public IShippmentRepository ShippmentRepository => GetRepository<IShippmentRepository, ShippmentRepository>();
        public ISubCategoryRepository SubCategoryRepository => GetRepository<ISubCategoryRepository, SubCategoryRepository>();
        public ISpecificationRepository SpecificationRepository => GetRepository<ISpecificationRepository, SpecificationRepository>();

        public ISubCategorySpecificationRepository SubCategorySpecificationRepository => GetRepository<ISubCategorySpecificationRepository, SubCategorySpecificationRepository>();
        public IProductSpecificationSubCategoryRepository productSpecificationSubCategoryRepository => GetRepository<IProductSpecificationSubCategoryRepository, ProductSpecificationSubCategoryRepository>();
        public IBrandRepository BrandRepository => GetRepository<IBrandRepository, BrandRepository>();

        public async Task SaveChangesAsync()
        {
            try
            {
                await _jumiaContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when saving changes");
                // Depending on your error handling policy, you might want to rethrow, handle or log the exception
                throw; // Rethrow the exception if you want calling code to handle it
            }
        }

        public void Dispose()
        {
            _jumiaContext?.Dispose();
        }

        private TRepository GetRepository<TRepositoryInterface, TRepository>() where TRepository : TRepositoryInterface
        {
            var type = typeof(TRepository).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = Activator.CreateInstance(typeof(TRepository), _jumiaContext);
                _repositories.Add(type, repositoryInstance);
            }

            return (TRepository)_repositories[type];
        }

        //public UnitOfWork(JumiaContext jumiaContext
        //    //,ILoggerFactory loggerFactory
        //    )
        //{
        //    _jumiaContext = jumiaContext;
        //    //_logger = loggerFactory.CreateLogger("logs");
        //    //CategoryRepository = new CategoryRepository(_jumiaContext);
        //    //OrderItemsRepository = new OrderItemRepository(_jumiaContext);
        //    //OrderRepository = new OrderRepository(_jumiaContext);
        //    //PaymentRepository = new PaymentRepository(_jumiaContext);
        //    //ProductRepository = new ProductRepository(_jumiaContext);
        //    //ReviewRepository = new ReviewRepository(_jumiaContext);
        //    //ShippmentRepository = new ShippmentRepository(_jumiaContext);
        //    //SubCategoryRepository = new SubCategoryRepository(_jumiaContext);
        //}

        //public async Task SaveChangesAsync()
        //{
        //    await _jumiaContext.SaveChangesAsync();
        //}
        //public void Dispose()
        //{
        //    _jumiaContext?.Dispose();
        //}
        //public IRepository<TEntity, Tid> Repository<TEntity, Tid>() where TEntity : class
        //{
        //    if (_repositories == null) _repositories = new Hashtable();

        /* var type = typeof(TEntity).Name;

         if (!_repositories.ContainsKey(type))
         {
             var repositoryType = typeof(Repository<TEntity,Tid>);
             var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _jumiaContext);

             _repositories.Add(type, repositoryInstance);
         }

         return (IRepository<TEntity,Tid>)_repositories[type];*/

    }
}

