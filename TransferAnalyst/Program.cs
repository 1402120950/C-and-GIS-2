using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SuperMap.SampleCode.Analyst.TrafficAnalyst
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
        /// The main entry
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormMain());
		}
	}
}


