using UnityEngine;
using System.Collections;

public class DemoController : MonoBehaviour {

    //References
    [SerializeField] GameObject character;
    [SerializeField] GameObject[] lights;

    // Room 1
    Vector3 rm1CamPos = new Vector3(0, 11.5f, -3);
    Vector3 rm1CamRot = new Vector3(75, 0, 0);
    Vector3 rm1CharPos = new Vector3(0, 1, -3);

    // Room 2
    Vector3 rm2CamPos = new Vector3(0, 15, -3.5f);
    Vector3 rm2CamRot = new Vector3(10, 0, 0);
    Vector3 rm2CharPos = new Vector3(-2, 12, 0);

    // Back Yard
    Vector3 BYCamPos = new Vector3(-17.5f, 12.5f, 30);
    Vector3 BYCamRot = new Vector3(40, 90, 0);
    Vector3 BYCharPos = new Vector3(-11, 0, 36);

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Change the camera view and player position on these button clicks
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            Camera.main.transform.position = rm1CamPos;
            Camera.main.transform.rotation = Quaternion.Euler(rm1CamRot);
            character.transform.position = rm1CharPos;
            character.GetComponent<PlayerInput>().outside = false;
            lights[0].SetActive(true);
            lights[1].SetActive(false);
            lights[2].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Camera.main.transform.position = rm2CamPos;
            Camera.main.transform.rotation = Quaternion.Euler(rm2CamRot);
            character.transform.position = rm2CharPos;
            character.GetComponent<PlayerInput>().outside = false;
            lights[0].SetActive(false);
            lights[1].SetActive(true);
            lights[2].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Camera.main.transform.position = BYCamPos;
            Camera.main.transform.rotation = Quaternion.Euler(BYCamRot);
            character.transform.position = BYCharPos;
            character.GetComponent<PlayerInput>().outside = true;
            lights[0].SetActive(false);
            lights[1].SetActive(false);
            lights[2].SetActive(true);
        }
    }
}
