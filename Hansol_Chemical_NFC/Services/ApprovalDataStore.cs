using Hansol_Chemical_NFC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hansol_Chemical_NFC.Services
{
    public class ApprovalDataStore : IDataStore<Approval>
    {
        private List<Approval> approvals;

        /// <summary>
        /// 화학물질/msds/비상대응 데이터 맞추어 넣기?
        /// </summary>
        public ApprovalDataStore()
        {
            GetRefresh();
        }

        public async Task<bool> AddItemAsync(Approval item)
        {
            approvals.Add(item);

            //Provider를 통한 데이터 입력

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Approval item)
        {
            var oldItem = approvals.Where((Approval arg) => arg.ID == item.ID).FirstOrDefault();
            approvals.Remove(oldItem);
            approvals.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = approvals.Where((Approval arg) => arg.ID == id).FirstOrDefault();
            approvals.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Approval> GetItemAsync(string id)
        {
            return await Task.FromResult(approvals.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Approval>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(approvals);
        }

        public List<Approval> GetSearchResults(string searchString)
        {
            ObservableCollection<Approval> results = new ObservableCollection<Approval>();
            if (searchString == "")
            {
                return approvals;
            }
            var test = approvals.Where(x => x.ApprovalName.ToLower().Contains(searchString) || x.Type.ToLower().Contains(searchString) || x.Summary.ToLower().Contains(searchString)).ToList();
            return test;
        }
        public void GetRefresh()
        {
            //Provider를 통한 데이터 조회
            approvals = new List<Approval>()
            {

                new Approval { ApprovalName = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "First item"},
                new Approval { ApprovalName = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "Second item" },
                new Approval { ApprovalName = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "Third item"},
                new Approval { ApprovalName = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "Fourth item"},
                new Approval { ApprovalName = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "Fifth item"},
                new Approval { ApprovalName = Guid.NewGuid().ToString(), ID = Guid.NewGuid().ToString(),Summary = Guid.NewGuid().ToString(), Type = "Sixth item"}
            };
        }
    }

}