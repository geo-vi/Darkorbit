using System.Collections.Generic;

namespace Darkorbit.Network
{
    public static class Items
    {
        public const int NONE = 0;
        public const int POWDER = 1;
        public const int PLATES = 2;
        public const int TRITONS_BLESSING = 42;
        public const int TRITONS_BENEVOLENCE = 54;
        public const int TRITONS_CROWN = 63;
        public const int OGOUN_AMULET = 43;
        public const int AGWE_AMULET = 44;
        public const int LEGBA_AMULET = 45;
        public const int SIMBI_AMULET = 64;
        public const int UNSTOPABLE = 52;
        public const int SPEEDSTONE = 27;
        public const int PUMPKIN_POWER = 16;
        public const int CANDLE = 22;
        public const int SNOWMAN = 21;
        public const int WINTERLIGHT = 23;
        public const int HAILSTORM = 28;
        public const int WINDSTORM = 29;
        public const int BLOODLUST = 33;
        public const int SKY_FIRE = 1;
        public const int ELMOS_FIRE = 0;
        public const int SMOKE_BOMB = 2;
        public const int DRAGON_FIRE = 56;
        public const int BROTHERS_IN_ARMS = 3;
        public const int LOST_LOVE = 51;
        public const int SUPER_ARMOR_PLATES = 36;
        public const int LIONS_BULWARK = 58;
        public const int LIONS_FIRE = 57;
        public const int DRAGON_FIRE_LEVEL2 = 75;
        public const int TELEPORTATION = 34;
        public const int SWEERS_VISION = 25;
        public const int EYE_OF_PRECISION = 24;
        public const int LIGHT_OF_TORTUGA = 9;
        public const int BEHEMOTH_MEDAL = 30;

        private static Dictionary<string, int> ItemsList;

        public static Dictionary<string, int> GetItems()
        {
            if (ItemsList == null)
            {
                ItemsList = new Dictionary<string, int>
                {
                    { "Triton's Blessing", TRITONS_BLESSING },
                    { "Triton's Benevolence", TRITONS_BENEVOLENCE },
                    { "Triton's Crown", TRITONS_CROWN },
                    { "Ogoun Amulet", OGOUN_AMULET },
                    { "Agwe Amulet", AGWE_AMULET },
                    { "Legba Amulet", LEGBA_AMULET },
                    { "Simbi Amulet", SIMBI_AMULET },
                    { "Swift Stone", SPEEDSTONE },
                    { "Pumpkin Power", PUMPKIN_POWER},
                    { "NONE", NONE }
                };
            }
            return ItemsList;
        }
    }
}
