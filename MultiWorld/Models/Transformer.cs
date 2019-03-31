using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiWorld.Models
{

    public enum AllegianceType
    {
        Autobot = 1,
        Decepticon = 2
    }
    public class Transformer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime InsertTime { get; set; } = DateTime.UtcNow;

        public DateTime? LastUpdateTime { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(AllegianceType))]
        [JsonConverter(typeof(StringEnumConverter))]
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

        public int GetScore()
        {
            return this.Strength + this.Intelligence + this.Speed + this.Endurance + this.Rank + this.Courage + this.Firepower + this.Skill;
        }

    }
}
