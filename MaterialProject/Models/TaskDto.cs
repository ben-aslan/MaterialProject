using System.Collections.Generic;

namespace MaterialProject.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string TaskNo { get; set; }
        public string AdNo { get; set; }
        public string Remarks { get; set; }
        public string NDTRemark { get; set; }
        public List<AccessPanelDto> AccessPanels { get; set; }
        public List<ConsumableMaterialDto> ConsumableMaterials { get; set; }
        public List<PartRequirementDto> PartRequirements { get; set; }
        public List<ToolAndTesterDto> ToolAndTesters { get; set; }
        public List<NDTDto> NDTs { get; set; }
    }
}
