using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());
            Stack<int> caloriesPerDay = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
           int mealsCount = meals.Count;
            int mealCalories = 0;
            int dailyCalories = 0;
            string currenMeal = "";
            while (meals.Count > 0 && caloriesPerDay.Count > 0)
            {

                if (dailyCalories == 0)
                {
                    dailyCalories = caloriesPerDay.Peek();
                }
                if (mealCalories == 0)
                {
                    currenMeal = meals.Peek();
                }
                else
                {
                    if (dailyCalories - mealCalories >= 0)
                    {
                        dailyCalories -= mealCalories;
                        mealCalories = 0;
                        meals.Dequeue();
                    }
                    else
                    {
                        mealCalories -= dailyCalories;
                        dailyCalories = 0;
                        caloriesPerDay.Pop();
                        if (caloriesPerDay.Count == 0)
                        {
                            meals.Dequeue();
                        }
                    }
                    continue;
                }
                if (currenMeal == "salad")
                {
                    mealCalories = 350;
                    if (dailyCalories - mealCalories >= 0)
                    {
                        dailyCalories -= mealCalories;
                        mealCalories = 0;
                        meals.Dequeue();
                    }
                    else
                    {
                        mealCalories -= dailyCalories;
                        dailyCalories = 0;
                        caloriesPerDay.Pop();
                        if (caloriesPerDay.Count == 0)
                        {
                            meals.Dequeue();
                        }
                    }
                }
                else if (currenMeal == "soup")
                {
                    mealCalories = 490;
                    if (dailyCalories - mealCalories >= 0)
                    {
                        dailyCalories -= mealCalories;
                        mealCalories = 0;
                        meals.Dequeue();
                    }
                    else
                    {
                        mealCalories -= dailyCalories;
                        dailyCalories = 0;
                        caloriesPerDay.Pop();
                        if (caloriesPerDay.Count == 0)
                        {
                            meals.Dequeue();
                        }
                    }
                }
                else if (currenMeal == "pasta")
                {
                    mealCalories = 680;
                    if (dailyCalories - mealCalories >= 0)
                    {
                        dailyCalories -= mealCalories;
                        mealCalories = 0;
                        meals.Dequeue();
                    }
                    else
                    {
                        mealCalories -= dailyCalories;
                        dailyCalories = 0;
                        caloriesPerDay.Pop();
                        if (caloriesPerDay.Count == 0)
                        {
                            meals.Dequeue();
                        }
                    }
                }
                else if (currenMeal == "steak")
                {
                    mealCalories = 790;
                    if (dailyCalories - mealCalories >= 0)
                    {
                        dailyCalories -= mealCalories;
                        mealCalories = 0;
                        meals.Dequeue();
                    }
                    else
                    {
                        mealCalories -= dailyCalories;
                        dailyCalories = 0;
                        caloriesPerDay.Pop();
                        if (caloriesPerDay.Count == 0)
                        {
                            meals.Dequeue();
                        }
                    }
                }
            }
            if (meals.Count == 0)
            {
                caloriesPerDay.Pop();
                caloriesPerDay.Push(dailyCalories);
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCount -meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
