using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game {
    public Dictionary<NetworkPlayer, PlayerData> connectedPlayers = new Dictionary<NetworkPlayer, PlayerData>();
    public MapData map;

    public class PlayerData {
        public string name = "";
        public int team = 0;
        public Faction faction = FactionManager.GetFactions()[0];
        public PlayerColor color = PlayerColor.GetColor(0);

        public NetworkPlayer networkPlayer { private set; get; }

        public PlayerData(NetworkPlayer networkPlayer) {
            this.networkPlayer = networkPlayer;
        }
    }
}
