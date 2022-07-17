using Microsoft.Extensions.Logging;
using TestLanding.Interfaces;
using TestLanding.Services.Data;
using Microsoft.EntityFrameworkCore;
using TestLanding.DAL.Context;

namespace TestLanding.Services.Services;

public class DbInitializer : IDbInitializer
{
    private readonly TestLandingDB db;
    private readonly ILogger<DbInitializer> logger;

    public DbInitializer(TestLandingDB Db, ILogger<DbInitializer> Logger)
    {
        db = Db;
        logger = Logger;
    }
    public async Task<bool> RemoveAsync(CancellationToken Cancel = default)
    {
        logger.LogInformation("Удаление БД...");
        var removed = await db.Database.EnsureDeletedAsync(Cancel).ConfigureAwait(false);

        if (removed)
            logger.LogInformation("БД удалена успешно");
        else
            logger.LogInformation("Удаление БД не требуется (отсутствует на сервере).");
        return removed;
    }

    public async Task InitializeAsync(bool RemoveBefore = false, CancellationToken Cancel = default)
    {
        logger.LogInformation("Инициализация БД..");

        if (RemoveBefore)
            await RemoveAsync(Cancel).ConfigureAwait(false);

        //await db.Database.EnsureCreatedAsync(Cancel).ConfigureAwait(false);

        var pending_migrations = await db.Database.GetPendingMigrationsAsync(Cancel).ConfigureAwait(false);
        if (pending_migrations.Any())
        {
            logger.LogInformation("Выполнение миграции БД...");
            await db.Database.MigrateAsync(Cancel).ConfigureAwait(false);
            logger.LogInformation("Миграция БД выполнена успешно.");
        }
        else
            logger.LogInformation("Миграция БД не требуется");

        await InitializeTestDataAsync(Cancel).ConfigureAwait(false);

        logger.LogInformation("Инициализация БД выполнена успешно.");
    }

    private async Task InitializeTestDataAsync(CancellationToken Cancel = default)
    {
        if(await db.Departments.AnyAsync(Cancel).ConfigureAwait(false))
        {
            logger.LogInformation("В базе данных есть сотрудники - в инициализации тестовыми данными не нуждается");
            return;
        }

        logger.LogInformation("Инициализация тестовыми данными...");

        logger.LogInformation("Добавление отделов...");
        await using (var transaction = await db.Database.BeginTransactionAsync(Cancel))
        {
            await db.Departments.AddRangeAsync(TestData.Departments, Cancel).ConfigureAwait(false);

            await db.SaveChangesAsync(Cancel).ConfigureAwait(false);

            await transaction.CommitAsync(Cancel).ConfigureAwait(false);
        }

        logger.LogInformation("Добавление сотрудников...");
        await using (var transaction = await db.Database.BeginTransactionAsync(Cancel))
        {
            await db.Employees.AddRangeAsync(TestData.Employees, Cancel).ConfigureAwait(false);

            await db.SaveChangesAsync(Cancel).ConfigureAwait(false);

            await transaction.CommitAsync(Cancel).ConfigureAwait(false);
        }
    }
}
