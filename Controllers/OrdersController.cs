﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TobaccoStore.Entities;
using TobaccoStore;
using TobaccoStore.Data;
using TobaccoStore.Data.EFCore;

namespace TobaccoStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController<OrderEntity, EFCoreOrderRepository>
    {
        public OrdersController(EFCoreOrderRepository repository) : base(repository)
        {
            
        }
    }
}
