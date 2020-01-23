using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TobaccoStore.Data;
using TobaccoStore.Data.EFCore;
using TobaccoStore.DTO;
using TobaccoStore.Entities;

namespace TobaccoStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<UserEntity, EFCoreUsersRepository>
    {
       public UsersController(EFCoreUsersRepository repository) : base(repository)
       {
       }
    }
}
