using MongoDB.Driver;
using System.Collections.Generic;

namespace BarcodeGen
{
    interface IPartDataAdapter
    {
        List<Part> GetPartsData();
    }
}
