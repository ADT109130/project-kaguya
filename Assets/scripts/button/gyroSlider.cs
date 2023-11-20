using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gyroSlider : MonoBehaviour
{
    public Slider gyroslider;
    public static bool gyroON = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroslider.value == 1)
        {
            gyroON = true;
        }
        else
        {
            gyroON = false;
        }
    }
}
