﻿using Backend.API.AbstractClasses;
using Backend.API.Entities.Interface;
using Backend.API.Enums;

namespace Backend.API.Entities;

/// <summary>
/// For adding languages the person knows and fluency
/// </summary>
public class LanguageDTO : BaseDto
{
    /// <summary>
    /// How fluent you are at the language, based on the <c>LanguageLevel enum</c>
    /// </summary>
    public LanguageLevel? Level { get; set; }
}