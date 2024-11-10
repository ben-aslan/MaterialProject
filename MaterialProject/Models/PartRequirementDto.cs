namespace MaterialProject.Models
{
    public class PartRequirementDto
    {
        public int Id { get; set; }
        public string PartNo { get; set; }
        public string QTY { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
    }
}
