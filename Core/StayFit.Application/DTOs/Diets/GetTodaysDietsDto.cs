using StayFit.Application.DTOs.Abstracts;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.Diets
{
    public record GetTodaysDietsDto : IDto
    {
        public int Id { get; init; }
        public MealType MealType { get; init; }
        public string FoodName { get; init; }
        public float Portion { get; init; }
        public string Unit { get; init; }
        public float Calories { get; init; }
        public float Carbohydrate { get; init; }
        public float Protein { get; init; }
        public float Fat { get; init; }
        public DietCreator Creator { get; init; }
    }
}
