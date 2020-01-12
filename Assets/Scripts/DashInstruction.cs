using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashInstruction : MonoBehaviour
{
    public GameObject dashText;
    const float period = 6f;
    private float startTime = 0.1f;
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
            startTime *= 1.01f;
        }
    }
    void DisableText()
    {
        dashText.SetActive(false);
        startTime = 0.1f;

    }
    void EnableText()
    {
        dashText.SetActive(true);
        Color colorOfObject = GetComponent<Text>().color;//Changed this
        colorOfObject.a = 1;
        GetComponent<Text>().color = colorOfObject;//Changed this
    }
}
