using Footballers.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace Footballers.Data.Models
{
    public class Footballer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public PositionType PositionType { get; set; }
        public BestSkillType BestSkillType { get; set; }
        public int CoachId { get; set; }
        public Coach Coach { get; set; }
        public ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
