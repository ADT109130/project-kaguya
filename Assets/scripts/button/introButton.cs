using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introButton : MonoBehaviour
{
    public Animator Fade;
    public float fadewaittime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            StartCoroutine(loadFade("StartScene"));
        }
    }

    IEnumerator loadFade(string sceneIndex)
    {
        Fade.SetTrigger("start");

        yield return new WaitForSeconds(fadewaittime);

        SceneManager.LoadScene(sceneIndex);
    }
}
