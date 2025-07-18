using System.ComponentModel;

namespace FootballManager.DataAccess.Entities
{
    public enum PlayerPositions
    {
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
}
