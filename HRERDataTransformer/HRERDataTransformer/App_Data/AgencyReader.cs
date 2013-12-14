using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using HRERDataTransformer.Models;

namespace HRERDataTransformer.App_Data
{
	public class AgencyReader
	{
		private readonly DataTable _agencyDataTable;
		public AgencyReader(DataTable dt)
		{
			_agencyDataTable = dt;
		}

		public List<AgencyModel> GetAgencies()
		{
			var agencies = (
				from DataRow currentAgencyRecord in _agencyDataTable.Rows
				select new AgencyModel
				{
					Name = GetValueAsString(currentAgencyRecord, "Name"),
					Twitter1 = GetValueAsString(currentAgencyRecord, "Twitter1"),
					Twitter2 = GetValueAsString(currentAgencyRecord, "Twitter2"),
					Twitter3 = GetValueAsString(currentAgencyRecord, "Twitter3"),
					Facebook1 = GetValueAsString(currentAgencyRecord, "Facebook1"),
					Facebook2 = GetValueAsString(currentAgencyRecord, "Facebook2"),
					Facebook3 = GetValueAsString(currentAgencyRecord, "Facebook3"),
					WebSite1 = GetValueAsString(currentAgencyRecord, "WebSite1"),
					WebSite2 = GetValueAsString(currentAgencyRecord, "WebSite2"),
					WebSite3 = GetValueAsString(currentAgencyRecord, "WebSite3"),
					City = GetValueAsString(currentAgencyRecord, "City"),
					County = GetValueAsString(currentAgencyRecord, "County"),
					State = GetValueAsString(currentAgencyRecord, "State"),
					AgencyType = GetValueAsString(currentAgencyRecord, "AgencyType")
				}).ToList();
			return agencies;
		}

		private static string GetValueAsString(DataRow currentAgencyRecord, string columnName)
		{
			return currentAgencyRecord[columnName] == DBNull.Value ? null : (string)currentAgencyRecord[columnName];
		}
	}
}