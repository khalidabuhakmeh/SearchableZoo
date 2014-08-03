using System.Data.Entity;
using EFHooks;

namespace SearchableZoo.Models.Hooks
{
    public class KeeperInsertedHook : PostActionHook<Objects.Keeper>
    {
        public override void Hook(Objects.Keeper entity, HookEntityMetadata metadata)
        {
            using (var session = MvcApplication.DocumentStore.OpenSession())
            {
                var model = new Search.Keeper(entity);

                if (metadata.State == EntityState.Deleted)
                {
                    var item = session.Load<Search.Keeper>(model.Id);
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