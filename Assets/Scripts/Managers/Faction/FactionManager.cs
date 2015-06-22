using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FactionManager : MonoBehaviour {
    private static List<Faction> factions;

    void Start() {
        Faction[] factions = Resources.LoadAll<Faction>("Factions");

        if (factions.Length <= 0) {
            Debug.LogError("No factions were loaded!");
        }

        FactionManager.factions = new List<Faction>(factions);
    }

    public static List<Faction> GetFactions() {
        return factions;
    }

    public static Faction GetFaction(string techName) {
        foreach (Faction faction in factions) {
            if (faction.techName == techName) {
                return faction;
            }
        }

        Debug.LogError("Faction not found by techName! techName: \"" + techName + "\"");
        return null;
    }
}
