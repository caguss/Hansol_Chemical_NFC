using Hansol_Chemical_NFC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hansol_Chemical_NFC.Services
{
    public class ChemicalDataStore : IDataStore<Chemical>
    {
        private List<Chemical> chemicals;

        /// <summary>
        /// 화학물질/msds/비상대응 데이터 맞추어 넣기?
        /// </summary>
        public ChemicalDataStore()
        {
            GetRefresh();
        }

        public async Task<bool> AddItemAsync(Chemical item)
        {
            chemicals.Add(item);

            //Provider를 통한 데이터 입력

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Chemical item)
        {
            var oldItem = chemicals.Where((Chemical arg) => arg.ID == item.ID).FirstOrDefault();
            chemicals.Remove(oldItem);
            chemicals.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = chemicals.Where((Chemical arg) => arg.ID == id).FirstOrDefault();
            chemicals.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Chemical> GetItemAsync(string id)
        {
            return await Task.FromResult(chemicals.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Chemical>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(chemicals);
        }

        public List<Chemical> GetSearchResults(string searchString)
        {
            ObservableCollection<Chemical> results = new ObservableCollection<Chemical>();
            if (searchString == "")
            {
                return chemicals;
            }
            var test = chemicals.Where(x => x.CASNo.ToLower().Contains(searchString) || x.ChemicalName.ToLower().Contains(searchString) || x.MaterialName.ToLower().Contains(searchString) || x.NFCTag.ToLower().Contains(searchString)).ToList();
            return test;
        }
        public void GetRefresh()
        {
            //Provider를 통한 데이터 조회
            chemicals = new List<Chemical>()
            {

                new Chemical { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "First item", ChemicalName="This is an item description." },
                new Chemical { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "Second item", ChemicalName="This is an item description." },
                new Chemical { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "Third item", ChemicalName="This is an item description." },
                new Chemical { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "Fourth item", ChemicalName="This is an item description." },
                new Chemical { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "Fifth item", ChemicalName="This is an item description." },
                new Chemical { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "Sixth item", ChemicalName="This is an item description." }
            };
        }
    }

}