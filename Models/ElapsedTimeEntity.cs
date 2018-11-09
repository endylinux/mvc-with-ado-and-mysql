using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWithADO.Models
{
	public class ElapsedTimeEntity
	{
		public long LastTime = 0;
		public long TotalTime = 0;
		public int Count = 0;
		public long MinTime = long.MaxValue;
		public long MaxTime = long.MinValue;
		
		public double Average
		{
			get { return (TotalTime / Count); }
		}

		public DateTime MinDate;
		public DateTime MaxDate;
		public DateTime LastDate;
	}
}