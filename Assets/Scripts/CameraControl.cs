using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public Ball ball;
    private Vector3 ballToCameraOffset;
    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        ballToCameraOffset = transform.position - ball.transform.position;
        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (ball.transform.position.z >= 1650f)
        {
            transform.position += new Vector3 (0,0,0);
        }
        else
        {
            transform.position = ball.transform.position + ballToCameraOffset;
        }
    }
}
