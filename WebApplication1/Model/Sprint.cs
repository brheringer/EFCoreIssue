using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Model
{
	public class Sprint
	{
        public virtual int Id { get; set; }
		public virtual DateTime InitialDate { get; set; }
		public virtual DateTime FinalDate { get; set; }
		public virtual IList<SprintBacklogItem> SprintBacklog { get; set; }

		public Sprint() : base()
		{
		}
	}
}
