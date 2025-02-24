using Robust.Shared.Network;

namespace Content.Server.Database;

public sealed class ServerAppearanceBanDef
{
    public int? Id { get; set; }
    public NetUserId? UserId { get; }

    public int? RoundId { get; }
    public string? Reason { get; }

    public DateTimeOffset BanTime { get; }
    public DateTimeOffset? ExpirationTime { get; }

    public ServerAppearanceBanDef(
        int? id,
        NetUserId? userId,
        int? roundId,
        DateTimeOffset banTime,
        DateTimeOffset? expirationTime,
        string reason)
    {
        if (userId == null)
        {
            throw new ArgumentException("Must have a userid.");
        }

        // This lacks anti-evasion features like hwid or ip because its not really meant to be treated seriously
        // If a person wants to evade an appearance ban - let them at the cost of losing unlocked roles or hitting a multiaccount warn

        Id = id;
        UserId = userId;
        RoundId = roundId;
        Reason = reason;

        BanTime = banTime;
        ExpirationTime = expirationTime;
    }
}
