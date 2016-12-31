using UnityEngine;
using System.Collections;

/*
    Can be interected with by player.
*/

public class MoveableObject : MonoBehaviour {

    [Tooltip("Drag in the associated room puzzle that this object belongs to.")]
    [SerializeField] Puzzle puzzle;

    [Header("Object Refences")]
    [SerializeField] Material successMat;
    [SerializeField] GameObject cat;
    [SerializeField] GameObject catGoal;
    [SerializeField] GameObject dresserBody;

    bool canMove = true;
    public bool successful = false;

    void SunCat() {
        if (cat != null) {
            cat.SetActive(false);
            catGoal.SetActive(true);
        }
    }

    public void Interact(Vector3 forceDirection, float forcePower) {
        Debug.Log("Adding Force");
        this.GetComponent<Rigidbody>().AddForce(forceDirection * forcePower, ForceMode.Impulse);
    }

    public void RightSpot() {
        canMove = false;
        successful = true;
        MeshRenderer[] children = dresserBody.transform.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in children) {
            mesh.material = successMat;
        }

        puzzle.Success();
        SunCat();
    }
}
