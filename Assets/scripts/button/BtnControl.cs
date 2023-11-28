using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnControl : MonoBehaviour
{
    public Animator Fade;
    public float fadewaittime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("leave"))
                {
                    Debug.Log("leave");
                    StartCoroutine(loadFade("portScene"));
                }
            }
        }
    }

    // Update is called once per frame
    public void menu()
    {
        StartCoroutine(loadFade("StartScene"));
    }
    public void kaguyahouse()
    {
        StartCoroutine(loadFade("kaguyahouse"));
    }
    public void portscene()
    {
        StartCoroutine(loadFade("portscene"));
    }
    public void openvideo()
    {
        StartCoroutine(loadFade("openvideoScene"));
    }
    public void openvideo2()
    {
        StartCoroutine(loadFade("openvideoScene2"));
    }
    public void intro()
    {
        StartCoroutine(loadFade("introScene"));
    }
    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void loadfade()
    {
        StartCoroutine(loadFade("playscene"));
    }
    IEnumerator loadFade(string sceneIndex)
    {
        Fade.SetTrigger("start");

        yield return new WaitForSeconds(fadewaittime);

        SceneManager.LoadScene(sceneIndex);
    }
}
