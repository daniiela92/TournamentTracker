using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {

        PrizeModel CreatePrize(PrizeModel model);

        PersonModel CreatePerson(PersonModel model);

        List<PersonModel> GetPerson_All(); // method to get all persons from the data source

    }
}
