using UnityEngine;
using System.Collections;
/*
    Get list of windows touched by light
    cast ray to those windows
    if there is nothing in the way, charge the battery - put this scipt on the player battery 
*/
public class PlayerInput : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] GameObject battery;
    [SerializeField] GameObject lightSource;
    public bool outside;

    GameObject interactableObject;
    bool canInteract = false;
    bool colliding = false;
    int roomNumber = 1;
    public float currentSpeed;

    void Start() {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update() {
        HandleInput();
        CheckForLight();
    }

    void CheckForLight() {
        // Cast a ray from the battery to the life

        // If the ray hits any object EXCEPT FOR the robot, the battery, or the window - the window is not being hit by the light

        // Drain battery

        // If it is only hitting either the robot, the battery, or the window - then it is in the light

        // Fill Battery
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // move left
            if (!outside) { this.GetComponent<Rigidbody>().MovePosition(this.transform.position + Vector3.left * currentSpeed * Time.deltaTime); }
            else { this.GetComponent<Rigidbody>().MovePosition(this.transform.position + Vector3.forward * currentSpeed * Time.deltaTime); }
            // transform.Rotate(this.transform.up, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // move right
            if (!outside) { this.GetComponent<Rigidbody>().MovePosition(this.transform.position + Vector3.right * currentSpeed * Time.deltaTime); }
            else { this.GetComponent<Rigidbody>().MovePosition(this.transform.position + Vector3.back * currentSpeed * Time.deltaTime); } 
            //transform.Rotate(this.transform.up, 1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            // move forward
            if (!outside) { this.GetComponent<Rigidbody>().MovePosition(this.transform.position + Vector3.forward * currentSpeed * Time.deltaTime); }
            else { this.GetComponent<Rigidbody>().MovePosition(this.transform.position + Vector3.right * currentSpeed * Time.deltaTime); }
        }
        if (Input.GetKey(KeyCode.S))
        {
            // move back
            if (!outside) { this.GetComponent<Rigidbody>().MovePosition(this.transform.position + Vector3.back * currentSpeed * Time.deltaTime); }
            else { this.GetComponent<Rigidbody>().MovePosition(this.transform.position + Vector3.left * currentSpeed * Time.deltaTime); }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            // Debug.Log("Interacting");
            if (canInteract) { interactableObject.GetComponent<InteractTrigger>().InteractWithObject(); }
            else { } // Jump
        }
    }

    public void SetCanInteract(bool state, GameObject newInteractableObject) {
        canInteract = state;
        interactableObject = newInteractableObject;
    }

    // Call in the move cam trigger
    public void SetRoomNumber(int newRoom) {
        roomNumber = newRoom;
    }
}
