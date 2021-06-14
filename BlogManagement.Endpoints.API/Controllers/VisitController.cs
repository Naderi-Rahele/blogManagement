
using BlogManagement.Core.ApplicationServices.Visits;
using BlogManagement.Core.Domain.Visits;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VisitManagement.Endpoints.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitsController : ControllerBase
    {
        private readonly VisitApplicationService _visitApplicaitonService;

        public VisitsController(VisitApplicationService visitApplicaitonService)
        {
            _visitApplicaitonService = visitApplicaitonService;
        }

        [HttpPost]
        public IActionResult Add(Visit VisitForAdd)
        {
            _visitApplicaitonService.Add(VisitForAdd);
            return Ok();
        }

      
    }
}
