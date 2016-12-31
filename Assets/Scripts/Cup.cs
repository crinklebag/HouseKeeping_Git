using UnityEngine;
using System.Collections;

/*
    Can be tipped and untipped. 
    Can be interacted with by player.
*/

public class Cup : MonoBehaviour {

    [Tooltip("Drag in the associated room puzzle that this object belongs to.")]
    [SerializeField] Puzzle puzzle;

    [Header("Object References")] 
    [SerializeField] GameObject cupWater;
    [SerializeField] GameObject waterSpill;
    [Tooltip("Enter in 'tipped' or 'not tipped' depending on what state the curtains should be in when the puzzle is solved.")]
    [SerializeField] string goalState;
    
    bool successful = false;
    bool tipped = false;

    void Start() {
        if (goalState.ToLower() == "tipped") { UntipGlass(); }
        else { TipGlass(); }
    }

    public void TipGlass() {
        waterSpill.SetActive(true);
        cupWater.SetActive(false);
        tipped = true;

        if (goalState.ToLower() == "tipped") {
            puzzle.Success();
            successful = true;
        }
        else if (goalState.ToLower() != "tipped" && successful) {
            puzzle.Failure();
            successful = false;
        }
    }

    public void UntipGlass() {
        waterSpill.SetActive(false);
        cupWater.SetActive(true);
        tipped = false;

        if (goalState.ToLower() == "not tipped") {
            puzzle.Success();
            successful = true;
        }
        else if (goalState.ToLower() != "not tipped" && successful) {
            puzzle.Failure();
            successful = false;
        }
    }

    public void Interact() {
        if (tipped) {
            UntipGlass();
        } else {
            TipGlass();
        }
    }
}
