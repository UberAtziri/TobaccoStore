using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TobaccoStore.Entities;
using TobaccoStore.Data;
using TobaccoStore.DTO;
using TobaccoStore.Data.EFCore;

namespace TobaccoStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TobaccoController : BaseController<TobaccoEntity, EFCoreTobaccoRepository>
    {
      private readonly EFCoreTobaccoRepository repository;
      public TobaccoController(EFCoreTobaccoRepository repository) : base(repository)
      {
        this.repository = repository;
      }
      [HttpGet("test")]
      public IQueryable<string> GetSomething()
      {
          return repository.GetName();
      }  
    }
}
