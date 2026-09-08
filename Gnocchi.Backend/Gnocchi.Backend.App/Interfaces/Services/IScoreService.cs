using Gnocchi.Backend.App.DTOs;

namespace Gnocchi.Backend.App.Interfaces;

public interface IScoreService
{
    #region Create signatures
    public Task<ScoreDTO> AddScoreAsync(CreateScoreDTO createScoreDTO, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<ScoreDTO> GetScoreByIdAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<ScoreDTO>> GetAllScoresAsync(CancellationToken ct = default);
    #endregion
    #region Update signatures
    #endregion
    #region Delete signatures
    public Task DeleteScoreAsync(DeleteScoreDTO deleteScoreDTO, CancellationToken ct = default);
    #endregion
}