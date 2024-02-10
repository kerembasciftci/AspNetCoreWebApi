using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        public CategoryDto Category;
    }
}
