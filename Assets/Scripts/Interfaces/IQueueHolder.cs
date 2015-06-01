using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IQueueHolder {
    List<QueueItem> GetQueueItems();
}
