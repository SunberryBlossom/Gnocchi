using Gnocchi.Backend.App.DTOs;

namespace Gnocchi.Backend.API.Interfaces;

public interface IResultService
{
    #region Create signatures
    public Task<ResultDTO> AddResultAsync(CreateResultDTO createResultDTO, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<ResultDTO> GetResultByIdAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<ResultDTO>> GetAllResultsAsync(CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<ResultDTO> UpdateResultAsync(UpdateResultDTO updateResultDTO, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteResultAsync(DeleteResultDTO deleteResultDTO, CancellationToken ct = default);
    #endregion
}