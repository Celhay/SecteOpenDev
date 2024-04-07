using RefactoBase;
using RefactoBase.Core;
using RefactoBase.Models;
using RefactoBase.Utils;

// ourAnimals array will store the following: 
var animalSpecies = "";
var animalId = "";
int? animalAge = null;
var animalPhysicalDescription = "";
var animalPersonalityDescription = "";
var animalNickname = "";

// variables that support data entry
var maxPets = 8;
string? readResult;
int? menuSelection = null;
var petCount = 0;
var anotherPet = "y";
var validEntry = false;
var petAge = 0;

// array used to store runtime data
var ourAnimals = new List<Animal>();

// sample data ourAnimals array entries
var sampleDataProvider = new SampleDataProvider();
var sampleData = sampleDataProvider.GetSampleData();
ourAnimals.AddRange(sampleData);

// top-level menu options
do
{
    MenuManager.DisplayMenu();
    
    menuSelection = MenuManager.GetUserMenuSelection();

    switch (menuSelection)
    {
        case 0:
            Console.WriteLine("Good bye !");
            break;
        case > 0 and <= 8:
            MenuManager.DoMenuAction((Actions)menuSelection, ourAnimals);
            break;
        default:
            Console.WriteLine("Your entry is incorrect ! ");
            break;
    }

    WaitUserToContinue();
    
    // switch-case to process the selected menu option
    switch (menuSelection)
    {
        case 2:
            // Add a new animal friend to the ourAnimals array
            //
            // The ourAnimals array contains
            //    1. the species (cat or dog). a required field
            //    2. the ID number - for example C17
            //    3. the pet's age. can be blank at initial entry.
            //    4. the pet's nickname. can be blank.
            //    5. a description of the pet's physical appearance. can be blank.
            //    6. a description of the pet's personality. can be blank.

            anotherPet = "y";
            petCount = 0;
            for (var i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                // get species (cat or dog) - string animalSpecies is a required field 
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            //Console.WriteLine($"You entered: {animalSpecies}.");
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                animalId = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // get the pet's age. can be ? at initial entry.
                do
                {
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }                        
                    }
                } while (validEntry == false);


                // get a description of the pet's physical appearance - animalPhysicalDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }
                } while (validEntry == false);


                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }
                } while (validEntry == false);


                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }
                } while (validEntry == false);

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalId;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                // increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                petCount = petCount + 1;

                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");
                }
                //NOTE: The value of anotherPet (either "y" or "n") is evaluated in the while statement expression - at the top of the while loop
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
            }
            WaitUserToContinue();
            break;
        case 8:
            // #1 Display all dogs with a multiple search characteristics

            var dogCharacteristics = "";

            while (dogCharacteristics == "")
            {
                // #2 have user enter multiple comma separated characteristics to search for
                Console.WriteLine($"\nEnter dog characteristics to search for separated by commas");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    dogCharacteristics = readResult.ToLower();
                    Console.WriteLine();
                }
            }

            string[] dogSearches = dogCharacteristics.Split(",");
            // trim leading and trailing spaces from each search term
            for (var i = 0; i < dogSearches.Length; i++)
            {
                dogSearches[i] = dogSearches[i].Trim();
            }

            Array.Sort(dogSearches);
            // #4 update to "rotating" animation with countdown
            string[] searchingIcons = {"\\", "|", "/", "--"};

            var matchesAnyDog = false;
            var dogDescription = "";

            // loops through the ourAnimals array to search for matching animals
            for (var i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("dog"))
                {

                    // Search combined descriptions and report results
                    dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                    var matchesCurrentDog = false;

                    foreach (var term in dogSearches)
                    {
                        // only search if there is a term to search for
                        if (term.Trim() != "")
                        {
                            for (var j = 2; j > -1 ; j--)
                            {
                                // #5 update "searching" message to show countdown
                                foreach (var icon in searchingIcons)
                                {
                                    Console.Write($"\rsearching our dog {ourAnimals[i, 3]} for {term.Trim()} {icon} {j.ToString()}");
                                    Thread.Sleep(100);
                                }
                                
                                Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                            }

                            // #3a iterate submitted characteristic terms and search description for each term
                            if (dogDescription.Contains(" " + term.Trim() + " "))
                            {
                                // #3b update message to reflect current search term match 

                                Console.WriteLine($"\rOur dog {ourAnimals[i, 3]} matches your search for {term.Trim()}");

                                matchesCurrentDog = true;
                                matchesAnyDog = true;
                            }
                        }
                    }
                    
                    // #3d if the current dog is match, display the dog's info
                    if (matchesCurrentDog)
                    {
                        Console.WriteLine($"\r{ourAnimals[i, 3]} ({ourAnimals[i, 0]})\n{dogDescription}\n");
                    }
                }
            }

            if (!matchesAnyDog)
            {
                Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristics);
            }

            WaitUserToContinue();
            break;
    }
} 
while (menuSelection != 0);

static void WaitUserToContinue()
{
    Console.WriteLine();
    Console.WriteLine("Press the Enter key to continue");
    Console.ReadLine();
}
