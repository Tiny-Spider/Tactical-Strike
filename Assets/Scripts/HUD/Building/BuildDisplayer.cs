using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(LayoutGroup))]
public class BuildDisplayer : MonoBehaviour {
    public BuildEntry entryPrefab;
    public BuildManager buildManager;

    void Awake() {
        Clear();
    }

    void Start() {
        Refresh();
    }

    void Clear() {
        BuildEntry[] entries = GetComponentsInChildren<BuildEntry>();

        foreach (BuildEntry entry in entries) {
            Destroy(entry.gameObject);
        }
    }

    void Refresh() {
        Clear();

        Game game = GameManager.instance.game;
        Player player = game.GetPlayer();
        Faction faction = player.faction;

        foreach (StructureCreation structureCreation in faction.structures) {
            BuildEntry entry = Instantiate(entryPrefab);
            Structure structure = structureCreation.structure;
            bool canBuild = player.HasResources(structureCreation.cost);
            
            entry.Initalize(structure, () => { buildManager.StartBuild(structure); });
            entry.SetActive(canBuild);
            entry.transform.SetParent(transform);
        }
    }
}
