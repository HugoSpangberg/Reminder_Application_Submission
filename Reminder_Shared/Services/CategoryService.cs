
using Reminder_Shared.Dto;
using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services;

public class CategoryService(CategoryRepository categoryRepository)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;



    public CategoryEntity CreateCategory(CategoryDTO category)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == category.CategoryName);

            if (categoryEntity == null)
            {
                categoryEntity = _categoryRepository.Create(new CategoryEntity { CategoryName = category.CategoryName });
            }

            return categoryEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating Category: {ex.Message}");
            return null!;

        }
    }

    public CategoryEntity GetCategoryName(CategoryDTO category)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == category.CategoryName);
            return categoryEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Getting Category Name: {ex.Message}");
            return null!;

        }

    }

    public IEnumerable<CategoryEntity> GetAllCategory()
    {
        try
        {
            var allCategory = _categoryRepository.GetAll();
            return allCategory;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Getting all Categories: {ex.Message}");
            return null!;
        }

    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        try
        {
            var updatedCategoryEntity = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
            return updatedCategoryEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Update Category: {ex.Message}");
            return null!;
        }
    }

    public bool DeleteCategory(int id)
    {
        try
        {
            _categoryRepository.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting Category: {ex.Message}");
            return false;
        }
    }
}
