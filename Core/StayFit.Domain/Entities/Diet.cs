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
        public string FoodName { get; set; }
        public float Portion { get; set; }
        public string Unit { get; set; }
        public float Calories { get; set; }
        public float Carbohydrate { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public DietCreator Creator { get; set; } = DietCreator.Trainer;
        public DietDay DietDay { get; set; }
    }
}
