using System.Collections.Generic;
using Darkorbit.Helper;
using DotNetty.Buffers;

namespace Darkorbit.Network.Messages
{
    class ShipInitializationCommand : Message
    {
        public const int Id = 26642;
        int userId;

        string userName;
        int shipType; int speed; int shield; int shieldMax; int hitPoints; int hitMax;
            int cargoSpace; int cargoSpaceMax; int nanoHull; int maxNanoHull; int x; int y; int mapId; int factionId; int clanId; int laserBatteriesMax;
            int rocketsMax; int expansionStage; bool premium; double ep; double honourPoints; int level; double credits; double uridium; float jackpot; int dailyRank;
            string clanTag; int galaxyGatesDone; bool useSystemFont; bool cloaked; List<VisualModifierCommand> modifiers;
        public int GetId()
        {
            return Id;
        }

        public ShipInitializationCommand(int userId, string userName, int shipType, int speed, int shield, int shieldMax, int hitPoints, int hitMax, int cargoSpace, int cargoSpaceMax, int nanoHull, int maxNanoHull, int x, int y, int mapId, int factionId, int clanId, int laserBatteriesMax, int rocketsMax, int expansionStage, bool premium, double ep, double honourPoints, int level, double credits, double uridium, float jackpot, int dailyRank, string clanTag, int galaxyGatesDone, bool useSystemFont, bool cloaked, List<VisualModifierCommand> modifiers)
        {
            this.userId = userId;
            this.userName = userName;
            this.shipType = shipType;
            this.speed = speed;
            this.shield = shield;
            this.shieldMax = shieldMax;
            this.hitPoints = hitPoints;
            this.hitMax = hitMax;
            this.cargoSpace = cargoSpace;
            this.cargoSpaceMax = cargoSpaceMax;
            this.nanoHull = nanoHull;
            this.maxNanoHull = maxNanoHull;
            this.x = x;
            this.y = y;
            this.mapId = mapId;
            this.factionId = factionId;
            this.clanId = clanId;
            this.laserBatteriesMax = laserBatteriesMax;
            this.rocketsMax = rocketsMax;
            this.expansionStage = expansionStage;
            this.premium = premium;
            this.ep = ep;
            this.honourPoints = honourPoints;
            this.level = level;
            this.credits = credits;
            this.uridium = uridium;
            this.jackpot = jackpot;
            this.dailyRank = dailyRank;
            this.clanTag = clanTag;
            this.galaxyGatesDone = galaxyGatesDone;
            this.useSystemFont = useSystemFont;
            this.cloaked = cloaked;
            this.modifiers = modifiers;
        }

        public void Read(IByteBuffer param1)
        {
  
        }

        public void Write(IByteBuffer param1)
        {
            param1.WriteShort(Id);
            param1.WriteInt(userId);
            param1.WriteUTF(userName);
            param1.WriteInt(shipType);
            param1.WriteInt(speed);
            param1.WriteInt(shield);
            param1.WriteInt(shieldMax);
            param1.WriteInt(hitPoints);
            param1.WriteInt(hitMax);
            param1.WriteInt(cargoSpace);
            param1.WriteInt(cargoSpaceMax);
            param1.WriteInt(nanoHull);
            param1.WriteInt(maxNanoHull);
            param1.WriteInt(x);
            param1.WriteInt(y);
            param1.WriteInt(mapId);
            param1.WriteInt(factionId);
            param1.WriteInt(clanId);
            param1.WriteInt(laserBatteriesMax);
            param1.WriteInt(rocketsMax);
            param1.WriteInt(expansionStage);
            param1.WriteBoolean(premium);
            param1.WriteDouble(ep);
            param1.WriteDouble(honourPoints);
            param1.WriteInt(level);
            param1.WriteDouble(credits);
            param1.WriteDouble(uridium);
            param1.WriteFloat(jackpot);
            param1.WriteInt(dailyRank);
            param1.WriteUTF(clanTag);
            param1.WriteInt(galaxyGatesDone);
            param1.WriteBoolean(useSystemFont);
            param1.WriteBoolean(cloaked);
            param1.WriteInt(modifiers.Count);
            foreach (var item in modifiers)
            {
                item.Write(param1);
            }
        }
    }
}
