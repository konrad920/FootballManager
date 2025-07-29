using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FootballManager.DataAccess.Entities
{
    public enum PlayerPositions
    {
        None = 0,
        GK = 1,
        LB = 2,
        CB = 3,
        RB = 4,
        LM = 5,
        CM = 6,
        RM = 7,
        FW = 8
    }
    public static class PlayerPositionMapper
    {
        private static readonly Dictionary<PlayerPositions, string> enumToString = new()
        {
            [PlayerPositions.None] = "",
            [PlayerPositions.GK] = "BR",
            [PlayerPositions.LB] = "LO",
            [PlayerPositions.CB] = "ŚO",
            [PlayerPositions.RB] = "PO",
            [PlayerPositions.LM] = "LP",
            [PlayerPositions.CM] = "ŚP",
            [PlayerPositions.RM] = "PP",
            [PlayerPositions.FW] = "N",
        };

        public static string ToString(PlayerPositions pos)
        {
            return enumToString.TryGetValue(pos, out var val) ? val : "-";
        }

        private static readonly Dictionary<string, PlayerPositions> stringToEnum = enumToString
        .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        public static PlayerPositions FromString(string shortCode)
        {
            return stringToEnum.TryGetValue(shortCode ?? "", out var val) ? val : PlayerPositions.None;
        }
    }
}
