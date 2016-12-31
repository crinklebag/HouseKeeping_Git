using UnityEngine;
using System.Collections;

/*
    Can be cooled and heated.
    Cannot be interacted with by player.
*/

public class HeatableObject : MonoBehaviour {

    [Tooltip("Drag in the associated room puzzle that this object belongs to.")]
    [SerializeField] Puzzle puzzle;

    [Header("Object References")]
    [SerializeField] GameObject objectBody;
    [SerializeField] GameObject triggerBox;
    [SerializeField] Material coolMat;
    [SerializeField] Material warmMat;
    [Tooltip("Enter in 'warm' or 'cool' depending on what state the curtains should be in when the puzzle is solved.")]
    [SerializeField] string goalState;
    [SerializeField] string goalMessage = "Nice and Cool!";
    [SerializeField] int targetTemp = 0;

    int objectTemp = 0;
    bool successful = false;

    public void Cool() {
        Debug.Log("Cooling Temp: " + objectTemp);
        // Successful
        if (goalState.ToLower() == "cool" && targetTemp == objectTemp) {
            Debug.Log("Successfully Cooled");
            objectBody.GetComponent<MeshRenderer>().material = coolMat;
            triggerBox.GetComponent<InteractTrigger>().ChangeMessage(goalMessage);
            successful = true;
            puzzle.Success();
        }
        // Not Successful
        else if (goalState.ToLower() != "cool" && successful == true) {
            // If it was previously successful
            successful = false;
            puzzle.Failure();
        }
    }

    public void Warm() {
        // Successful
        if (goalState.ToLower() == "warm" && targetTemp == objectTemp) {
            Debug.Log("Successfully Heated");
            objectBody.GetComponent<MeshRenderer>().material = warmMat;
            triggerBox.GetComponent<InteractTrigger>().ChangeMessage(goalMessage);
            successful = true;
            puzzle.Success();
        } // Not Successful
        else if (goalState.ToLower() != "warm" && successful == true) {
            // If it was previously successful
            successful = false;
            puzzle.Failure();
        }
    }

    public void EffectTemp(int effect) {
        objectTemp += effect;
    }
}
