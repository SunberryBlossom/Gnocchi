using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Services;

public class VariantService : IVariantService
{
    private readonly IVariantManager _variantManager;
    public VariantService(IVariantManager variantManager)
    {
        _variantManager = variantManager;
    }
    public async Task<VariantDTO> AddVariantAsync(CreateVariantDTO createVariantDTO, CancellationToken ct = default)
    {
        Variant variant = new()
        {
            VariantId = Guid.NewGuid().ToString(),
            Type = createVariantDTO.Type,
            Dishes = createVariantDTO.DishIds.Select(id => new Dish { DishId = id }).ToList()

        };

        await _variantManager.AddAsync(variant, ct);

        return new VariantDTO
        {
            VariantId = variant.VariantId ?? string.Empty,
            Type = variant.Type,
            Dishes = variant.Dishes?.Select(d => d.DishId ?? string.Empty).ToList() ?? new List<string>()
        };
    }

    public async Task DeleteVariantAsync(DeleteVariantDTO deleteVariantDTO, CancellationToken ct = default)
    {
        var variant = await _variantManager.GetByIdAsync(deleteVariantDTO.VariantId, ct);

        if (variant is null)
        {
            throw new NullReferenceException(message: "This ID does not belong to any variant!");
        }

        await _variantManager.RemoveAsync(variant, ct);
    }

    public async Task<IReadOnlyList<VariantDTO>> GetAllVariantsAsync(CancellationToken ct = default)
    {
        var variants = await _variantManager.GetAllAsync(ct);

        if (variants is null)
        {
            return new List<VariantDTO>();
        }

        return variants.Select(variant => new VariantDTO
        {
            VariantId = variant.VariantId ?? string.Empty,
            Type = variant.Type,
            Dishes = variant.Dishes?.Select(d => d.DishId ?? string.Empty).ToList() ?? new List<string>()
        }).ToList();
    }

    public async Task<VariantDTO> GetVariantByIdAsync(string id, CancellationToken ct = default)
    {
        var variant = await _variantManager.GetByIdAsync(id, ct);

        if (variant is null)
        {
            throw new NullReferenceException(message: "This ID does not belong to any Variant!");
        }

        return new VariantDTO
        {
            VariantId = variant.VariantId ?? string.Empty,
            Type = variant.Type,
            Dishes = variant.Dishes?.Select(d => d.DishId ?? string.Empty).ToList() ?? new List<string>()
        };
    }
}