using AdminPanel.Frontend.Interfaces;
using Backend.API.Enums;

namespace Backend.API.Models;

/// <summary>
/// For adding languages the person knows and fluency
/// </summary>
public class LanguageModel : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    /// <summary>
    /// How fluent you are at the language, based on the <c>LanguageLevel enum</c>
    /// </summary>
    public LanguageLevel? Level { get; set; }
    public required AboutModel Person { get; set; }
}