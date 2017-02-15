using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public bool inPlay;

    private Rigidbody rigi;
    private AudioSource audi;
    private Vector3 ballStartPos;


    // Use this for initialization
    void Start () {
        rigi = GetComponent<Rigidbody>();
        rigi.useGravity = false;
        inPlay = false;
        ballStartPos = transform.position;
	}

    public void Launch(Vector3 velocity)
    {
        rigi.useGravity = true;
        rigi.velocity = velocity;

        audi = GetComponent<AudioSource>();
        audi.Play();
        inPlay = true;
    }

    public void ResetBall()
    {
        inPlay = false;
        rigi.velocity = Vector3.zero;
        rigi.angularVelocity = Vector3.zero;
        rigi.useGravity = false;
        transform.position = ballStartPos;
        print("Ball reset");
    }
}
