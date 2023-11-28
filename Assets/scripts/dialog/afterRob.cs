using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class afterRob : MonoBehaviour
{
    public GameObject dialogui;
    public Button buttonYes;
    public Button buttonNo;
    private TextAsset[] portdialog3;
    private bool isPaused;
    private bool isMoveing;
    private bool goFish = false;
    public Animator Fade;
    public float fadewaittime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        portdialog3 = Resources.LoadAll<TextAsset>("portScene3");
        buttonYes.onClick.AddListener(nextday);
        buttonNo.onClick.AddListener(no);
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
               
                if (raycastHit.collider.CompareTag("fishman3"))
                {
                    dialogui.GetComponent<DialogManager>().textfile = portdialog3[3];
                    dialogui.SetActive(true);
                }
                if (raycastHit.collider.CompareTag("boss3"))
                {
                    dialogui.GetComponent<DialogManager>().textfile = portdialog3[1];
                    dialogui.SetActive(true);
                }
                if (raycastHit.collider.CompareTag("boat3"))
                {
                    dialogui.GetComponent<DialogManager>().textfile = portdialog3[0];
                    dialogui.SetActive(true);
                    goFish = true;
                }
            }
        }

        if (dialogui.activeInHierarchy == false)
        {
            buttonYes.gameObject.SetActive(false);
            buttonNo.gameObject.SetActive(false);
        }

        if (goFish && dialogui.activeInHierarchy == false)
        {
            dialogui.GetComponent<DialogManager>().textfile = portdialog3[4];
            dialogui.SetActive(true);
            StartCoroutine(check());
        }
    }

    private void nextday()
    {
        StartCoroutine(loadFade());
    }
    private void no()
    {
        goFish = false;
    }


    IEnumerator loadFade()
    {
        Fade.SetTrigger("start");

        yield return new WaitForSeconds(fadewaittime);

        SceneManager.LoadScene("onSeaScene");
    }

    IEnumerator check()
    {
        yield return new WaitForSeconds(1f);
        buttonYes.gameObject.SetActive(true);
        buttonNo.gameObject.SetActive(true);
    }
}
