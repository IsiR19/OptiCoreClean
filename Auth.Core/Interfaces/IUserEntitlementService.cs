using Auth.Core.Interfaces.Models;

namespace Auth.Core.Interfaces
{
    public interface IUserEntitlementService
    {
        Task<IEnumerable<IUserEntitlement>> GetAllByUuidAsync(string uuid);
        Task AddAsync(string uuid, string entitlementCode);
        Task ToggleAsync(string uuid, string entitlementCode, bool disabled);
        Task ToggleAsync(int id, bool disabled);
        Task RemoveAsync(string uuid, string entitlementCode);
    }
}
