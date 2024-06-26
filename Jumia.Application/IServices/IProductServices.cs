﻿using Jumia.Dtos.Product;
using Jumia.Dtos.Reports;
using Jumia.DTOS.ViewResultDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia.Application.IServices
{
    public interface IProductServices
    {
        Task<ResultView<CreateOrUpdateProductDto>> Create(CreateOrUpdateProductDto product, List<IFormFile> images);

        //    Task<ResultView<CreateOrUpdateProductDTO>> HardDelete(CreateOrUpdateProductDTO product);
        //    Task<ResultView<CreateOrUpdateProductDTO>> SoftDelete(CreateOrUpdateProductDTO product);
        Task<ResultDataForPagination<GetAllProducts>> GetAllPagination(int items, int pagenumber);
        Task<ResultView<CreateOrUpdateProductDto>> GetOne(int ID);
        Task<ResultView<CreateOrUpdateProductDto>> Update(CreateOrUpdateProductDto productDto, List<IFormFile> images);
        Task<ResultView<CreateOrUpdateProductDto>> Delete(CreateOrUpdateProductDto productDto);
        Task<ResultView<GetAllProducts>> Getbyname(string name);
        Task<ResultDataForPagination<GetAllProducts>> GetOrderedAsc();
        Task<ResultDataForPagination<GetAllProducts>> GetOrderedDsc();
        Task<ResultDataForPagination<GetAllProducts>> GetNewestArrivals();
        Task<ResultDataForPagination<GetAllProducts>> Search(string PartialName);
        Task<ResultDataForPagination<GetAllProducts>> FilterByPriceRange(int MinPrice, int MaxPrice);
        Task<ResultDataForPagination<GetAllProducts>> FilterByBrandName(int BrandId);
        Task<ResultDataForPagination<GetAllProducts>> FilterByBrandList(List<int> BrandIdList);
        Task<ResultDataForPagination<GetAllProducts>> FilterByDiscountRange(int MinDisc);
        Task<ResultDataForPagination<GetAllProducts>> FilterByDiscountRangeToSlider(int MinDisc, int items, int pagenumber);
        Task<ResultDataForPagination<GetAllProducts>> GetNewestArrivalsToSlider(int items, int pagenumber);
        Task<ResultDataForPagination<GetAllProducts>> FilterByAll(List<int>? BrandIdList, int? MinPrice, int? MaxPrice, int? MinDisc);
        Task<ResultDataForPagination<GetAllProducts>> FilterByAll(List<int>? BrandIdList, int? MinPrice, int? MaxPrice, int? MinDisc, int items, int pagenumber);
        Task<ResultDataForPagination<GetAllProducts>> GetProductsByCategoryId(int CategoryId, int items, int pagenumber);
        Task<ResultDataForPagination<GetAllProducts>> GetProductsBySubCategoryId(int SubCategoryId, int items, int pagenumber);
        Task<ResultDataForPagination<GetAllProducts>> GetOrderedAscWithPagination(int items, int pagenumber);
        Task<ResultDataForPagination<GetAllProducts>> GetOrderedDscWithPagination(int items, int pagenumber);
        Task<ResultDataForPagination<GetAllProducts>> GetNewestArrivalsWithPagination(int items, int pagenumber);
        Task<ResultView<CreateOrUpdateProductDto>> UpdateQuantity(CreateOrUpdateProductDto productDto);
        Task<List<GetAllProducts>> GetOutOfStockProducts();
        Task<List<GetAllProducts>> GetProductsAlmostFinished(int threshold);
        Task<List<TopProductDTO>> GetTopProductsSold();
        Task<List<OrdersPerMonthDTO>> GetOrdersPerMonth();
        Task<TotalAmountDTO> GetTotalAmount();

    }
}
