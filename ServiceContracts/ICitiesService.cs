﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ICitiesService
    {
        List<string> GetCities();
        void AddCity(string city);
    }
}
