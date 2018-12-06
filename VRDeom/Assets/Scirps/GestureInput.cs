using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
public class GestureInput : MonoBehaviour {

    GestureRecognizer recognizer;
    bool star = false;
	void Start ()
    {
        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap );
        recognizer.Tapped += RecognizerTapEvent;
        recognizer.StartCapturingGestures();
	}
	
    void Update ()
    {
		
	}
    private void  RecognizerTapEvent(TappedEventArgs tap)
    {
        if (star)
        {
            if (GazeAdsorbent.instans.Galleey != null)
            {
                GazeAdsorbent.instans.myCube.transform.Rotate(Vector3.up);
            }
            if (GazeAdsorbent.instans.SmaGameObject != null)
            {
                GazeAdsorbent.instans.Galleey.GetComponent<MeshRenderer>().material.color = GazeAdsorbent.instans.SmaGameObject.GetComponent<MeshRenderer>().material.color;
            }
        }
        
        star = !star;
    }

    private void OnDestroy()
    {
        recognizer.StopCapturingGestures();
        recognizer.Tapped -= RecognizerTapEvent;
    }
}
