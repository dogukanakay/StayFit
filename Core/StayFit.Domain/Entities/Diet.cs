using StayFit.Domain.Entities.Common;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Domain.Entities
{
    public class Diet : BaseEntity<int>
    {
        public int DietDayId { get; set; }
        public MealType MealType { get; set; }
        public TimeSpan TargetTime { get; set; }
        public string FoodName { get; set; }
        public float Portion { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public int Carbs { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public DietDay DietDay { get; set; }
    }
}
