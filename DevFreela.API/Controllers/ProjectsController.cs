using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        public ProjectsController(DevFreelaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var projects = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Where(p => !p.IsDeleted ).ToList();

            var model = projects.Select(ProjectViewModel.FromEntity).ToList();

            return Ok(model);                                                         
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == id);

            var model = ProjectItemViewModel.FromEntity(project);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            var project =  model.ToEntity();

            _context.Projects.Add(project); 
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = project.Id }, model);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            if (id != model.IdProject)
            {
                return BadRequest();
            }

            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if(project is null)
            {
                return NotFound();
            }

            project.Update(model.Title , model.Description , model.TotalCost);

            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
         
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return NotFound();
            }

            project.SetAsDeleted();
            _context.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return NotFound();
            }

            project.Start();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return NotFound();
            }

            project.Complete();
            _context.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return NotFound();
            }

            var comment = new ProjectCommment(model.Content,model.Idproject,model.IdUser);
            _context.ProjectCommments.Add(comment);
            _context.SaveChanges();

            return Ok();
        }
    }
}
