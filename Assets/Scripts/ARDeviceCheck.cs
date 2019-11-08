using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARDeviceCheck : MonoBehaviour
{
    [SerializeField] ARSession m_Session;

    IEnumerator Start() {
        if ((ARSession.state == ARSessionState.None )||
            (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            // Start some fallback experience for unsupported devices
            Debug.Log("AR NOT SUPPORTED ON THIS DEVICE");
        }
        else
        {
            Debug.Log("AR IS SUPPORTED ON THIS DEVICE");
            // Start the AR session
            m_Session.enabled = true;
        }
    }
}
