namespace MiniatureOrderManagementTool.Models.Dtos
{
    public class Part
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public Part()
        {
        }

        public Part(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }
    }
}
