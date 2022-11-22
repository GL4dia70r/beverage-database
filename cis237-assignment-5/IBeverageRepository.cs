// David Allen
// 11/15/2022 - 11/21/2022
// Assignment 5: Databases
using cis237_assignment_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_5
{
    internal interface IBeverageRepository
    {
        void AddNew(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
            );

        void Update(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
            );

        void Delete(string name);

        string DrinkToString(Beverage beverage);

        Beverage Find(string name);
    }
}
