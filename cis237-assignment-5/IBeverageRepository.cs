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

        void Delete();

        string ToString();

        string Find(string name);
    }
}
