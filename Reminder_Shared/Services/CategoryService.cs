
using Reminder_Shared.Dto;
using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services;

public class CategoryService(CategoryRepository categoryRepository)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;



    public CategoryEntity CreateCategory(CategoryDTO category)
    {
        var categoryEntity = _categoryRepository.Get(x => x.CategoryName == category.CategoryName);

        if (categoryEntity == null)
        {
            categoryEntity = _categoryRepository.Create(new CategoryEntity { CategoryName = category.CategoryName });
        }

        return categoryEntity;
    }

    public CategoryEntity GetCategoryName(CategoryDTO category)
    {
        var categoryEntity = _categoryRepository.Get(x => x.CategoryName == category.CategoryName);
        return categoryEntity;
    }

    public IEnumerable<CategoryEntity> GetAllCategory()
    {
        var allCategory = _categoryRepository.GetAll();
        return allCategory;
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        var updatedCategoryEntity = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return updatedCategoryEntity;
    }

    public bool DeleteCategory(int id)
    {
        _categoryRepository.Delete(x => x.Id == id);
        return true;
    }
}
