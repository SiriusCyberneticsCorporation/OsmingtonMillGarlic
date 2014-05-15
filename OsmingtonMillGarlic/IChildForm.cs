using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsmingtonMillGarlic
{
	public interface IChildForm
	{
		bool CanClose();
		void RefreshDisplay();
	}
}
