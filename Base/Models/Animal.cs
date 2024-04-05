namespace RefactoBase.Models;

public class Animal
{
    // Properties of the animal
    public string Id { get; set; }
    public string Species { get; set; }
    public string? Nickname { get; set; }
    public int? Age { get; set; }
    public string? PhysicalDescription { get; set; }
    public string? PersonalityDescription { get; set; }
    public decimal? SuggestedDonation { get; set; }

    // Extension method for eachProperty to display correctly in the console
    public string IdToString() => "ID #: " + Id;
    public string SpeciesToString() => "Species: " + Species;
    public string AgeToString() => "Age: " + Age;
    public string NicknameToString() => "Nickname: " + Nickname;
    public string PhysicalDescriptionToString() => "Physical description: " + PhysicalDescription;
    public string PersonalityDescriptionToString() => "Personality: " + PersonalityDescription;
    public string SuggestedDonationToString() => "Suggested Donation: " + SuggestedDonation;
}