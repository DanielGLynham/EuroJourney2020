using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Attributes
    private Vector3 velocity;
    private float distanceFromNet;
    private bool inNet;
    private int phase;

    // Functions
    void Start()
    {
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
        distanceFromNet = 50.0f;
        inNet = false;
        phase = 0;
    }

    void Update()
    {
        
    }

    public bool GetInNet()
    {
        return inNet;
    }
    public int GetPhase()
    {
        return phase;
    }
    public void PerformQTE()
    {

    }

    private void CalculateTrajectory()
    {

    }
}
