using System;

namespace ContentManagementSystem.Extensions;

internal static class GuidExtensions
{
    internal static bool HasValue(this Guid value) => value != Guid.Empty;
}