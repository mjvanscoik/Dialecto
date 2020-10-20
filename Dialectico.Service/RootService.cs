using Dialectico.Data;
using Dialectico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Service
{
    public class RootService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<RootListItem> GetRoots()
        {
            var rootEntities = _db.Roots.ToList();
            var rootList = rootEntities.Select(r => new RootListItem
            {
                Id = r.Id,
                RootName = r.RootName,
                NotesOnRoot = r.NotesOnRoot
            });
            return rootList;
        }

        public RootListItem GetRootById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Roots
                        .Single(e => e.Id == id);

                var list = new List<WordListItem>();

                foreach (var item in entity.WordsList)
                {
                    var conversion = new WordListItem
                    {
                        RootId = item.RootId,
                        RootName = item.RootName,
                        WordId = item.WordId,
                        Notes = item.Notes,
                        WordName = item.WordName,
                    };
                    list.Add(conversion);
                }
                
                return
                    new RootListItem
                    {
                        RootName = entity.RootName,
                        NotesOnRoot = entity.NotesOnRoot,
                        WordsList = list,
                        Measures = entity.Measures,
                    };
            }
        }
        public bool CreateRoot(RootCreate model)
        {
            var entity = new Root()
            {
                RootName = model.RootName,
                NotesOnRoot = model.NotesOnRoot,
            };

            using (var ctx = new ApplicationDbContext())
            {
                if (_db.Roots.Where(e => e.RootName == model.RootName).Any())
                {
                    return false;
                }
                else
                {
                    ctx.Roots.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }
        public bool DeleteRoot(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Roots.Single(e => e.Id == id);

                ctx.Roots.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public bool UpdateRoot(RootListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Roots
                        .Single(e => e.Id == model.Id);

                entity.RootName = model.RootName;
                entity.NotesOnRoot = model.NotesOnRoot;

                return ctx.SaveChanges() == 1;
            }
        }
        public List<string> GetMeasures(int id)
        {
            List<string> measuresList = new List<string>();
            var root = GetRootById(id);
            if(root.RootName.Length == 3)
            {
                List<char> letters = root.RootName.ToList();

                measuresList.Add(root.RootName); //measure one

                List<char> measureTwo = new List<char>(letters); //measure two
                measureTwo.Insert(2, 'ي');
                measureTwo.Insert(0, 'ت');
                string measureII = String.Concat(measureTwo);
                measuresList.Add(measureII);

                 List<char> measureThree = new List<char>(letters); //measure three
                measureThree.Insert(3, 'ة');
                measureThree.Insert(1, 'ا');
                measureThree.Insert(0, 'م');
                string measureIII = String.Concat(measureThree);
                measuresList.Add(measureIII);

                List<char> measureFour = new List<char>(letters); //measure four
                if (letters.ElementAt(0) == 'ا')
                {
                    letters.RemoveAt(0);
                    letters.Insert(0, 'آ');
                    measureFour.Insert(1, 'ا');
                    string measureIV = String.Concat(measureFour);
                    measuresList.Add(measureIV);
                }
                else if(letters.ElementAt(2) == 'ى')
                {
                    letters.RemoveAt(2);
                    measureFour.Add('ا');
                    measureFour.Add('ء');
                    measureFour.Insert(1, 'ا');
                    measureFour.Insert(0, 'إ');
                    string measureIV = String.Concat(measureFour);
                    measuresList.Add(measureIV);
                }
                //else if()
                else
                {
                    measureFour.Insert(2, 'ا');
                    measureFour.Insert(0, 'إ');
                    string measureIV = String.Concat(measureFour);
                    measuresList.Add(measureIV);
                }

                List<char> measureFive = new List<char>(letters); //measure five
                measureFive.Insert(0, 'ت');
                string measureV = String.Concat(measureFive);
                measuresList.Add(measureV);

                List<char> measureSix = new List<char>(letters); //measure six
                measureSix.Insert(1, 'ا');
                measureSix.Insert(0, 'ت');
                string measureVI = String.Concat(measureSix);
                measuresList.Add(measureVI);

                List<char> measureSeven = new List<char>(letters); //measure seven
                measureSeven.Insert(2, 'ا');
                measureSeven.Insert(0, 'ن');
                measureSeven.Insert(0, 'إ');
                string measureVII = String.Concat(measureSeven);
                measuresList.Add(measureVII);

                List<char> measureEight = new List<char>(letters); //measure eight
                measureEight.Insert(2, 'ا');
                measureEight.Insert(1, 'ت');
                measureEight.Insert(0, 'إ');
                string measureVIII = String.Concat(measureEight);
                measuresList.Add(measureVIII);

                List<char> measureTen = new List<char>(letters); //measure ten
                measureTen.Insert(2, 'ا');
                measureTen.Insert(0, 'ت');
                measureTen.Insert(0, 'س');
                measureTen.Insert(0, 'إ');
                string measureX = String.Concat(measureTen);
                measuresList.Add(measureX);





            }
                return measuresList;
        }
    }
}
