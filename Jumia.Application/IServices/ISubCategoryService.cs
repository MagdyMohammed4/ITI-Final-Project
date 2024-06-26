﻿using Jumia.Application.Contract;
using Jumia.Dtos.SubCategory;
using Jumia.DTOS.ViewResultDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia.Application.Services.IServices
{
    public interface ISubCategoryService
    {

        Task<ResultView<CreateOrUpdateSubDto>> Create(CreateOrUpdateSubDto subcategoryDto, IFormFile image);


        Task<ResultView<CreateOrUpdateSubDto>> Update(CreateOrUpdateSubDto subcategoryDto, IFormFile image);

        Task<ResultView<CreateOrUpdateSubDto>> Delete(CreateOrUpdateSubDto subcategoryDto);

        Task<ResultDataForPagination<GetAllSubDto>> GetAll(int item, int pagnumber);

        Task<ResultView<CreateOrUpdateSubDto>> GetOne(int id);
        Task<ResultDataForPagination<GetAllSubDto>> GetByCategoryId(int catId);









    }
}
