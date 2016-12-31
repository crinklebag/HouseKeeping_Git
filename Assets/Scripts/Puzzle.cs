using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Puzzle : MonoBehaviour {

    [Tooltip("Number of Objects that need to be moved to solve the room:")]
    [SerializeField] int successObjects;

    [Header("Object Refernces: ")]
    [SerializeField] GameObject lockedDoor;

    int successObjectCount = 0;

    void CheckWin() {
        if (successObjectCount == successObjects) {
            lockedDoor.SetActive(false);
        } else {
            lockedDoor.SetActive(true);
        }
    }

    public void Success() {
        successObjectCount++;
        CheckWin();
    }

    public void Failure() {
        successObjectCount--;
        CheckWin();
    }
}
