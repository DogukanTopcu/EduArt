using UnityEngine;

public class LandscapeOrientation : MonoBehaviour
{
    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
