using UnityEngine;

public class PortraitOrientation : MonoBehaviour
{
    void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
