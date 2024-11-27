using Apps.Models;
using Apps.Data;
using System.Linq;

namespace Apps.Services
{
    internal class ItemsService
    {
        public IEnumerable<ItemsModel> GetAllItems()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                return context.Items.ToList();
            }
        }

        public void UpdateItem(ItemsModel model)
        {
            using (var context = new AppDbContext())
            {
                var itemToUpdate = context.Items.FirstOrDefault(item => item.ID == model.ID);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Name = model.Name;
                    itemToUpdate.Description = model.Description;
                    itemToUpdate.IsDeleted = model.IsDeleted;
                    context.SaveChanges();
                }
            }
        }

        public void AddedItem(ItemsModel model)
        {
            using (var context = new AppDbContext())
            {
                context.Items.Add(model);
                context.SaveChanges();
            }
        }
    }
}
