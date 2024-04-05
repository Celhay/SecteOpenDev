namespace RefactoBase;

public class MenuManager
{ 
    public void Display()
    {
        do
        {
            Console.Clear();
            DisplayMenu();
            
            GetUserMenuSelection();

            // switch-case to process the selected menu option
            switch (menuSelection)
            {
                case "1":
                    // list all pet info
                    foreach (var currentAnimal in ourAnimals)
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

                    Console.WriteLine("\r\nPress the Enter key to continue");
                    Console.ReadLine();

                    break;
                case "2":
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
                        Console.WriteLine(
                            $"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
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
                            Console.WriteLine(
                                "Enter a physical description of the pet (size, color, gender, weight, housebroken)");
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
                            Console.WriteLine(
                                "Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
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
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                    }

                    break;

                case "3":
                    // Ensure animal ages and physical descriptions are complete
                    //
                    //    ourAnimals[i, 2] = "Age: " + animalAge;
                    //    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;

                    for (var i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 2] == "Age: ?" && ourAnimals[i, 0] != "ID #: ")
                        {
                            do
                            {
                                Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalAge = readResult;
                                    validEntry = int.TryParse(animalAge, out petAge);
                                }
                            } while (validEntry == false);

                            ourAnimals[i, 2] = "Age: " + animalAge.ToString();
                        }

                        if (ourAnimals[i, 4] == "Physical description: " && ourAnimals[i, 0] != "ID #: ")
                        {
                            do
                            {
                                Console.WriteLine(
                                    $"Enter a physical description for {ourAnimals[i, 0]} (size, color, gender, weight, housebroken)");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalPhysicalDescription = readResult.ToLower();
                                    validEntry = animalPhysicalDescription != "";
                                }
                            } while (validEntry == false);

                            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                        }
                    }

                    Console.WriteLine(
                        "\n\rAge and physical description fields are complete for all of our friends. \n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();

                    break;

                case "4":
                    // Ensure animal nickname and personality descriptions are complete
                    //
                    //    ourAnimals[i, 3] = "Nickname: " + animalNickname;
                    //    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

                    for (var i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 3] == "Nickname: " && ourAnimals[i, 0] != "ID #: ")
                        {
                            do
                            {
                                Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalNickname = readResult;
                                    if (animalNickname == "")
                                    {
                                        validEntry = false;
                                    }
                                    else
                                    {
                                        validEntry = true;
                                    }
                                }
                            } while (validEntry == false);

                            ourAnimals[i, 3] = "Nickname: " + animalNickname;
                        }

                        if (ourAnimals[i, 5] == "Personality: " && ourAnimals[i, 0] != "ID #: ")
                        {
                            do
                            {
                                //"Enter a description of the pet's personality (likes or dislikes, tricks, energy level"
                                Console.WriteLine(
                                    $"Enter a personality description for {ourAnimals[i, 0]} (likes or dislikes, tricks, energy level)");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalPersonalityDescription = readResult.ToLower();
                                    if (animalPersonalityDescription == "")
                                    {
                                        validEntry = false;
                                    }
                                    else
                                    {
                                        validEntry = true;
                                    }
                                }
                            } while (validEntry == false);

                            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                        }
                    }

                    Console.WriteLine(
                        "\n\rAge and physical description fields are complete for all of our friends. \n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();

                    break;

                case "5":
                    // Edit an animal’s age");
                    Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "6":
                    // Edit an animal’s personality description");
                    Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "7":
                    // Display all cats with a specified characteristic
                    Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "8":
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
                    string[] searchingIcons = { "\\", "|", "/", "--" };

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
                                    for (var j = 2; j > -1; j--)
                                    {
                                        // #5 update "searching" message to show countdown
                                        foreach (var icon in searchingIcons)
                                        {
                                            Console.Write(
                                                $"\rsearching our dog {ourAnimals[i, 3]} for {term.Trim()} {icon} {j.ToString()}");
                                            Thread.Sleep(100);
                                        }

                                        Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                                    }

                                    // #3a iterate submitted characteristic terms and search description for each term
                                    if (dogDescription.Contains(" " + term.Trim() + " "))
                                    {
                                        // #3b update message to reflect current search term match 

                                        Console.WriteLine(
                                            $"\rOur dog {ourAnimals[i, 3]} matches your search for {term.Trim()}");

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

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();

                    break;

                default:
                    break;
            }
        } while (menuSelection != "exit");
    }

    private void DisplayMenu()
    {
        Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
        Console.WriteLine(" 1. List all of our current pet information");
        Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
        Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
        Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
        Console.WriteLine(" 5. Edit an animal’s age");
        Console.WriteLine(" 6. Edit an animal’s personality description");
        Console.WriteLine(" 7. Display all cats with a specified characteristic");
        Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    }
    
    private static int? GetUserMenuSelection()
    {
        Console.WriteLine();
        Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

        var userInput = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(userInput))
        {
            menuSelection = readResult.ToLower();
        }
    }
}