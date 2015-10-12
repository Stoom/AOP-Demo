using System;

namespace AopDemo.Interfaces
{
	public interface IAudit
	{
		DateTime CreatedOn { get; set; }
		DateTime AccessedOn { get; set; }
		DateTime ModifiedOn { get; set; }
	}
}

