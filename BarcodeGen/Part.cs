
namespace BarcodeGen
{
    class Part
    {
        public int id { get; private set; }

        public Part(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return this.id;
        }

        public string GetName()
        {
            return "Part Number " + this.id;
        }
    }
}
