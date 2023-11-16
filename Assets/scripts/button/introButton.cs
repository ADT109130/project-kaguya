using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introButton : MonoBehaviour
{

    public GameObject intro1;
    public GameObject intro2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void introcontrol()
    {
        if (intro1.activeInHierarchy == true)
        {
            intro2.SetActive(true);
            intro1.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("startScene");
        }
    }
}
