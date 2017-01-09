using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TempTrigger : MonoBehaviour {
    
    [SerializeField] GameObject notificationPanel;
    [SerializeField] string message;

    void OnTriggerEnter(Collider other) {
        notificationPanel.GetComponentInChildren<Text>().text = message;
        notificationPanel.SetActive(true);
    }

    void OnTriggerExit(Collider other) {
        notificationPanel.SetActive(false);
    }
}
