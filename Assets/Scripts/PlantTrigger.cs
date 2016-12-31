using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class PlantTrigger : MonoBehaviour {

    [Header("Object References: ")]
    [SerializeField] GameObject plant;

    bool sunned = false;
    bool watered = false;
    bool nourished = false;

    void OnTriggerEnter(Collider other) {
        // Debug.Log("Other: " + other.name);
        if (other.CompareTag("Cup")) {
            watered = true;
            Debug.Log("Watering Plant");
        }
        if (other.CompareTag("Plant")) {
            sunned = true;
            Debug.Log("Sunning Plant");
        }

        CheckSuccess();
    }

    void CheckSuccess() {
        if (watered && sunned && !nourished) {
            plant.GetComponent<Plant>().NourishPlant();
            nourished = true;
        }
    }
}
