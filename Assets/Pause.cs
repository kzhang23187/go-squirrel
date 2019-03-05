using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    public static bool pause = false;
    public void TogglePause()
    {
        if (pause) {
            pause = !pause;
            Time.timeScale = 1;
        } else {
            pause = !pause;
            Time.timeScale = 0;
        }

    }
}