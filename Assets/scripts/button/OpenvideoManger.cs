using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OpenvideoManger : MonoBehaviour
{
    public GameObject SkipBTN;
    public VideoPlayer openVidoe;
    public float timeCount = 0f;
    public float videolenth;
    // Start is called before the first frame update
    void Start()
    {
        videolenth = (float)openVidoe.GetComponent<VideoPlayer>().clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCount > videolenth)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        

        TimeCount();



        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                SkipBTN.SetActive(true);
                StartCoroutine(ButtonDisappear());
            }
        }
    }

    void TimeCount()
    {
        timeCount += Time.deltaTime;
        Debug.Log(timeCount);
        Debug.Log(videolenth);
    }

    IEnumerator ButtonDisappear()
    {
        yield return new WaitForSeconds(2f);
        SkipBTN.SetActive(false);
    }
}
