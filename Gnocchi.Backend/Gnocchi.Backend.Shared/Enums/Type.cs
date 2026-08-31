namespace Gnocchi.Backend.Shared.Enums;

[Flags] // To be able to combine enum values
// TODO: Ask M about different types/specialties when it comes to cooking
public enum Type
{
    Vegetarian,
    Vegan,
    Pescitarian,
    LCHF,
    WithoutOnions,
}