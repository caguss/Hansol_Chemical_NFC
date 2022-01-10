using Hansol_Chemical_NFC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hansol_Chemical_NFC.Services
{
    public class PatrolDataStore : IDataStore<Patrol>
    {
        private List<Patrol> patrols;

        /// <summary>
        /// 화학물질/msds/비상대응 데이터 맞추어 넣기?
        /// </summary>
        public PatrolDataStore()
        {
            GetRefresh();
        }

        public async Task<bool> AddItemAsync(Patrol item)
        {
            patrols.Add(item);

            //Provider를 통한 데이터 입력

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Patrol item)
        {
            var oldItem = patrols.Where((Patrol arg) => arg.ID == item.ID).FirstOrDefault();
            patrols.Remove(oldItem);
            patrols.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = patrols.Where((Patrol arg) => arg.ID == id).FirstOrDefault();
            patrols.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Patrol> GetItemAsync(string id)
        {
            return await Task.FromResult(patrols.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Patrol>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(patrols);
        }

        public List<Patrol> GetSearchResults(string searchString)
        {
            ObservableCollection<Patrol> results = new ObservableCollection<Patrol>();
            if (searchString == "")
            {
                return patrols;
            }
            var test = patrols.Where(x => x.Location.ToLower().Contains(searchString) || x.Type.ToLower().Contains(searchString) || x.Summary.ToLower().Contains(searchString)).ToList();
            return test;
        }
        public void GetRefresh()
        {
            //Provider를 통한 데이터 조회
            patrols = new List<Patrol>()
            {

                new Patrol { Location = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "First item"},
                new Patrol { Location = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "Second item" },
                new Patrol { Location = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "Third item"},
                new Patrol { Location = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "Fourth item"},
                new Patrol { Location = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "Fifth item"},
                new Patrol { Location = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "Sixth item"}
            };
        }
    }

}