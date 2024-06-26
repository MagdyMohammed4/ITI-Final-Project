﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia.Application.Contract
{
    public interface IUnitOfWork 
    {
        ICategoryRepository? CategoryRepository { get; }
        IOrderItemsRepository? OrderItemsRepository { get; }
        IOrderRepository? OrderRepository { get; }
        IProductRepository? ProductRepository { get; }
        IReviewRepository? ReviewRepository { get; }
        IShippmentRepository? ShippmentRepository { get; }
        ISubCategoryRepository? SubCategoryRepository { get; }
        ISpecificationRepository? SpecificationRepository { get; }
        //IRepository<TEntity,Tid> Repository<TEntity,Tid>() where TEntity : class;
        public ISubCategorySpecificationRepository SubCategorySpecificationRepository { get; }
        public IProductSpecificationSubCategoryRepository productSpecificationSubCategoryRepository { get; }
        public IBrandRepository BrandRepository { get; }

        Task SaveChangesAsync();
    }
}
