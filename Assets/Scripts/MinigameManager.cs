using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    // Attributes 
    private const float maxGoalHeight = 50.0f;
    private const float maxGoalWidth = 150.0f;
    private float ballInitialYPos = 25.0f;

    private float speed, xzAngle, yzAngle;
    private float pX, pY;
    private const float gravAcc = 9.81f;
    private float xzTime, yTime, xzVel, yInitialVel, yVel;
    private float xDisplacement, yDisplacement, zDisplacement;
    private float ballInGoalX;
    private float ballHitGoalieTime;
    private float beforeBounceYVel;
    private const float curveFactor = 10.0f;
    private Vector3 ballStartPos = new Vector3(maxGoalWidth / 2.0f, 25.0f, -300.0f);
    private Vector3 ballPos;

    private float coefficientOfRes = 0.6f;
    private float minYBounce = 1.5f;

    private bool ballMoving = false;
    private bool ballRolling = false;
    private bool kicked = false;
    private bool soundPlayed = false;
    private bool goalieJumped = false;
    private bool ballHitGoalie = false;

    private const float fastForwardSpeed = 3.0f;
    private const float goalieJumpTime = 2.0f;
    private float ballToGoalTimer = 0.0f;
    private float endTimer = 2.0f;
    private bool endTimerActive = false;

    private GameManager gm;
    private AudioManager am;
    private BTNManager btnm;
    private Goalie oppGoalie;

    public GameObject ball;
    public GameObject ballShadow;
    private GameObject goalieObject;

    private Vector3 ballShadowStartScale = new Vector3(0.88f, 0.2f, 1.0f);
    private Vector3 ballShadowStartPos = new Vector3(0.0f, -175.0f, 1.0f);
    private Vector3 canvasBallStartScale = new Vector3(1.0f, 1.0f, 1.0f);
    private Vector3 canvasBallStartPos = new Vector3(0.0f, -100.0f, 1.0f);
    private const float ballDiameter = 60.0f;
    private const float endScaleFactor = 0.1f;
    private const float scaleFactorGrad = 0.9f / 300.0f;

    private bool practice;
    private bool penalty = true;

    // REMOVE LATER
    private bool test = false;

    // Functions
    void Start()
    {
        am = this.gameObject.GetComponent<AudioManager>();
        gm = this.gameObject.GetComponent<GameManager>();
        btnm = this.gameObject.GetComponent<BTNManager>();
        ballPos = ballStartPos;

    }

    void Update()
    {
        if (ballMoving)
        {
            if (!kicked)
            {
                am.PlaySingle(am.kicking);
                kicked = true;
            }            
            
            oppGoalie.SetBallPos(ballPos);
            ballToGoalTimer -= Time.deltaTime * fastForwardSpeed;
            xzTime += Time.deltaTime * fastForwardSpeed;
            yTime += Time.deltaTime * fastForwardSpeed;
            //CalculateYVelocity();
            CalculateDisplacement();
            MoveBall();
            //Debug.Log("X: " + ballPos.x + ", Y: " + ballPos.y + ", Z: " + ballPos.z);

            if (ballPos.z >= 0.0f && !ballHitGoalie)
            {
                //Debug.Log("Actual ball pos: (" + ballPos.x + ", " + ballPos.y + ", " + ballPos.z + ")");
                //Debug.Log("Actual time to goal: " + xzTime);
                
                oppGoalie.SetPhase(0);
                endTimerActive = true;
                if (BallHitGoalie())
                {
                    am.PlaySingle(am.crowdGroaning);                //Works really well
                    ballHitGoalieTime = xzTime;
                    ballHitGoalie = true;
                    ballInGoalX = ballStartPos.x + (Mathf.Sin(xzAngle) * xzVel * ballHitGoalieTime) + (pX * curveFactor * Mathf.Pow(ballHitGoalieTime, 2.0f));
                    xzVel *= coefficientOfRes;
                }
                else
                {
                    ballMoving = false;
                    btnm.DisplayStillBall();
                }
            }

            if (!goalieJumped && ballToGoalTimer < goalieJumpTime / fastForwardSpeed)
            {
                goalieJumped = true;
                // TODO: FUNCTION CAUSES CRASH, FIX LATER
                //oppGoalie.SetBallInGoalPos(CalculateBallInGoalPos());
            }
        }
        if (endTimerActive)
        {
            if (IsGoalSuccessful())
            {
                if (!soundPlayed)
                {
                    am.PlaySingle(am.cheeringShort);
                    soundPlayed = true;
                    btnm.DisplayStillBall();
                    btnm.DisplayScorePopUp();
                }
            }
            else
            {
                if (!soundPlayed)
                {
                    am.PlaySingle(am.crowdGroaning);
                    soundPlayed = true;            
                }
            }
            endTimer -= Time.deltaTime;
            if (endTimer <= 0.0f)
            {
                if (!practice)
                {
                    btnm.DisplayMatch();
                    oppGoalie.SetActive(false);
                    gm.QTEEnded(IsGoalSuccessful());
                    soundPlayed = false;
                    kicked = false;
                }
                else
                {
                    btnm.ReplayQTEPractice();
                    soundPlayed = false;
                    kicked = false;
                }
                

                EndGame();
            }
        }
    }

    public void SetSpeed(float speed)
    {
        // REMOVE LATER
        if (test)
            speed = 70.0f;
        this.speed = (speed / 2.0f) + 20.0f;
    }

    public void SetXZAngle(float angle)
    {
        // REMOVE LATER
        if (test)
            angle = -15.0f;
        xzAngle = Mathf.Deg2Rad * angle * 2.0f;
    }

    public void SetPX(float pX)
    {
        // REMOVE LATER
        if (test)
            pX = 40.0f;
        pX = (pX - 50.0f) / 50.0f;
        this.pX = -pX;
    }

    public void SetPY(float pY)
    {
        // REMOVE LATER
        if (test)
            pY = 30.0f;
        pY = (pY - 50.0f) / 50.0f;
        this.pY = -pY;
        CalculateYZAngle();
    }

    private void CalculateYZAngle()
    {
        yzAngle = Mathf.Deg2Rad * ((pY * 25.0f) + 35.0f);
    }

    private void CalculateInitialVelocities()
    {
        xzVel = speed * Mathf.Cos(yzAngle);
        yInitialVel = speed * Mathf.Sin(yzAngle);

        yVel = beforeBounceYVel = yInitialVel;
    }

    private void CalculateYVelocity()
    {
        yVel = yInitialVel - (gravAcc * yTime);
    }

    private void CalculateDisplacement()
    {
        if (!ballRolling || true)
        {
            if (!endTimerActive)
                if (xzAngle != 0)
                {
                    xDisplacement = ballStartPos.x + (Mathf.Sin(xzAngle) * xzVel * xzTime) + (pX * curveFactor * Mathf.Pow(xzTime, 2.0f));
                    zDisplacement = ballStartPos.z + (Mathf.Cos(xzAngle) * xzVel * xzTime);
                    //xDisplacement = ballPos.x + (Mathf.Sin(xzAngle) * xzVel * Time.deltaTime) + (pX * curveFactor * Mathf.Pow(Time.deltaTime, 2.0f));
                    //zDisplacement = ballPos.z + (Mathf.Cos(xzAngle) * xzVel * Time.deltaTime);
                }
                else
                {
                    xDisplacement = ballStartPos.x + (pX * curveFactor * Mathf.Pow(xzTime, 2.0f));
                    zDisplacement = ballStartPos.z + (xzVel * xzTime);
                    //xDisplacement = ballPos.x + (pX * curveFactor * Mathf.Pow(Time.deltaTime, 2.0f));
                    //zDisplacement = ballPos.z + (xzVel * Time.deltaTime);
                }
            else
            {
                if (xzAngle != 0)
                {
                    xDisplacement = ballInGoalX - (Mathf.Sin(xzAngle) * xzVel * (xzTime - ballHitGoalieTime));
                    zDisplacement = Mathf.Cos(xzAngle) * -xzVel * (xzTime - ballHitGoalieTime);
                    //xDisplacement = ballPos.x - (Mathf.Sin(xzAngle) * xzVel * Time.deltaTime);
                    //zDisplacement = ballPos.z + (Mathf.Cos(xzAngle) * -xzVel * Time.deltaTime);
                }
                else
                {
                    xDisplacement = ballInGoalX;
                    zDisplacement = -xzVel * (xzTime - ballHitGoalieTime);
                    //xDisplacement = ballPos.x;
                    //zDisplacement = ballPos.z + (-xzVel * Time.deltaTime);
                }
            }

            yDisplacement = (yVel * yTime) - (0.5f * gravAcc * Mathf.Pow(yTime, 2.0f)) + ballInitialYPos;
            if (yDisplacement < 0.0f)
            {
                CalculateYVelocity();
                yVel = yInitialVel = Mathf.Abs(yVel) * coefficientOfRes;

                yTime = 0.0f;
                ballInitialYPos = 0.0f;
                //CalculateYVelocity();
                yDisplacement = (yVel * yTime) - (0.5f * gravAcc * Mathf.Pow(yTime, 2.0f));

                if (CalcMaxYDisplacement() < minYBounce)
                {
                    ballRolling = true;
                    yDisplacement = 0.0f;
                }
            }
        }

        ballPos = new Vector3(xDisplacement, yDisplacement, zDisplacement);
    }

    private float CalcMaxYDisplacement()
    {
        float yTimeAtMax = yInitialVel / gravAcc;

        return (yVel * yTimeAtMax) - (0.5f * gravAcc * Mathf.Pow(yTimeAtMax, 2.0f));
    }

    public void MoveBall()
    {
        float zScaleFactor = (Mathf.Abs(ballPos.z) * scaleFactorGrad) + endScaleFactor;
        float ballShadowXScale = ballShadowStartScale.x * zScaleFactor;
        float ballShadowYScale = ballShadowStartScale.y * zScaleFactor;
        float ballShadowYPos = ballShadowStartPos.y + ballPos.z - ballStartPos.z;

        ballShadow.transform.localScale = new Vector3(ballShadowXScale, ballShadowYScale, 1.0f);
        ball.transform.localScale = new Vector3(zScaleFactor, zScaleFactor, zScaleFactor);
        ballShadow.transform.localPosition = new Vector3(ballPos.x - 75.0f, ballShadowYPos, 1.0f);
        ball.transform.localPosition = new Vector3(ballPos.x - 75.0f, ballShadowYPos + ballPos.y + (ballShadowXScale * 50.0f) - (25.0f * ballShadowYScale), 1.0f);
    }

    private bool IsGoalSuccessful()
    {
        return !ballHitGoalie && (ballPos.x > 0.0f && ballPos.y >= 0.0f && ballPos.x < maxGoalWidth && ballPos.y < maxGoalHeight);
    }

    public void BeginMoveBall()
    {
        CalculateInitialVelocities();
        ballToGoalTimer = CalculateBallTimeToGoal();
        ballMoving = true;
        oppGoalie.SetPhase(2);
        btnm.DisplayBallSpriteMove();

    }

    private void ResetBall()
    {
        ballShadow.transform.localScale = ballShadowStartScale;
        ballShadow.transform.localPosition = ballShadowStartPos;
        ball.transform.localScale = canvasBallStartScale;
        ball.transform.localPosition = canvasBallStartPos;
        xzTime = 0.0f;
        yTime = 0.0f;
        MoveBall();
    }

    public void ActivateGoalie()
    {
        oppGoalie = gm.GetOppGoalie();

        if (!oppGoalie.isSetUp())
        {
            practice = true;
            oppGoalie = new Goalie();
            oppGoalie.StartSetup();
            oppGoalie.SetUpPracticeStats();
        }
        else
            practice = false;

        goalieObject = GameObject.FindGameObjectWithTag("Goalie");
        goalieObject.AddComponent(oppGoalie.GetType());
        oppGoalie = goalieObject.GetComponent<Goalie>();
        oppGoalie.FindGameObject();
        oppGoalie.Reset();
        oppGoalie.SetPhase(1);
        oppGoalie.SetActive(true);
    }

    private float CalculateBallTimeToGoal()
    {
        return -ballStartPos.z / (Mathf.Cos(xzAngle) * xzVel);
    }

    private Vector2 CalculateBallInGoalPos()
    {
        float endTime = CalculateBallTimeToGoal();
        float xValue = ballStartPos.x - (ballStartPos.z * Mathf.Tan(xzAngle)) + (pX * curveFactor * Mathf.Pow(endTime, 2.0f));
        float yValue;
        float yVel = beforeBounceYVel / coefficientOfRes;
        float yTime = 0.0f;
        float ballYStartPos = 25.0f;
        float prevYTime;
        float timeDifference = 0.0f;
        int counter = 0;

        do {
            counter++;
            yVel = Mathf.Abs(yVel - (gravAcc * timeDifference)) * coefficientOfRes;
            //Debug.Log("Y Initial Velocity: " + yVel + ", Time Difference: " + timeDifference + ", Counter: " + counter);
            prevYTime = yTime;
            yTime += ((2.0f * yVel) + Mathf.Sqrt(Mathf.Pow((2.0f * yVel), 2.0f) + (8.0f * gravAcc * ballYStartPos))) / (2.0f * gravAcc);
            ballYStartPos = 0.0f;
            timeDifference = yTime - prevYTime;
        } while (endTime > yTime);

        //Debug.Log("PrevYTime: " + prevYTime + ", EndTime: " + endTime + ", YTime: " + yTime + ", YVel: " + yVel);

        if (counter < 2)
            yValue = ballInitialYPos + (yVel * (endTime - prevYTime)) - (0.5f * gravAcc * Mathf.Pow((endTime - prevYTime), 2.0f));
        else
            yValue = (yVel * (endTime - prevYTime)) - (0.5f * gravAcc * Mathf.Pow((endTime - prevYTime), 2.0f));

        return new Vector2(xValue, yValue);
    }

    private bool BallHitGoalie()
    {
        Vector3 goaliePos = oppGoalie.Get3DPosition();
        Vector2 goalieSize = oppGoalie.GetSize();
        float ballRadius = (ballDiameter / 2.0f) * ((Mathf.Abs(ballPos.z) * scaleFactorGrad) + endScaleFactor);

        //Debug.Log("Goalie X: " + goaliePos.x + ", Goalie Y: " + goaliePos.y);
        //Debug.Log("Goalie Right: " + (goaliePos.x + (goalieSize.x / 2.0f)) + ", Goalie Left: " + (goaliePos.x - (goalieSize.x / 2.0f)) +
                  //", Goalie Up: " + (goaliePos.y + (goalieSize.y / 2.0f)) + ", Goalie Down: " + (goaliePos.y - (goalieSize.y / 2.0f)));
        //Debug.Log("Ball X: " + ballPos.x + ", Ball Y: " + ballPos.y);
        //Debug.Log("Ball Right: " + (ballPos.x + ballRadius) + ", Ball Left: " + (ballPos.x - ballRadius) +
                  //", Ball Up: " + (ballPos.y + ballRadius) + ", Ball Down: " + (ballPos.y - ballRadius));

        return ballPos.x - ballRadius < goaliePos.x + (goalieSize.x / 2.0f) && 
               ballPos.x + ballRadius > goaliePos.x - (goalieSize.x / 2.0f) &&
               ballPos.y - ballRadius < goaliePos.y + (goalieSize.y / 2.0f) && 
               ballPos.y + ballRadius > goaliePos.y - (goalieSize.y / 2.0f);
    }

    public void EndGame()
    {
        ballPos = ballStartPos;
        ballMoving = false;
        ballRolling = false;
        endTimer = 2.0f;
        endTimerActive = false;
        goalieJumped = false;
        ballHitGoalie = false;
        ResetBall();
        oppGoalie.Reset();
        btnm.HideScorePopUp();
    }

    public void SetPenalty(bool penalty)
    {
        this.penalty = penalty;
    }
}
