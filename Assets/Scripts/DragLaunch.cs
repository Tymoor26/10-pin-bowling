using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {
    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();

    }

    public void DragStart()
    {
        if (!ball.inPlay)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd()
    {
        if (!ball.inPlay)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float diffTime = endTime - startTime;
            float launchSpeedX = (dragEnd.x - dragStart.x) / diffTime;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / diffTime;
            Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
            ball.Launch(launchVelocity);
        }
    }

    public void MoveStart(float xNudge)
    {
        if (!ball.inPlay)
        {
            Mathf.Clamp(0, -53, 53);
            ball.transform.Translate(new Vector3(xNudge, 0, 0));
        }
    }

}
