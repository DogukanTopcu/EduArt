using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ResetARSession : MonoBehaviour
{
    private ARSession arSession;
    void Awake()
    {
        arSession = GameObject.Find("AR Session").GetComponent<ARSession>();
        arSession.Reset();
    }

    public void ResetSession()
    {
        arSession.Reset();
    }
}
