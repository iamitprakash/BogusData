using System;
namespace BogusData.Data;
using Bogus;

public class DataGenerator
{
	Faker<PersonModel> personModelfekar;

	public DataGenerator()
	{
		Randomizer.Seed = new Random(123);

		personModelfekar = new Faker<PersonModel>()
			.RuleFor(u => u.Id, f => f.Random.Int(1, 1000))
			.RuleFor(u => u.FirstName, f => f.Name.FirstName())
			.RuleFor(u => u.LastName, f => f.Name.LastName())
			.RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
			.RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
			.RuleFor(u => u.StreetAddress, f => f.Address.StreetAddress())
			.RuleFor(u => u.City, f => f.Address.City())
			.RuleFor(u => u.State, f => f.Address.StateAbbr())
			.RuleFor(u => u.Zip, f => f.Address.ZipCode())
			.RuleFor(u => u.Rating, f => f.PickRandom<PublicRating>());

	}

	public PersonModel GeneratePerson()
	{
		return personModelfekar.Generate();
	}

	public IEnumerable<PersonModel> GenerateBulk()
	{
		return personModelfekar.GenerateForever();
	}
}

