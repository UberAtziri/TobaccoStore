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

namespace TobaccoStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TobaccoController : ControllerBase
    {
        private readonly ITobaccoRepository _tobacco;
        private readonly IMapper _mapper;

        public TobaccoController(
            ITobaccoRepository tobacco,
            IMapper mapper)
        {
            _tobacco = tobacco;
            _mapper = mapper;
        }

        // GET: api/Tobacco
        [HttpGet, EnableQuery]
        
        public  ActionResult<List<TobaccoEntity>> GetTobacco()
        {
            return _tobacco.GetAll();
        }

        // GET: api/Tobacco/5
        [HttpGet("{id}")]
        public ActionResult<TobaccoEntity> GetSingleTobacco(int id)
        {
            var tobacco =  _tobacco.GetSingle(id);

            if (tobacco == null)
            {
                return NotFound();
            }

            return tobacco;
        }

        //PUT: api/Tobacco/5
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public ActionResult<TobaccoDto> UpdateTobacco(int id, [FromBody] TobaccoUpdateDto tobaccoUpdate)
        {
           if (tobaccoUpdate == null)
           {
               return BadRequest();
           }

           var existingTobaccoItem = _tobacco.GetSingle(id);
           if(existingTobaccoItem == null)
           {
               return NotFound();
           }

            _mapper.Map(tobaccoUpdate, existingTobaccoItem);

            _tobacco.Update(id, existingTobaccoItem);
            if(!_tobacco.Save())
            {
                throw new Exception ("Updating an item failed on save.");
            }
            return Ok(_mapper.Map<TobaccoDto>(existingTobaccoItem));
        }

        //POST: api/Tobacco
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<TobaccoEntity> PostTobacco(TobaccoCreateDto tobaccoCreate)
        {
            if(tobaccoCreate == null)
            {
                return BadRequest();
            }
            TobaccoEntity toAdd = _mapper.Map<TobaccoEntity>(tobaccoCreate);
            _tobacco.Add(toAdd);
            if(!_tobacco.Save())
            {
                throw new Exception("Creating a tobacco failed on save");
            }
            TobaccoEntity newTobacco = _tobacco.GetSingle(toAdd.Id);
            return CreatedAtRoute(nameof(GetSingleTobacco), _mapper.Map<TobaccoDto>(newTobacco));
           
        }

        // DELETE: api/Tobacco/5
        [HttpDelete("{id}")]
        public ActionResult<TobaccoEntity> DeleteTobacco(int id)
        {
           TobaccoEntity tobaccoItem = _tobacco.GetSingle(id);
           if(tobaccoItem == null)
           {
               return BadRequest();
           }
           _tobacco.Delete(id);

           if(!_tobacco.Save())
           {
               throw new Exception("Deleting tobacco failde on save");
           }
           return NoContent();
        }

        private bool isTobaccoExists(int id)
        {
           return _tobacco.Exist(id);
        }
    }
}
