using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitInstruction : MonoBehaviour
{
    public GameObject waitText;
    const float period = 1f;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        EnableText();
        startTime = 0.1f;
        Invoke("DisableText", 8f);//invoke after 5 seconds
    }

    // Update is called once per frame
    void Update()
    {
        {
            Color colorOfObject = GetComponent<Text>().color;//Changed this
            colorOfObject.a = Mathf.Lerp(1, 0, startTime);
            GetComponent<Text>().color = colorOfObject;//Changed this
            startTime *=1.01f;
        }
    }
    void DisableText()
    {
        waitText.SetActive(false);

    }
    void EnableText()
    {
        waitText.SetActive(true);

        startTime = 0.1f;
        Color colorOfObject = GetComponent<Text>().color;//Changed this
        colorOfObject.a = 1;
        GetComponent<Text>().color = colorOfObject;//Changed this
    }
}
