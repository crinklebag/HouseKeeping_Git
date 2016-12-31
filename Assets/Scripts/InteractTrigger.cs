using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
    Name all interactable objects based off of what the are, use these names as a refernce:
        1. Moveable
        2. Cup
        3. Curtain
*/

public class InteractTrigger : MonoBehaviour {

    [SerializeField] GameObject interactableObject;
    [SerializeField] GameObject objectOutline;
    [SerializeField] string failInstructions = "These fish are boiling!";
    [SerializeField] Vector3 forceDirection;
    [SerializeField] float forcePower;
    
    GameObject instructionsText;
    PlayerInput player;
    string instructions;

    // Use this for initialization
    void Start () {
        instructions = failInstructions;
        instructionsText = GameObject.FindGameObjectWithTag("Trigger Text");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && interactableObject.activeSelf == true) {
            objectOutline.SetActive(true);
            instructionsText.transform.GetChild(0).gameObject.SetActive(true);
            instructionsText.transform.GetChild(0).GetComponent<Text>().text = instructions;
            player.SetCanInteract(true, this.gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            instructionsText.transform.GetChild(0).gameObject.SetActive(false);
            player.SetCanInteract(false, null);
            objectOutline.SetActive(false);
        }
    }

    public void InteractWithObject() {
        Debug.Log("Object Type: " + interactableObject.tag);
        switch (interactableObject.tag) {
            case "Moveable": // Shelves
                interactableObject.GetComponent<MoveableObject>().Interact(forceDirection, forcePower);
                break;
            case "Cup": // Cup
                interactableObject.GetComponent<Cup>().Interact();
                break;
            case "Curtain": // Curtain
                interactableObject.GetComponent<Curtain>().Interact();
                break;
        }
    }

    public void ChangeMessage(string newMessage) {
        instructions = newMessage;
    }
}
