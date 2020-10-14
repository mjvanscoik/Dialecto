namespace Dialectico.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dialectico.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dialectico.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            context.Roots.AddOrUpdate(r => r.RootName,
                new Root
                {
                    RootName = "فعل",
                    NotesOnRoot = "fa‘ala a (fa‘l, fi‘l) to do (ھـ s.th.); to act; to perform, some activity; to have an influence or effect(في or ب on), affect(في or ب s.o., s.th.); to do (ب to s.o., s.th.; ھـ فيs.th.with) │ كريھا فعال فيه فعل) fi‘lan) to have an unpleasant effect on s.o.II to scan (ھـ a verse) VI to interact, interplay; (chem.) to enter into combination, form a compound; to combine(مع with) VII to be done; to be or become influenced or affected(ل by), be under the influence of s.o.or s.th. (ل ; (to b.agitated, excited, upset VIII to concoct, invent, fabricate (على كذبا) kidban kidban a lie against); to falsify, forge(ھـ s.th., e.g., a handwriting); to invent(ھـ s.th.)",
                    Id = 1,
                }
              );
            context.Words.AddOrUpdate(w => w.WordName
            , new Word
            {
                RootId = 1,
                WordId = 1,
                WordName = "فعل",
                Notes = "fi‘l activity, doing, work, action, performance; function; --(pl.افعال af‘āl, فعال fi‘āl) deed, act, action; effect, impact; --(pl.افعال af‘āl) verb(gram.); pl.افاعيل afā‘īl 2 great deeds, exploits, feats; machinations │ فعال fi‘lan or بالفعل indeed, in effect, actually, really, practically; بالفعل out of, because of, due to ",
                RootName = "فعل",
            }
            );
            context.Words.AddOrUpdate(w => w.WordName
           , new Word
           {
               RootId = 1,
               WordId = 2,
               WordName = "فعلي",
               Notes = "fi‘lī actual, factual, real; effective, efficacious, efficient; practical; de facto; verbal(gram.)",
               RootName = "فعل"
           });
            context.Words.AddOrUpdate(w => w.WordName
           , new Word
           {
               RootId = 1,
               WordId = 3,
               WordName = "فعلة",
               Notes = "fa‘‘ālīya effectiveness, efficacy, efficiency; activity",
               RootName = "فعل"
           });
        }
    }
}
