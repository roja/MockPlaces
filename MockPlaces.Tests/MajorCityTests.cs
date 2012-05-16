namespace MockPlaces.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class MajorCityTests
	{
		[Test]
		public void ShouldReturnARandomCity()
		{
			var result = MajorCities.Random();
			var result2 = MajorCities.Random();

			Assert.That(result.Name, Is.Not.EqualTo(result2.Name));
		}

		[Test]
		public void ShouldReturnARandomCityFromUK()
		{
			var result = MajorCities.RandomFrom("GB");

			Assert.That(result.CountryCode, Is.EqualTo("GB"));
		}
	}
}
