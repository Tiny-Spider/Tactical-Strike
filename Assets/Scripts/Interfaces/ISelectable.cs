using UnityEngine;
using System.Collections;

public interface ISelectable{
    bool HasStances();

    CursorType GetCursorType();

    void Select();
}
