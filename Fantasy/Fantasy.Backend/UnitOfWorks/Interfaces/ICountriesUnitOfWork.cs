using Fantasy.Shared.Entities;
using Fantasy.Shared.Responses;

namespace Fantasy.Backend.UnitOfWorks.Interfaces;

public interface ICountriesUnitOfWork
{
    Task<ActionResponse<Country>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();

    Task<IEnumerable<Country>> GetComboAsync();
}