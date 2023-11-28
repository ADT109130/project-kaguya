using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    SpriteRenderer pointren;
    float shankeTime = 0f;
    public bool isShake = true;

    // Start is called before the first frame update
    void Start()
    {
        pointren = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ToChangeColor();
    }


    void ToChangeColor()
    {
        if (isShake)
        {
            shankeTime += Time.deltaTime;
            if (shankeTime % 1 <= 0.2f)
            {
                pointren.color = new Color(1, 1, 1, 0.8f);
            }
            else if (shankeTime % 1 <= 0.4f)
            {
                pointren.color = new Color(1, 1, 1, 0.6f);
            }
            else if (shankeTime % 1 <= 0.6f)
            {
                pointren.color = new Color(1, 1, 1, 0.4f);
            }
            else if (shankeTime % 1 <= 0.8f)
            {
                pointren.color = new Color(1, 1, 1, 0.6f);
            }
            else 
            {
                pointren.color = new Color(1, 1, 1, 0.8f);
            }
        }
    }

}
