using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Db;
using Server.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentAnalysisController : ControllerBase
    {
        private readonly CongreeLangDbContext _context;

        public DocumentAnalysisController(CongreeLangDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<DocumentAnalysisResponseDTO>> DocumentAnalysis([FromBody] DocumentAnalysisRequestDTO request)
        {
            return null;
        }
    }
}
