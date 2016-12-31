using UnityEngine;
using System.Collections;

/*
    Can be opened and closed.
    Can be interacted with by player.
*/

public class Curtain : MonoBehaviour {

    [Tooltip("Drag in the associated room puzzle that this object belongs to.")]
    [SerializeField] Puzzle puzzle;
    
    [Header("Object Refernces: ")]
    [SerializeField] GameObject warmableObject;

    [Header("Object Variables: ")]
    [SerializeField] Vector3 openCurtain;
    [SerializeField] Vector3 closeCurtain;
    [Tooltip("Enter in 'open' or 'closed' depending on what state the curtains should be in when the puzzle is solved.")]
    [SerializeField] string goalState;

    bool closed = false;
    bool successful = false;

    void Start() {
        if (goalState.ToLower() == "open") { CloseCurtains(); }
        else { OpenCurtains(); }
    }

    void WarmObject() {
        if (warmableObject != null) {
            warmableObject.GetComponent<HeatableObject>().EffectTemp(1);
            warmableObject.GetComponent<HeatableObject>().Warm();
        }
    }

    void CoolObject() { 
        if (warmableObject != null) {
            warmableObject.GetComponent<HeatableObject>().EffectTemp(-1);
            warmableObject.GetComponent<HeatableObject>().Cool();
        }
    }

    void OpenCurtains() {
        if (!successful) { 
            closed = false;
            this.transform.localScale = openCurtain;
            WarmObject();
        }

        if (goalState.ToLower() == "open") { successful = true; }
    }

    void CloseCurtains() {
        if (!successful) { 
            closed = true;
            this.transform.localScale = closeCurtain;
            CoolObject();
        }

        if (goalState.ToLower() == "closed") { successful = true; }
    }

    public void Interact() {
        if (closed) {
            OpenCurtains();
        } else {
            CloseCurtains();
        }
    }
}
