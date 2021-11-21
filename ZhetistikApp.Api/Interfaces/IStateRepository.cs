using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IStateRepository
    {
        public Task<State> GetStateAsync(int stateId);
        public Task<State> GetStateAsync(string stateName);
        public Task<int> CreateStateAsync(State state);
        public Task<bool> DeleteStateAsync(int id);
        public Task<int> UpdateStateAsync(int id, State state);
    }
}
