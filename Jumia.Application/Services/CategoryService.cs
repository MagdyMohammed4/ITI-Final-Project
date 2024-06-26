﻿using AutoMapper;
using Jumia.Application.Contract;
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
using Jumia.Application.Services.IServices;
using Jumia.Dtos.Shippment;

namespace Jumia.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper )
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

                var CategoryWithSameImage = Data.FirstOrDefault(c => c.Image.SequenceEqual(categoryDto.Image));
                if (CategoryWithSameImage != null)
                {
                    return new ResultView<CreateOrUpdateCategoryDto> { Entity = null, IsSuccess = false, Message = "Cannot add the same image for a category added before" };
                }

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
       public async Task<ResultView<CreateOrUpdateCategoryDto>> Update(CreateOrUpdateCategoryDto categoryDto, IFormFile image)
        {
            
            var OldCategory = await _repository.GetOneAsync(categoryDto.Id);
            if (OldCategory == null) 
            {
                return new ResultView<CreateOrUpdateCategoryDto> { Entity = null, IsSuccess = false, Message = "Category Not Found!" };

            }


            var Data = await _repository.GetAllAsync();
            var CategoryWithSameImage = Data.FirstOrDefault(c => c.Id != categoryDto.Id && c.Image.SequenceEqual(categoryDto.Image));

            if (CategoryWithSameImage != null)
            {
                return new ResultView<CreateOrUpdateCategoryDto> { Entity = null, IsSuccess = false, Message = "image already in use by another category." };
            }


            if (image == null || image.Length == 0)
             {
                    categoryDto.Image = OldCategory.Image;
             }
            else
            {
                    
                    using (var memoryStream = new MemoryStream())
                    {
                        await image.CopyToAsync(memoryStream);
                        categoryDto.Image = memoryStream.ToArray();
                    }
             }

              


                _mapper.Map(categoryDto, OldCategory);

                var UPCategory = await _repository.UpdateAsync(OldCategory);
                await _repository.SaveChangesAsync();
                var CategoryDto = _mapper.Map<CreateOrUpdateCategoryDto>(UPCategory);

                return new ResultView<CreateOrUpdateCategoryDto> { Entity = CategoryDto, IsSuccess = true, Message = "Category Updated Successfully" };
            



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

               var res= await _repository.DeleteAsync(category);
               var res1= await _repository.SaveChangesAsync();

                var CategoryDto = _mapper.Map<CreateOrUpdateCategoryDto>(res);
                return new ResultView<CreateOrUpdateCategoryDto> { Entity = categoryDto, IsSuccess = true, Message = "Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultView<CreateOrUpdateCategoryDto> { Entity = null, IsSuccess = false, Message = ex.Message };
            }
        }



        // GetAll
        public async Task<ResultDataForPagination<GetAllCategoryDto>> GetAll(int item , int pagnumber)
        {
            var AllData =( await _repository.GetAllAsync());
            var Category = AllData.Skip(item * (pagnumber - 1)).Take(item).ToList();
            var Categorys = _mapper.Map<List<GetAllCategoryDto>>(Category);

            var totalItems = AllData.Count(c => c.IsDeleted != true);
            var totalPages = (int)Math.Ceiling((double)totalItems / item);

            var resultDataFor = new ResultDataForPagination<GetAllCategoryDto>
            {
                Entities = Categorys,
                count = totalItems,
                TotalPages = totalPages,
                CurrentPage = pagnumber,
                PageSize = item
            };

            return resultDataFor;

        }




        //GetOne
        public async Task<ResultView<CreateOrUpdateCategoryDto>> GetOne(int id)
        {
            var Category = await _repository.GetOneAsync(id);
            if (Category == null)
            {
                return new ResultView<CreateOrUpdateCategoryDto> { Entity = null, IsSuccess = false, Message = "Not Found!" };
            }
            else
            {
                var CategoryDto = _mapper.Map<CreateOrUpdateCategoryDto>(Category);

                return new ResultView<CreateOrUpdateCategoryDto> { Entity = CategoryDto, IsSuccess = true, Message = "Succses" };
            }
        }











       








































    }
}
