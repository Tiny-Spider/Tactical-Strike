using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LayoutGroup))]
public class QueueDisplayer : MonoBehaviour {
    public QueueEntry entryPrefab;

    void Awake() {
        Clear();
    }

    void Start() {
        SelectionManager selectionManager = SelectionManager.instance;
        selectionManager.OnSelectEvent += Refresh;
    }

    void OnDestroy() {
        SelectionManager selectionManager = SelectionManager.instance;
        selectionManager.OnSelectEvent -= Refresh;
    }

    void Clear() {
        QueueEntry[] entries = GetComponentsInChildren<QueueEntry>();

        foreach (QueueEntry entry in entries) {
            Destroy(entry.gameObject);
        }
    }

    void Refresh(Structure structure) {
        Clear();

        IQueueHolder holder = structure as IQueueHolder;
        if (holder != null) {
            List<QueueItem> queueItems = holder.GetQueueItems();
            foreach (QueueItem queueItem in queueItems) {
                QueueEntry entry = Instantiate(entryPrefab);

                entry.Initalize(queueItem);
                entry.transform.SetParent(transform);
            }
        }
    }
}
