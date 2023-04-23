namespace Core.Models.UserRoleAccessLevelRights;

public enum AccessLevel
{
    /// <summary>
    /// Только чтение собственно созданных сущностей
    /// </summary>
    Read = 0,

    /// <summary>
    /// Возможность создавать собственные сущности + выше
    /// </summary>
    Write = 1,

    /// <summary>
    /// Возможность чтения всех сущностей + выше
    /// </summary>
    ReadAll = 2,

    /// <summary>
    /// Полный доступ ко всем сущностям
    /// </summary>
    WriteAll = 3
}