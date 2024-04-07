using RefactoBase.Models;
using System;

namespace RefactoBase.Core;

public static class MenuActions
{
    public static void ListAllPetInfo(this IEnumerable<Animal> animals)
    {
        foreach (var currentAnimal in animals)
        {
            Console.WriteLine();
            Console.WriteLine(currentAnimal.IdToString());
            Console.WriteLine(currentAnimal.SpeciesToString());
            Console.WriteLine(currentAnimal.AgeToString());
            Console.WriteLine(currentAnimal.NicknameToString());
            Console.WriteLine(currentAnimal.PhysicalDescriptionToString());
            Console.WriteLine(currentAnimal.PersonalityDescriptionToString());
            Console.WriteLine(currentAnimal.SuggestedDonationToString());
        }

        Console.WriteLine();
    }
    public static void CompleteAgesAndPhysicalDescriptions(this IEnumerable<Animal> animals)
    {
        foreach (var currentAnimal in animals)
        {
            while (currentAnimal.Age is null)
            {
                Console.WriteLine($"Enter an age for {currentAnimal.IdToString()}");
                var ageInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(ageInput) && int.TryParse(ageInput, out var age))
                {
                    currentAnimal.Age = age;
                }
            }

            while (string.IsNullOrWhiteSpace(currentAnimal.PhysicalDescription))
            {
                Console.WriteLine(
                    $"Enter a physical description for {currentAnimal.IdToString()} (size, color, gender, weight, housebroken)");
                var physicalDescriptionInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(physicalDescriptionInput))
                {
                    currentAnimal.PhysicalDescription = physicalDescriptionInput.ToLower();
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Age and physical description fields are complete for all of our friends.");
    }
    public static void CompleteNicknamesAndPersonalityDescriptions(this IEnumerable<Animal> animals)
    {
        foreach (var currentAnimal in animals)
        {
            while (string.IsNullOrWhiteSpace(currentAnimal.Nickname))
            {
                Console.WriteLine($"Enter a nickname for {currentAnimal.IdToString()}");
                var nicknameInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nicknameInput))
                {
                    currentAnimal.Nickname = nicknameInput;
                }
            }

            while (string.IsNullOrWhiteSpace(currentAnimal.PersonalityDescription))
            {
                Console.WriteLine(
                    $"Enter a personality description for {currentAnimal.IdToString()} (likes or dislikes, tricks, energy level)");
                var personalityDescriptionInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(personalityDescriptionInput))
                {
                    currentAnimal.PersonalityDescription = personalityDescriptionInput.ToLower();
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Nicknames and personality descriptions fields are complete for all of our friends.");
    }
    public static void AddNewAnimal(this List<Animal> animals)
    {
        const int maxPets = 8;
        var newAnimal = new Animal();
        var anotherPet = "y";

        if (animals.Count < maxPets)
        {
            Console.WriteLine($"We currently have {animals.Count} pets that need homes. We can manage {maxPets - animals.Count} more.");
        }

        while (anotherPet == "y" && animals.Count < maxPets)
        {
            // get species (cat or dog) - string animalSpecies is a required field 
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter 'dog' or 'cat' to begin a new entry");
                var speciesInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(speciesInput) && (speciesInput.ToLower() == "dog" || speciesInput.ToLower() == "cat"))
                {
                    newAnimal.Species = speciesInput.ToLower();
                }
                else
                {
                    Console.WriteLine("Your entry is incorrect !");
                }
            } while (string.IsNullOrWhiteSpace(newAnimal.Species));

            // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
            newAnimal.Id = string.Concat(newAnimal.Species.AsSpan(0, 1), (animals.Count + 1).ToString());

            // get the pet's age. can be ? at initial entry.
            var petAgeValidated = false;
            do
            {
                Console.WriteLine("Enter the pet's age or enter ? if unknown");
                var ageInput = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(ageInput))
                {
                    continue;
                }
                
                petAgeValidated = true;
                var isValidInteger = int.TryParse(ageInput, out var petAge);
                if (ageInput != "?" && isValidInteger)
                {
                    petAgeValidated = true;
                    newAnimal.Age = petAge;
                } 
                else if (ageInput != "?" && !isValidInteger)
                {
                    petAgeValidated = false;
                    Console.WriteLine("Your entry is incorrect !");
                }
            } while (petAgeValidated == false);


            // get a description of the pet's physical appearance - animalPhysicalDescription can be blank.
            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
            var physicalDescriptionInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(physicalDescriptionInput))
            {
                newAnimal.PhysicalDescription = physicalDescriptionInput.ToLower();
            }


            // get a description of the pet's personality - animalPersonalityDescription can be blank.
            Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
            var personalityDescriptionInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(personalityDescriptionInput))
            {
                newAnimal.PersonalityDescription = personalityDescriptionInput.ToLower();
            }

            // get the pet's nickname. animalNickname can be blank.
            Console.WriteLine("Enter a nickname for the pet");
            var nicknameInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nicknameInput))
            {
                newAnimal.Nickname = nicknameInput.ToLower();
            }
   
            animals.Add(newAnimal);
            
            // check maxPet limit
            if (animals.Count < maxPets)
            {
                // another pet?
                Console.WriteLine("Do you want to enter info for another pet (y/n)");
                do
                {
                    var anotherPetInput = Console.ReadLine();
                    if (anotherPetInput?.ToLower() is "y" or "n")
                    {
                        anotherPet = anotherPetInput.ToLower();
                    }
                } while (anotherPet is not ("y" or "n"));
            }
            //NOTE: The value of anotherPet (either "y" or "n") is evaluated in the while statement expression - at the top of the while loop
        }

        if (animals.Count >= maxPets)
        {
            Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
        } 
    }
    public static void DisplayAllDogsWithAMultipleSearchCharacteristics(this IEnumerable<Animal> animals)
    {
        // #1 Display all dogs with a multiple search characteristics
        var dogCharacteristics = "";
        while (dogCharacteristics == "")
        {
            // #2 have user enter multiple comma separated characteristics to search for
            Console.WriteLine();
            Console.WriteLine("Enter dog characteristics to search for separated by commas: ");
            var characteristicsInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(characteristicsInput))
            {
                continue;
            }

            dogCharacteristics = characteristicsInput.ToLower();
            Console.WriteLine();
        }

        var dogSearches = dogCharacteristics.Split(",").ToList();

        // trim leading and trailing spaces from each search term
        dogSearches.ForEach(x => x.Trim());

        dogSearches.Sort();

        // #4 update to "rotating" animation with countdown
        string[] searchingIcons = { "\\", "|", "/", "--" };

        var matchesAnyDog = false;

        // loops through the ourAnimals array to search for matching animals
        foreach (var currentAnimal in animals)
        {
            if (currentAnimal.Species.ToLower() == "dog")
            {
                var dogDescription = currentAnimal.PhysicalDescription + "\n" + currentAnimal.PersonalityDescription;
                var matchesCurrentDog = false;

                foreach (var term in dogSearches)
                {
                    // #3a iterate submitted characteristic terms and search description for each term
                    if (dogDescription.Contains(term))
                    {
                        // #3b update message to reflect current search term match 
                        Console.WriteLine($"\rOur dog {currentAnimal.Nickname} matches your search for {term}");

                        matchesCurrentDog = true;
                        matchesAnyDog = true;
                    }
                }

                // #3d if the current dog is match, display the dog's info
                if (matchesCurrentDog)
                {
                    Console.WriteLine($"\r{currentAnimal.Nickname} ({currentAnimal.Id})\n{dogDescription}\n");
                }
            }
        }

        if (!matchesAnyDog)
        {
            Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristics);
        }
    }
}