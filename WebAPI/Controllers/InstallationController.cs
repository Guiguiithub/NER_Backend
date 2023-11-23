using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using WebAPI.Models;
using WebAPI.Extensions;
using DAL.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class InstallationController : ControllerBase
    {
        private readonly InstallationContext _context;
        public InstallationController(InstallationContext context)
        {
            _context = context;
        }

        [HttpGet("api/Installations")]
        public async Task<ActionResult<IEnumerable<InstallationM>>> GetInstallations()
        {
            if (_context.Installations == null)
            {
                return NotFound();
            }

            var installationList = await _context.Installations.ToListAsync();
            if (installationList == null)
            {
                return NotFound();
            }
            var installationsM = new List<InstallationM>();
            foreach (var installation in installationList)
            {
                installationsM.Add(installation.ConvertToInstallationM());
            }
            return installationsM;
        }

        [HttpPost("api/Installations")]
        public async Task<ActionResult<InstallationM>> PostInstallation(InstallationM installationM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var installation = installationM.ConvertToInstallation();

            _context.Installations.Add(installation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstallation", new { id = installation.Id }, installation.ConvertToInstallationM());
        }
    }
}
