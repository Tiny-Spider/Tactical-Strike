using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Player {
    public delegate void ResourcesChangedEvent();
    public event ResourcesChangedEvent OnResourcesChanged = delegate { };

    public delegate void StructureBuildEvent(Structure structure);
    public event StructureBuildEvent OnStructureBuild = delegate { };


    public string name = "";
    public int team = 0;
    public Faction faction = FactionManager.GetFactions()[0];
    public PlayerColor color = PlayerColor.GetColor(0);

    private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();
    private List<Structure> structures = new List<Structure>();
    private List<Unit> units = new List<Unit>();

    public NetworkPlayer networkPlayer { private set; get; }

    public Player(NetworkPlayer networkPlayer) {
        this.networkPlayer = networkPlayer;

        Instatiate();
    }

    private void Instatiate() {
        foreach (ResourceType resourceType in Enum.GetValues(typeof(ResourceType))) {
            resources.Add(resourceType, 0);
        }
    }

    public void ChangeResource(ResourceType resourceType, int amount, bool add) {
        resources[resourceType] += add ? amount : -amount;
        OnResourcesChanged();
    }

    public void ChangeResources(IEnumerable<Cost> costs, bool add) {
        // Do this so there won't be event spam
        foreach (Cost cost in costs) {
            resources[cost.resourceType] += add ? cost.amount : -cost.amount;
        }

        OnResourcesChanged();
    }

    public bool HasResource(ResourceType resourceType, int amount) {
        return resources[resourceType] >= amount;
    }

    public bool HasResources(IEnumerable<Cost> costs) {
        foreach (Cost cost in costs) {
            if (!HasResource(cost.resourceType, cost.amount)) {
                return false;
            }
        }

        return true;
    }

    public Dictionary<ResourceType, int> GetResources() {
        return resources;
    }

    public void CallStructureBuild(Structure structure) {
        OnStructureBuild(structure);
    }
}
