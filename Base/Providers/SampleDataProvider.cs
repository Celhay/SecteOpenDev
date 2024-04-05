using RefactoBase.Models;

namespace RefactoBase;

public class SampleDataProvider
{
    public IEnumerable<Animal> GetSampleData() => new List<Animal>
    {
        new()
        {
            Id = "d1",
            Age = 2,
            Species = "dog",
            Nickname = "lola",
            PhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.",
            PersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.",
            SuggestedDonation = 85.00m
        },
        new()
        {
            Id = "d2",
            Age = 9,
            Species = "dog",
            Nickname = "gus",
            PhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.",
            PersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.",
            SuggestedDonation = 49.99m
        },
        new()
        {
            Id = "c3",
            Age = 1,
            Species = "cat",
            Nickname = "snow",
            PhysicalDescription = "small white female weighing about 8 pounds. litter box trained.",
            PersonalityDescription = "friendly",
            SuggestedDonation = 40m
        },
        new()
        {
            Id = "c4",
            Age = null,
            Species = "cat",
            Nickname = "lion",
            PhysicalDescription = null,
            PersonalityDescription = null,
            SuggestedDonation = null
        }
    };
}