using System.Data.Entity;
using EFHooks;
using SearchableZoo.Models.Objects;
using SearchableZoo.Models.Search;

namespace SearchableZoo.Models.Hooks
{
    public class AnimalInsertedHook : PostActionHook<Objects.Animal>
    {
        public override void Hook(Objects.Animal entity, HookEntityMetadata metadata)
        {
            using (var session = MvcApplication.DocumentStore.OpenSession())
            {
                var model = new Search.Animal(entity);

                if (metadata.State == EntityState.Deleted)
                {
                    var item = session.Load<Search.Animal>(model.Id);
                    session.Delete(item);
                }
                else
                {
                    session.Store(model);
                }

                session.SaveChanges();
            }
        }

        public override EntityState HookStates
        {
            get { return EntityState.Added | EntityState.Modified | EntityState.Deleted; }
        }
    }
}