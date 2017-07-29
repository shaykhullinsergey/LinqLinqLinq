using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLinqLinq
{
  class Table
  {
    public int Id { get; set; }
    public string Category { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
  }
  class Program
  {
    IEnumerable<Table> table = new List<Table>
    {
      new Table{Id = 123, Category = "Игры", LastName = "Иванов", Address = "Калининград"},
      new Table{Id = 128, Category = "Спорт", LastName = "Иванов", Address = "Калининград"},
      new Table{Id = 124, Category = "Игры", LastName = "Иванов", Address = "Москва"},
      new Table{Id = 125, Category = "Игры", LastName = "Сидоров", Address = "Екатеринбург"},
      new Table{Id = 126, Category = "Спорт", LastName = "Петров", Address = "Уфа"},
      new Table{Id = 127, Category = "Спорт", LastName = "Сидоров", Address = "Владивосток"},
    };

    static void Main(string[] args)
    {
      var result = table.GroupBy(x => x.Category)
        .Select(x => x.Distinct(y => y.LastName)
        .Count());

      foreach (var item in result)
      {
        Console.WriteLine(item);
      }
    }
  }

  static class Extensions
  {
    public static IEnumerable<T> Distinct<T, U>(this IEnumerable<T> source, Func<T, U> selector)
    {
      var set = new HashSet<U>();

      foreach (var item in source)
      {
        if (set.Add(selector(item)))
        {
          yield return item;
        }
      }
    }
  }
}
