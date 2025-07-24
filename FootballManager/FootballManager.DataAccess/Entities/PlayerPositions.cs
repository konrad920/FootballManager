using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FootballManager.DataAccess.Entities
{
    public enum PlayerPositions
    {
        [Description("Brak pozycji")]
        None = 0,

        [Description("Bramkarz")]
        GK = 1,

        [Description("Lewy Obrońca")]
        LB = 2,

        [Description("Środkowy Obrońca")]
        CB = 3,

        [Description("Prawy Obrońca")]
        RB = 4,

        [Description("Lewy Pomocnik")]
        LM = 5,

        [Description("Środkowy Pomocnik")]
        CM = 6,

        [Description("Prawy Pomocnik")]
        RM = 7,

        [Description("Napastnik")]
        FW = 8
    }

    //public static class EnumExtensions
    //{
    //    public static string GetDescription(this Enum value)
    //    {
    //        var field = value.GetType().GetField(value.ToString());
    //        var attr = field.GetCustomAttribute<DescriptionAttribute>();
    //        return attr?.Description ?? value.ToString();
    //    }

    //    public static int SetPlayerPosition(string position)
    //    {
    //        if (string.IsNullOrEmpty(position))
    //        {
    //            return -1;
    //        }


    //        int positionNumber;
    //        switch (position)
    //        {
    //            case "BR":
    //                positionNumber = (int)PlayerPositions.GK;
    //                break;
    //            case "LO":
    //                positionNumber = (int)PlayerPositions.LB;
    //                break;
    //            case "ŚO":
    //                positionNumber = (int)PlayerPositions.CB;
    //                break;
    //            case "PO":
    //                positionNumber = (int)PlayerPositions.RB;
    //                break;
    //            case "LP":
    //                positionNumber = (int)PlayerPositions.LM;
    //                break;
    //            case "ŚP":
    //                positionNumber = (int)PlayerPositions.CM;
    //                break;
    //            case "PP":
    //                positionNumber = (int)PlayerPositions.RM;
    //                break;
    //            case "N":
    //                positionNumber = (int)PlayerPositions.FW;
    //                break;
    //            default:
    //                positionNumber = (int)PlayerPositions.None;
    //                break;
    //        }
    //        return positionNumber;
    //    }
    //}

    public static class PlayerPositionMapper
    {
        private static readonly Dictionary<PlayerPositions, string> enumToShort = new()
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

        public static string ToShort(PlayerPositions pos)
        {
            return enumToShort.TryGetValue(pos, out var val) ? val : "-";
        }

        private static readonly Dictionary<string, PlayerPositions> shortToEnum = enumToShort
        .ToDictionary(kvp => kvp.Value, kvp => kvp.Key); // Odwracamy słownik

        public static PlayerPositions FromShort(string shortCode)
        {
            return shortToEnum.TryGetValue(shortCode ?? "", out var val) ? val : PlayerPositions.None;
        }
    }
}
