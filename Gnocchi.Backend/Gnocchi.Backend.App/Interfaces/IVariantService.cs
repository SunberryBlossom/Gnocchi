using Gnocchi.Backend.App.DTOs;

namespace Gnocchi.Backend.API.Interfaces;

public interface IVariantService
{
    #region Create signatures
    public Task<VariantDTO> AddVariantAsync(CreateVariantDTO createVariantDTO, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<VariantDTO> GetVariantByIdAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<VariantDTO>> GetAllVariantsAsync(CancellationToken ct = default);
    #endregion
    #region Update signatures
    #endregion
    #region Delete signatures
    public Task DeleteVariantAsync(DeleteVariantDTO deleteVariantDTO, CancellationToken ct = default);
    #endregion
}