using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game {
    public Dictionary<NetworkPlayer, PlayerData> connectedPlayers = new Dictionary<NetworkPlayer, PlayerData>();



    public class PlayerData {
        public string name = "";
        public Faction faction = Faction.Allied;
    }
}
