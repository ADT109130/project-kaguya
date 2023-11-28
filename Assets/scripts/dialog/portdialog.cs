using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class portdialog : MonoBehaviour
{
    public GameObject dialogui;
    public Button buttonYes;
    public Button buttonNo;
    public GameObject fishman1, fishman2, boss1, boss2, pointinn, inn1, inn2;
    private TextAsset[] portdialog1;
    private TextAsset[] portdialog2;
    private bool isPaused;
    private bool isMoveing;
    private bool canrob = false;
    public Animator Fade;
    public float fadewaittime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        portdialog1 = Resources.LoadAll<TextAsset>("portScene");
        portdialog2 = Resources.LoadAll<TextAsset>("portScene2");
        buttonYes.onClick.AddListener(nextday);
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
                if (raycastHit.collider.CompareTag("fishman1"))
                {
                    dialogui.GetComponent<DialogManager>().textfile = portdialog1[2];
                    dialogui.SetActive(true);
                    Debug.Log("fishman clicked");
                }
                if (raycastHit.collider.CompareTag("portinn1"))
                {
                    dialogui.GetComponent<DialogManager>().textfile = portdialog1[3];
                    dialogui.SetActive(true);
                    StartCoroutine(check());
                    Debug.Log("inn clicked");
                }
                if (raycastHit.collider.CompareTag("boss1"))
                {
                    dialogui.GetComponent<DialogManager>().textfile = portdialog1[1];
                    dialogui.SetActive(true);
                }
                if (raycastHit.collider.CompareTag("boat"))
                {
                    dialogui.GetComponent<DialogManager>().textfile = portdialog1[0];
                    dialogui.SetActive(true);
                }
                if (raycastHit.collider.CompareTag("fishman2"))
                {
                    dialogui.GetComponent<DialogManager>().textfile = portdialog2[0];
                    dialogui.SetActive(true);
                    Debug.Log("fishman clicked");
                }
                if (raycastHit.collider.CompareTag("boss2"))
                {
                    dialogui.GetComponent<DialogManager>().textfile = portdialog2[1];
                    dialogui.SetActive(true);
                    canrob = true;
                }
            }
        }

        if (dialogui.activeInHierarchy == false)
        {
            buttonYes.gameObject.SetActive(false);
            buttonNo.gameObject.SetActive(false);
        }

        if (boss2.activeInHierarchy == true && canrob) 
        {
            if (dialogui.activeInHierarchy == false)
            {
                SceneManager.LoadScene("robscene");
            }
        }
    }
    /*
    void check()
    {
        buttonYes.gameObject.SetActive(true);
        buttonNo.gameObject.SetActive(true);
    }*/

    private void nextday()
    {
        StartCoroutine(loadFade());
        //dialogui.SetActive(false);
        fishman1.SetActive(false);
        fishman2.SetActive(true);
        boss1.SetActive(false);
        boss2.SetActive(true);
        pointinn.SetActive(false);
        inn1.SetActive(false);
        inn2.SetActive(true);
    }


    IEnumerator loadFade()
    {
        Fade.SetTrigger("start");

        yield return new WaitForSeconds(fadewaittime);

        Fade.SetTrigger("quit");
    }

    IEnumerator check()
    {
        yield return new WaitForSeconds(1.2f);
        buttonYes.gameObject.SetActive(true);
        buttonNo.gameObject.SetActive(true);
    }
}
