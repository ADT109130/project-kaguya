using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [Header("UI")]
    public Text textLabel;
    public Text SpeakerName;

    [Header("文本設定")]
    public TextAsset textfile;
    public int index;
    public float TextSpeed = 0.1f;

    bool textfinished;
    
    List<string> TextList = new List<string>();

    void Awake()
    {
        textLabel = GameObject.Find("dialog").GetComponent<Text>();
        SpeakerName = GameObject.Find("name").GetComponent<Text>();
        GetTextFromFile(textfile);
    }
    private void OnEnable()
    {
        //textLabel.text = TextList[index];
        //index++;
        textfinished = true;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && textfinished)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                //textLabel.text = TextList[index];
                //index++;
                StartCoroutine(SetTextUI());
            }
            if (touch.phase == TouchPhase.Began && index == TextList.Count)
            {
                gameObject.SetActive(false);
                index = 0;
                return;
            }

        }
    }

    void GetTextFromFile(TextAsset file)
    {
        TextList.Clear();
        index = 0;


        var linedata = file.text.Split('\n');

        foreach (var line in linedata)
        {
            TextList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textfinished = false;
        textLabel.text = "";

        switch (TextList[index])
        {
            case string 我:
                SpeakerName.text = "輝夜姬";
                index++;
                break;
        }

        for (int i = 0; i < TextList[index].Length; i++)
        {
            textLabel.text += TextList[index][i];

            yield return new WaitForSeconds(TextSpeed);
        }
        textfinished = true;
        index++;
    }
}