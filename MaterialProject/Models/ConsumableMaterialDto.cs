namespace MaterialProject.Models
{
    public class ConsumableMaterialDto
    {
        public int Id { get; set; }
        public string PartNo { get; set; }
        public string AccessNo { get; set; }
        public string QTY { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
    }
}
