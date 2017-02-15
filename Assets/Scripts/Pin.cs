using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {
    public float standingThreshold;

    private Rigidbody rigi;

    // Use this for initialization
    void Start () {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
    }

    public bool IsStanding()
    {
        Vector3 rotInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(rotInEuler.x);
        float tiltInZ = Mathf.Abs(rotInEuler.z);

        if ((tiltInX < 270 + standingThreshold || tiltInX > 270 - standingThreshold) && (tiltInZ < standingThreshold || tiltInZ > 360 - standingThreshold)) { return true; }
        else                                                                                                                                          { return false;}
    }

    public void Raise()
    {
        rigi.useGravity = false;
        float yPos = 100f;
        transform.Translate(new Vector3(0, yPos, 0), Space.World);
    }

    public void Lower()
    {
        float yPos = -100f;
        transform.Translate(new Vector3(0, yPos, 0), Space.World);
        rigi.useGravity = true;
    }

    

}
