using Apps.Models;
using Apps.Data;

namespace Apps.Services
{
    internal class ItemsService
    {
        // Read all data
        public IEnumerable<ItemsModel> GetAllItems()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                return context.Items.ToList();
            }
        }

        // Update data service
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

        // Adding data service
        public void AddedItem(ItemsModel model)
        {
            using (var context = new AppDbContext())
            {
                context.Items.Add(model);
                context.SaveChanges();
            }
        }

        // Delete data service
        public void DeleteItem(ItemsModel model)
        {
            using (var context = new AppDbContext())
            {
                context.Remove(model);
                context.SaveChanges();
            }
        }
    }
}
