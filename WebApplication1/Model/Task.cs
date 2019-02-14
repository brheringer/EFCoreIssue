using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
	public class Task
	{
        public virtual int Id { get; set; }
		public virtual string Summary { get; set; }

		public Task()
		{
		}

		public override bool Equals(object obj)
		{
			if( obj == null ) return false;
			if( Object.ReferenceEquals(obj, this) ) return true;
			if( ! (obj is Task) ) return false;
			Task outro = (Task)obj;
			return this.Id == outro.Id;
		}

		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
