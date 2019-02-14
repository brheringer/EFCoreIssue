using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		XDbContext dbContext;

		public ValuesController(XDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[]
			{
				"/api/values/create",
				"/api/values/test"
			};
		}

		[HttpGet]
		[Route("create")]
		public ActionResult<IEnumerable<string>> CreateStuff()
		{
			dbContext.Database.EnsureDeleted();
			dbContext.Database.EnsureCreated();

			var task1 = new WebApplication1.Model.Task() { Summary = "task 1" };
			dbContext.TaskDbSet.Add(task1);

			var task2 = new WebApplication1.Model.Task() { Summary = "task 2" };
			dbContext.TaskDbSet.Add(task2);

			var sprint = new Sprint() { InitialDate = new DateTime(), FinalDate = new DateTime() };
			sprint.SprintBacklog.Add(new SprintBacklogItem() { PlannedSprint = sprint, PlannedTask = task1 });
			sprint.SprintBacklog.Add(new SprintBacklogItem() { PlannedSprint = sprint, PlannedTask = task2 });
			dbContext.SprintDbSet.Add(sprint);

			dbContext.SaveChanges();
			return Ok("");
		}

		[HttpGet]
		[Route("test")]
		public ActionResult<IEnumerable<string>> Test()
		{
			string txt = "";
			var sprint = dbContext.SprintDbSet.Find(1);
			txt += sprint.Id + ":";
			foreach (var item in sprint.SprintBacklog)
				txt += item.Id + "," + item.PlannedSprint.Id + "," + item.PlannedTask.Id + ". ";
			return Ok(txt);
		}
	}
}
