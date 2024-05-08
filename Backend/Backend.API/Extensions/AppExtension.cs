using Backend.API.Database;

namespace Backend.API.Extensions;

public static class AppExtension
{
    /// <summary>
    /// Setup database without migration.
    /// <remarks>Only use for development purpose, not for production</remarks>
    /// </summary>
    /// <param name="recreateDatabase">If <c>true</c> will drop database and recreate it</param>
    public static void NoMigration(this WebApplication? app, bool recreateDatabase = false)
    {
        var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CvContext>();

        if (recreateDatabase) context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}