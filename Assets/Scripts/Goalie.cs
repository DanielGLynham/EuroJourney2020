using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalie : Player
{
    // Attributes
    private Vector3 velocity;
    private Vector3 position;
    private Vector3 startingPos = new Vector3(0.0f, 142.0f, 0.0f);
    private Vector3 ballPos = new Vector3(75.0f, 25.0f, -300.0f);
    private Vector2 ballInGoalPos;

    private const float xMax = 70.0f;

    private const float maxWalkSpeed = 10.0f;   // 10.0f;
    private float walkSpeedScale = 1.0f;
    private float walkSpeed = maxWalkSpeed;

    private int phase = 0;
    private bool jumping;
    private bool active;
    private bool jumpCheck = true;
    private bool setUp = false;

    private GameObject goalie;

    private Vector2 goalieSize = new Vector2(17.0f, 42.0f);

    // Functions
    void Start()
    {
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
        position = startingPos;
        jumping = false;
    }

    void Update()
    {
        if (active)
            switch (phase)
            {
                case 0:     // Inactive
                    break;
                case 1:     // Non-penalty kick before ball is kicked
                    Move();
                    break;
                case 2:     // Non-penalty kick. Ball is moving, not close to goal
                    if (ballPos.z > -100.0f && jumpCheck)
                    {
                        if (CheckIfJumpForBall())
                            phase = 3;
                        jumpCheck = false;
                    }
                    if (ballPos.x > position.x)
                        walkSpeed = maxWalkSpeed;
                    else if (ballPos.x < position.x)
                        walkSpeed = -maxWalkSpeed;
                    else
                        walkSpeed = 0.0f;
                    Move();
                    break;
                case 3:     // Non-penalty kick. Ball is close to goal
                    break;
                case 4:     // Penalty kick when ball is moving
                    break;
            }
    }

    public int GetPhase()
    {
        return phase;
    }

    private bool CheckIfJumpForBall()
    {

        return false;
    }

    public void Move()
    {
        if (phase == 1)
        {
            if (position.x > xMax - 20.0f && walkSpeed > 0.0f || position.x < -xMax + 20.0f && walkSpeed < 0.0f)
                walkSpeed *= -1.0f;
        }
        else
            if (position.x > xMax && walkSpeed > 0.0f || position.x < -xMax && walkSpeed < 0.0f)
                walkSpeed *= -1.0f;
        position.x += walkSpeed * walkSpeedScale * Time.deltaTime;
        goalie.transform.localPosition = new Vector3(position.x, startingPos.y, 0.0f);
    }
    
    private void JumpForBall()
    {

    }

    public void SetBallPos(Vector3 ballPos)
    {
        this.ballPos = ballPos;
        this.ballPos.x -= 75.0f;
    }

    public void FindGameObject()
    {
        goalie = GameObject.FindGameObjectWithTag("Goalie");
    }

    public bool IsActive()
    {
        return active;
    }

    public void SetActive(bool active)
    {
        this.active = active;
    }

    public void SetPhase(int phase)
    {
        this.phase = phase;
        switch (phase)
        {
            case 1:
                walkSpeedScale = 2.0f;
                break;
            case 2:
                walkSpeedScale = 3.0f;
                break;
        }
    }

    public void SetBallInGoalPos(Vector2 ballInGoalPos)
    {
        this.ballInGoalPos = ballInGoalPos;
        //Debug.Log("Goalie Calc Pos: (" + ballInGoalPos.x + ", " + ballInGoalPos.y + ")");
    }

    public Vector3 Get3DPosition()
    {
        return position - startingPos + new Vector3(75.0f, goalieSize.y / 2.0f, 0.0f);
    }

    public Vector2 GetSize()
    {
        return goalieSize;
    }

    public void Reset()
    {
        goalie.transform.localPosition = startingPos;
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
        position = startingPos;
        jumping = false;
        phase = 0;
    }

    public override void StartSetup()
    {
        base.StartSetup();
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
        position = startingPos;
        jumping = false;
        setUp = true;
        phase = 0;
    }

    public bool isSetUp()
    {
        return setUp;
    }

    public void SetSetUp(bool setUp)
    {
        this.setUp = setUp;
    }
}
