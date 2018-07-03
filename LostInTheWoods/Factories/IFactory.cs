using LostInTheWoods.Models;
using System.Collections.Generic;
namespace LostInTheWoods.Factory{
    public interface IFactory<T> where T : BaseEntity{}
}