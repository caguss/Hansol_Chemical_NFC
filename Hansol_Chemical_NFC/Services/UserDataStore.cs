using Hansol_Chemical_NFC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hansol_Chemical_NFC.Services
{
    public class UserDataStore : IDataStore<User>
    {
        private List<User> users;

        /// <summary>
        /// 화학물질/msds/비상대응 데이터 맞추어 넣기?
        /// </summary>
        public UserDataStore()
        {
            GetRefresh();
        }

        public async Task<bool> AddItemAsync(User item)
        {
            users.Add(item);

            //Provider를 통한 데이터 입력

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            var oldItem = users.Where((User arg) => arg.ID == item.ID).FirstOrDefault();
            users.Remove(oldItem);
            users.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = users.Where((User arg) => arg.ID == id).FirstOrDefault();
            users.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }

        public List<User> GetSearchResults(string searchString)
        {
            ObservableCollection<Patrol> results = new ObservableCollection<Patrol>();
            if (searchString == "")
            {
                return users;
            }
            var test = users.Where(x => x.Name.ToLower().Contains(searchString) || x.Position.ToLower().Contains(searchString) || x.PhoneNum.ToLower().Contains(searchString)).ToList();
            return test;
        }
        public void GetRefresh()
        {
            //Provider를 통한 데이터 조회
            users = new List<User>()
            {

                new User {Name = Guid.NewGuid().ToString(), Position = Guid.NewGuid().ToString(),PhoneNum = Guid.NewGuid().ToString()},
                new User {Name = Guid.NewGuid().ToString(), Position = Guid.NewGuid().ToString(),PhoneNum = Guid.NewGuid().ToString()},
                new User {Name = Guid.NewGuid().ToString(), Position = Guid.NewGuid().ToString(),PhoneNum = Guid.NewGuid().ToString()},
                new User {Name = Guid.NewGuid().ToString(), Position = Guid.NewGuid().ToString(),PhoneNum = Guid.NewGuid().ToString()},
                new User {Name = Guid.NewGuid().ToString(), Position = Guid.NewGuid().ToString(),PhoneNum = Guid.NewGuid().ToString()},
                new User {Name = Guid.NewGuid().ToString(), Position = Guid.NewGuid().ToString(),PhoneNum = Guid.NewGuid().ToString()}
            };
        }
    }

}