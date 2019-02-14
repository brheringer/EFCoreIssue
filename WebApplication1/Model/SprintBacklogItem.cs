using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
	public class SprintBacklogItem
	{
        public virtual int Id { get; set; }
		public virtual Sprint PlannedSprint { get; set; }
		public virtual Task PlannedTask { get; set; }

		public virtual int PlannedSprintId { get; set; }
		public virtual int PlannedTaskId { get; set; }

		public SprintBacklogItem()
		{
		}

		public override bool Equals(object obj) {
			if (obj == null) return false;
			if (Object.ReferenceEquals(obj, this)) return true;
			if (!(obj is SprintBacklogItem)) return false;
			SprintBacklogItem outro = (SprintBacklogItem)obj;
			if (this.Id > 0 && this.Id == outro.Id)
				return true;
			else return
				object.Equals(this.PlannedSprintId, outro.PlannedSprintId) &&
				object.Equals(this.PlannedTaskId, outro.PlannedTaskId);
		}

		public override int GetHashCode() {
			int s = 0;
			if (this.PlannedSprint != null)
				s = this.PlannedSprint.GetHashCode();
			int t = 0;
			if (this.PlannedTask != null)
				t = this.PlannedTask.GetHashCode();
			return s * 137 + t;
		}

	}
}
