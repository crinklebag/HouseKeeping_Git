using UnityEngine;
using System.Collections;

/*
    Can be watered and sunned - once successful always successful.
    Cannot be interacted with by player.
*/

[DisallowMultipleComponent]
public class Plant : MonoBehaviour {

    [Tooltip("Drag in the associated room puzzle that this object belongs to.")]
    [SerializeField] Puzzle puzzle;

    [Header("Object References: ")]
    [SerializeField] GameObject flower;
    [SerializeField] MeshRenderer plantBody;
    [SerializeField] Material wateredPlantMat;

    bool successful = false;

    public void NourishPlant() {
        Debug.Log("Nourishing Plant");
        plantBody.GetComponent<MeshRenderer>().material = wateredPlantMat;
        flower.SetActive(true);
        puzzle.Success();
    }
}
