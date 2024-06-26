﻿using Jumia.Dtos.Category;
using Jumia.Dtos.User;
using Jumia.DTOS.ViewResultDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia.Application.Services.IServices
{
    public interface IUserService 
    { 
        Task<ResultDataForPagination<GetAllUsers>> GetAll();
        Task<ResultView<GetAllUsers>> CreateAsync( GetAllUsers getAllUsers);
        Task<ResultView<GetAllUsers>> Delete(GetAllUsers getAllUsers);
        Task<ResultView<GetAllUsers>> GetOne(int id);
      

    }
}
