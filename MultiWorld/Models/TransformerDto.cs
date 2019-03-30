using System.ComponentModel.DataAnnotations;

namespace MultiWorld.Models
{
    public class TransformerDto
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(AllegianceType))]
        public AllegianceType Allegiance { get; set; }

        [Range(1, 10)]
        public int Strength { get; set; }

        [Range(1, 10)]
        public int Intelligence { get; set; }

        [Range(1, 10)]
        public int Speed { get; set; }

        [Range(1, 10)]
        public int Endurance { get; set; }

        [Range(1, 10)]
        public int Rank { get; set; }

        [Range(1, 10)]
        public int Courage { get; set; }

        [Range(1, 10)]
        public int Firepower { get; set; }

        [Range(1, 10)]
        public int Skill { get; set; }

        public int? OverallScore { get; set; }
    }
}
