using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
    public Text standingText;
    public int lastStandingCount = -1;
    public GameObject pinSet;

    private Ball ball;
    private float lastChangeTime;
    private int pinsStanding;
    private bool ballEnteredBox;
	// Use this for initialization
	void Start () {
        ballEnteredBox = false;
        standingText.color = Color.green;
        ball = GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        pinsStanding = CountStanding();
        standingText.text = pinsStanding.ToString();

        if (ballEnteredBox)
        {
            CheckStanding();
        }
	}

    void CheckStanding()
    {
       int currentStanding = CountStanding();

       if (currentStanding != lastStandingCount)
       {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
       }

       float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        ball.ResetBall();
        lastStandingCount = -1;
        ballEnteredBox = false;
        standingText.color = Color.green;
    }

    int CountStanding()
    {
        int standing = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding()){ standing++; }
        }
        return standing;
    }

    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding()) { pin.Raise(); }
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Instantiate(pinSet, new Vector3(0, 0, 1829f), Quaternion.identity);
    }

    void OnTriggerEnter(Collider col)
    {
        Ball ball = col.GetComponent<Ball>();
        if (ball)
        {
            ballEnteredBox = true;
            standingText.color = Color.red;
        }
    }

    void OnTriggerExit(Collider col)
    {
        Ball ball = col.GetComponent<Ball>();
        Pin pin = col.GetComponent<Pin>();
        if (ball)
        {
        }
        else if (pin)
        {
            Destroy(col.gameObject);
        }
    }
}
