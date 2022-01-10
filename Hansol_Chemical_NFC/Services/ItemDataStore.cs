using Hansol_Chemical_NFC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hansol_Chemical_NFC.Services
{
    public class ItemDataStore : IDataStore<Item>
    {
        private List<Item> items;

        /// <summary>
        /// 화학물질/msds/비상대응 데이터 맞추어 넣기?
        /// </summary>
        public ItemDataStore()
        {
            GetRefresh();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            //Provider를 통한 데이터 입력

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.ID == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public List<Item> GetSearchResults(string searchString)
        {
            ObservableCollection<Item> results = new ObservableCollection<Item>();
            if (searchString == "")
            {
                return items;
            }
            var test = items.Where(x => x.CASNo.ToLower().Contains(searchString) || x.ChemicalName.ToLower().Contains(searchString) || x.MaterialName.ToLower().Contains(searchString) || x.NFCTag.ToLower().Contains(searchString)).ToList();
            return test;
        }
        public void GetRefresh()
        {
            //Provider를 통한 데이터 조회
            items = new List<Item>()
            {

                new Item { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "First item", ChemicalName="This is an item description." },
                new Item { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "Second item", ChemicalName="This is an item description." },
                new Item { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "Third item", ChemicalName="This is an item description." },
                new Item { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "Fourth item", ChemicalName="This is an item description." },
                new Item { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "Fifth item", ChemicalName="This is an item description." },
                new Item { ID = Guid.NewGuid().ToString(),CASNo = Guid.NewGuid().ToString(), MaterialName = "Sixth item", ChemicalName="This is an item description." }
            };
        }
    }

}