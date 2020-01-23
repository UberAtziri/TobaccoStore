using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TobaccoStore.Controllers;
using TobaccoStore.Data;
using TobaccoStore.Data.EFCore;
using TobaccoStore.Entities;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController<RoleEntity, EFCoreRoleRepository>
    {
       public RolesController(EFCoreRoleRepository repository) : base(repository)
       {
           
       }
    }
}
