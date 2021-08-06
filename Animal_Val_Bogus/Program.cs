using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using Bogus;
using System.Linq;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Animal_Val_Bogus
{
    class Program
    {
        static EFContext context = new EFContext();
        static void Main(string[] args)
        {
            //Перевірка швидкості додавання
            /* Stopwatch stopWatch = new Stopwatch();
             stopWatch.Start();

             //AnimalEdit();   //Додавання руцями
             AnimalBogus(); //Додавання за допомогою Bogus

             stopWatch.Stop();
             TimeSpan ts = stopWatch.Elapsed;
             string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
             ts.Hours, ts.Minutes, ts.Seconds,
             ts.Milliseconds / 10);
             Console.WriteLine("RunTime " + elapsedTime);
            */

            var thread = new Thread(() =>                  //
            {                                              //
                AnimalBogus();                             //
                for (int i = 0; i <= 100; i++)             //
                {                                          //
                    Console.SetCursorPosition(0, 2);       //
                    Console.WriteLine("Виконання {0}%", i);// показ відсотків,
                    Thread.Sleep(10);                      //
                }                                          //
            });                                            //
            thread.Start();                                //
            thread.Join();

            static void AnimalBogus()
            {   
                Console.WriteLine("Введіть кількість значень для додавання:");
                int k = Convert.ToInt32(Console.ReadLine());

                var kind = new[] { "собака", "кіт", "єнот", "шимпанзе", "морська свинка", "папуга", "хомяк", 
                "кінь", "лігр","корова", "ворона", "рибка", "черепашка", "щур", "ведмідь","змія", "павук"};
               
                var facker = new Faker<Animal>("uk")
                        .RuleFor(x => x.Kind, f => f.PickRandom(kind))
                        .RuleFor(x => x.Name, f => f.Name.FirstName());

                    for (int i = 0; i < k; i++)
                    {
                        var p = facker.Generate();
                        context.Animals.Add(p);
                    }
                    context.SaveChanges();
            }

            static void AnimalEdit()
            {
                var animal = new Animal();
                Console.WriteLine("Вкажіть вид тварини: ");
                animal.Kind = Console.ReadLine();
                Console.WriteLine("Вкажіть кличку тварини: ");
                animal.Name = Console.ReadLine();

                AnimalValidator validator = new AnimalValidator();

                var results = validator.Validate(animal);
                if (results.IsValid)
                {
                    EFContext context = new EFContext();
                    context.Animals.Add(animal);
                    context.SaveChanges();
                }
                else
                {
                    foreach (var failure in results.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
            }
        }
    }
}