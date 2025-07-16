using System.ComponentModel;

namespace FootballManager.DataAccess.Entities
{
    public enum PlayerPositions
    {
        [Description("Bramkarz")]
        GK,
        LB,
        CB,
        RB,
        LM,
        CM,
        [Description("Prawe Skrzydło")]
        RM,
        FW
    }
}
