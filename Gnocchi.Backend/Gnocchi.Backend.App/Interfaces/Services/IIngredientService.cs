using Gnocchi.Backend.App.DTOs;

namespace Gnocchi.Backend.API.Interfaces;

public interface IIngredientService
{
    #region Create signatures
    public Task<IngredientDTO> AddIngredientAsync(CreateIngredientDTO createIngredientDTO, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IngredientDTO> GetIngredientByIdAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<IngredientDTO>> GetAllIngredientsAsync(CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<IngredientDTO> UpdateIngredientAsync(UpdateIngredientDTO updateIngredientDTO, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteIngredientAsync(DeleteIngredientDTO deleteIngredientDTO, CancellationToken ct = default);
    #endregion
}