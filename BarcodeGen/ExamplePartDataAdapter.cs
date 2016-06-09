using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeGen
{
    class ExamplePartDataAdapter : IPartDataAdapter
    {
        public List<Part> GetPartsData()
        {
            List<Part> parts = new List<Part>();

            for (int n = 0; n < 30; n++)
            {
                parts.Add(new Part(n));
            }

            return parts;
        }
    }
}
