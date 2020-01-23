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
using Microsoft.AspNet.OData.Builder;

namespace TobaccoStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository: IRepository<TEntity>
    {
      private readonly TRepository repository;
      public BaseController(TRepository repository)
      {
          this.repository = repository;
      }
      //GET: api/[controller]
      [HttpGet]
    [EnableQuery()]
      public async Task<ActionResult<List<TEntity>>> Get ()
      {
          return await repository.GetAll();
      }

      //GET: [controller]/5
      [HttpGet("{id}")]
      public async Task<ActionResult<TEntity>> Get(int id)
      {
          var entity = await repository.Get(id);
          if(entity == null)
          {
              return NotFound();
          }
          return entity;
      }
      // PUT: api/[controller]/5
      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, TEntity tobacco)
      {
          if (id != tobacco.Id)
          {
              return BadRequest();
          }
          await repository.Update(tobacco);
          return NoContent();
      }

      // POST: api/[controller]
      [HttpPost]
      public async Task<ActionResult<TEntity>> Post (TEntity tobacco)
      {
          await repository.Add(tobacco);
          return CreatedAtAction("Get", new{ id = tobacco.Id}, tobacco);
      }

      // DELETE: api/[controller]/5
      [HttpDelete("{id}")]

      public async Task<ActionResult<TEntity>> Delete (int id)
      {
          var entity = await repository.Delete(id);
          if(entity == null)
          {
              return NotFound();
          }
          return entity;
      }

             
    }
}
