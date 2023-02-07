using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class CitiesService:ICitiesService
{
    private List<string> _cities= new List<string>() {
            "London",
            "Tokyo",
            "New York",
            "Rome",
            "Paris",
            "Madrid"
        };

  

    public void AddCity(string city)
    {
        _cities.Add(city);
    }

    public List<string> GetCities()
    {
        return _cities;
    }
}
