using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogButton : MonoBehaviour
{
    public GameObject dialogui;
    private TextAsset[] dialogbox;
    private bool isPaused;
    private bool isMoveing;

    // Start is called before the first frame update
    void Start()
    {
        dialogbox = Resources.LoadAll<TextAsset>("kaguyahouse");

    }

    // Update is called once per frame
    void Update()
    {
        isMoveing = TouchCameraRotation.isMoveing;
        isPaused = pausemanger.isPaused;
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Ended) && isPaused == false && isMoveing == false && dialogui.activeInHierarchy == false)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("kaguya"))
                {
                    dialogui.GetComponent<DialogManager>().textfile= dialogbox[1];
                    dialogui.SetActive(true);
                    Debug.Log("kaguya clicked");
                }
                if (raycastHit.collider.CompareTag("kaguyahouse"))
                {
                    dialogui.GetComponent<DialogManager>().textfile = dialogbox[0];
                    dialogui.SetActive(true);
                    Debug.Log("kaguyahouse clicked");
                }
            }
        }

    }
}
