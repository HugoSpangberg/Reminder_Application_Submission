
using Reminder_Shared.Context;
using Reminder_Shared.Entities;

namespace Reminder_Shared.Repositories;

public class CategoryRepository : BaseRepository<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
