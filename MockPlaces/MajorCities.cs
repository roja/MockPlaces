using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace MockPlaces
{
	public static class MajorCities
	{
		public static MajorCity Random()
		{
			return QueryCities("SELECT * FROM Cities ORDER BY RANDOM() LIMIT 1;").Single();
		}

		public static MajorCity RandomFrom(string countryCode)
		{
			return QueryCities("SELECT * FROM Cities WHERE CountryCode == @CountryCode ORDER BY RANDOM() LIMIT 1;", new { CountryCode = countryCode }).Single();
		}

		private static IEnumerable<MajorCity> QueryCities(string query, object paramaters = null)
		{
			using (IDbConnection con = new SQLiteConnection("Data Source=MajorCities.db"))
			{
				con.Open();

				return con.Query<MajorCity>(query, paramaters);
			}
		}
	}
}