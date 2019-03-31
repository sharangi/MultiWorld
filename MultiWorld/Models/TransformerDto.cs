using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MultiWorld.Models
{
    public class TransformerDto
    {
        /// <summary>
        /// This is a system generated field, user provided values will not be persisted.
        /// </summary>
        public string Id { get; set; }

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

        /// <summary>
        /// This is a system generated field, user provided values will not be persisted.
        /// </summary>
        public int? OverallScore { get; set; }

        public static TransformerDto ConvertEntityToDto(Transformer transformer)
        {
            if (transformer == null)
                return null;
            var transformerDto = new TransformerDto()
            {
                Id = transformer.Id.ToString(),
                Name = transformer.Name,
                Allegiance = transformer.Allegiance,
                Strength = transformer.Strength,
                Intelligence = transformer.Intelligence,
                Speed = transformer.Speed,
                Endurance = transformer.Endurance,
                Rank = transformer.Rank,
                Courage = transformer.Courage,
                Firepower = transformer.Firepower,
                Skill = transformer.Skill,
                OverallScore = transformer.GetScore()
            };
            return transformerDto;
        }
    }
}
