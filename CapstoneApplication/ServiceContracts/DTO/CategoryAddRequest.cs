using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class CategoryAddRequest
    {
        public string CategoryName {  get; set; }

        public string CategoryDesc { get; set; }

        public Category ToCategory()
        {
            return new Category { CategoryName = CategoryName, CategoryDescription = CategoryDesc };
        }
    }
}
