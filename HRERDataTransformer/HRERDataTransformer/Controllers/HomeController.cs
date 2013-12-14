using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRERDataTransformer.App_Data;

namespace HRERDataTransformer.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var conn =
				"Data Source=guadalupe.cloudapp.net;Initial Catalog=humanityroad;Persist Security Info=True;User ID=humanityroad;Password=Password1!";
			DataTable dt = new DataTable("content");
			var command = new SqlCommand("select * from content order by state, AgencyType", new SqlConnection(conn));
			DataAdapter da = new SqlDataAdapter(command);

			var ds = new DataSet();
			da.Fill(ds);
			dt = ds.Tables[0];

			var reader = new AgencyReader(dt);
			var agencies = reader.GetAgencies();



			return View(agencies);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}