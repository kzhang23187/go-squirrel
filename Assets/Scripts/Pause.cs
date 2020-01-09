using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    public static bool pause = false;
    public Squirrel squirrel;
    public void TogglePause()
    {
        if (pause) {
            pause = !pause;
            Time.timeScale = 1;
            squirrel.isIdle = 0;
            squirrel.anim.SetTrigger("Entry");
        } else {
            pause = !pause;
            Time.timeScale = 0;
        }

    }
}