﻿using AutoMapper;
using Jumia.Application.Contract;
using Jumia.Application.IServices;
using Jumia.Application.Services.IServices;
using Jumia.Dtos.Category;
using Jumia.DTOS.ViewResultDtos;
using Jumia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Jumia.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //Create
        public async Task<ResultView<CreateOrUpdateCategoryDto>> Create(CreateOrUpdateCategoryDto categoryDto, IFormFile image)
        {
            var Data = await _repository.GetAllAsync();
            var OldCategory = Data.Where(c => c.Name == categoryDto.Name).FirstOrDefault();

            if (OldCategory != null)
            {
                return new ResultView<CreateOrUpdateCategoryDto> { Entity = null, IsSuccess = false, Message = "Category Already Exist" };

            }
            else
            {

                if (image != null && image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await image.CopyToAsync(memoryStream);
                        categoryDto.Image = memoryStream.ToArray();
                    }
                }


                var Category = _mapper.Map<Category>(categoryDto);
                var NewCategory = await _repository.CreateAsync(Category);
                await _repository.SaveChangesAsync();
                var CategoryDto = _mapper.Map<CreateOrUpdateCategoryDto>(NewCategory);


                return new ResultView<CreateOrUpdateCategoryDto> { Entity = CategoryDto, IsSuccess = true, Message = "Category Created Successfully" };
            }


        }



        //Update
<<<<<<< HEAD
        public async Task<ResultView<CreateOrUpdateCategoryDto>> Update(CreateOrUpdateCategoryDto categoryDto)
        {
            var Data = await _repository.GetAllAsync();
            var OldCategory = Data.FirstOrDefault(c => c.Name == categoryDto.Name && c.Id == categoryDto.Id);
            if (OldCategory == null)
=======
       public async Task<ResultView<CreateOrUpdateCategoryDto>> Update(CreateOrUpdateCategoryDto categoryDto, IFormFile image)
        {
            
            var OldCategory = await _repository.GetOneAsync(categoryDto.Id);
            if (OldCategory == null) 
>>>>>>> refs/rewritten/mergeCategory-SubCategory
            {
                return new ResultView<CreateOrUpdateCategoryDto> { Entity = null, IsSuccess = false, Message = "Category Not Found!" };

            }
            else
            {
                //_mapper.Map<Category>(categoryDto);
                _mapper.Map(categoryDto, OldCategory);

                if (image != null && image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await image.CopyToAsync(memoryStream);
                        OldCategory.Image = memoryStream.ToArray();
                    }
                }


                
                var UPCategory = await _repository.UpdateAsync(OldCategory);
                await _repository.SaveChangesAsync();
                var CategoryDto = _mapper.Map<CreateOrUpdateCategoryDto>(UPCategory);

                return new ResultView<CreateOrUpdateCategoryDto> { Entity = CategoryDto, IsSuccess = true, Message = "Category Updated Successfully" };
            }



        }



        // delete
        public async Task<ResultView<CreateOrUpdateCategoryDto>> Delete(CreateOrUpdateCategoryDto categoryDto)
        {
            try
            {
                var category = await _repository.GetOneAsync(categoryDto.Id);
                if (category == null)
                {
                    return new ResultView<CreateOrUpdateCategoryDto> { Entity = null, IsSuccess = false, Message = "Category Not Found!" };
                }

                await _repository.DeleteAsync(category);
                await _repository.SaveChangesAsync();

                var CategoryDto = _mapper.Map<CreateOrUpdateCategoryDto>(category);
                return new ResultView<CreateOrUpdateCategoryDto> { Entity = categoryDto, IsSuccess = true, Message = "Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultView<CreateOrUpdateCategoryDto> { Entity = null, IsSuccess = false, Message = ex.Message };
            }
        }



        // GetAll
        public async Task<ResultDataForPagination<GetAllCategoryDto>> GetAll(int item, int pagnumber)
        {
            var AllData = await _repository.GetAllAsync();
            var Categorys = AllData.Skip(item * (pagnumber - 1)).Take(item)
             .Select(c => new GetAllCategoryDto
             {
                 Id = c.Id,
                 Name = c.Name,
                 Description = c.Description,
                 Image = c.Image,


             }).ToList();

            ResultDataForPagination<GetAllCategoryDto> resultDataFor = new ResultDataForPagination<GetAllCategoryDto>();

            resultDataFor.Entities = Categorys;
            resultDataFor.count = AllData.Count(c => c.IsDeleted != true);


            return resultDataFor;

        }




        //GetOne
        public async Task<ResultView<GetAllCategoryDto>> GetOne(int id)
        {
            var Category = await _repository.GetOneAsync(id);
            if (Category == null)
            {
                return new ResultView<GetAllCategoryDto> { Entity = null, IsSuccess = false, Message = "Not Found!" };
            }
            else
            {
                var CategoryDto = _mapper.Map<GetAllCategoryDto>(Category);

                return new ResultView<GetAllCategoryDto> { Entity = CategoryDto, IsSuccess = true, Message = "Succses" };
            }
        }




















































    }
}
