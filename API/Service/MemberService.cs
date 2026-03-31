using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class MemberService : IMemberService
    {
        public async Task<IEnumerable<object>> GetMembersAsync()
        {
            var members = new[]
            {
                new { Id = 1, DisplayName = "John Doe" },
                new { Id = 2, DisplayName = "Jane Smith" },
                new { Id = 3, DisplayName = "Bob Johnson" }
            };
            
            return await Task.FromResult(members);
        }
    }
}
