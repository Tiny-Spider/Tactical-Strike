using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {
    public string name = "";
    public int team = 0;
    public Faction faction = FactionManager.GetFactions()[0];
    public PlayerColor color = PlayerColor.GetColor(0);

    public Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();
    public List<Structure> structures = new List<Structure>();
    public List<Unit> units = new List<Unit>();

    public NetworkPlayer networkPlayer { private set; get; }

    public Player(NetworkPlayer networkPlayer) {
        this.networkPlayer = networkPlayer;
    }
}
