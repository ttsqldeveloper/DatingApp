using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<object>> GetMembersAsync();
    }
}