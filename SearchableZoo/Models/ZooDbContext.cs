using System.Data.Entity;
using EFHooks;
using SearchableZoo.Models.Hooks;
using SearchableZoo.Models.Objects;

namespace SearchableZoo.Models
{
    public class ZooDbContext : HookedDbContext
    {
        public ZooDbContext()
        {
            RegisterHook(new AnimalInsertedHook());
            RegisterHook(new KeeperInsertedHook());
        }

        public IDbSet<Animal> Animals { get; set; }
        public IDbSet<Keeper> Keepers { get; set; } 
    }
}