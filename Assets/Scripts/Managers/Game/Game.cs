using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game {
    private Dictionary<NetworkPlayer, Player> connectedPlayers = new Dictionary<NetworkPlayer, Player>();
    private MapData map;

    public MapData GetMap() {
        return map;
    }

    public void SetMap(MapData map) {
        this.map = map;
    }

    public Player GetPlayer() {
        return GetPlayer(Network.player);
    }

    public Player GetPlayer(NetworkPlayer networkPlayer) {
        return connectedPlayers[networkPlayer];
    }

    public Player AddPlayer(NetworkPlayer networkPlayer) {
        Player playerData = new Player(networkPlayer);

        connectedPlayers.Add(networkPlayer, playerData);

        return playerData;
    }

    public Player RemovePlayer(NetworkPlayer networkPlayer) {
        Player playerData = GetPlayer(networkPlayer);

        connectedPlayers.Remove(networkPlayer);

        return playerData;
    }

    public Dictionary<NetworkPlayer, Player> GetPlayers() {
        return connectedPlayers;
    }
}
