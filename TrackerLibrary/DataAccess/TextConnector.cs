using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {

        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";

        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int currentId = 1;

            if(people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            people.Add(model);

            people.SaveToPeopleFile(PeopleFile);

            return model; 
        }

        // TODO - Wire up the CreatePrize for text files.
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load the text file and convert the text to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels(); ; // Get the full path to the file


            // Find the max ID
            int currentId = 1;

            if(prizes.Count > 0) // If there are already prizes in the list
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1; // Get the highest ID and add 1 to it
            }

            model.Id = currentId; // Set the new ID to the model

            // Add the new record with the new ID (max +1)
            prizes.Add(model); // Add the new model to the list

            // Convert the prizes to a list<string>
            // Save the list<string> to the text file

            prizes.SaveToPrizeFile(PrizesFile); // Save the list to the file

            return model; // Return the model with the new ID
        }
    }
}
