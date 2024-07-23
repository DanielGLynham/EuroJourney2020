using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Camera camera;
    private Transform transform;
    private int movementPhase;
    private struct CameraVals
    {
        public Vector3 position;
        public Vector3 rotation;
        public float size;
    }

    private const int maxCameraVals = 6;
    private CameraVals[] cameras = new CameraVals[maxCameraVals];
    private float maxAnimationTimer;
    private float animationTimer;
    private float minMomentumScale;
    private float momentumScale;
    private bool animateCamera = false;

    // Quadratic Equation Components
    float a, b, c;

    // Camera Movement Values
    float prevCamXPos, nextCamXPos;
    float prevCamYPos, nextCamYPos;
    float prevCamZPos, nextCamZPos;
    float prevCamXRot, nextCamXRot;
    float prevCamYRot, nextCamYRot;
    float prevCamSize, nextCamSize;

    private void Start()
    {
        camera = this.gameObject.GetComponent<Camera>();
        transform = this.gameObject.GetComponent<Transform>();
        SetupCameras();
        SetCameraValues(0);
        SetMovemementPhase(0);
    }

    private void Update()
    {
        if (animateCamera)
        {
            if (animationTimer == 0.0f)
                animateCamera = false;
            else
                animationTimer -= Time.deltaTime * momentumScale;

            MoveCamera();

            momentumScale = CalcMomentumScale();

            if (animationTimer < 0.0f)
                animationTimer = 0.0f;
        }
    }

    private void MoveCamera()
    {
        float xPos = nextCamXPos + (animationTimer * ((prevCamXPos - nextCamXPos) / maxAnimationTimer));
        float yPos = nextCamYPos + (animationTimer * ((prevCamYPos - nextCamYPos) / maxAnimationTimer));
        float zPos = nextCamZPos + (animationTimer * ((prevCamZPos - nextCamZPos) / maxAnimationTimer));
        float xRot = nextCamXRot + (animationTimer * ((prevCamXRot - nextCamXRot) / maxAnimationTimer));
        float yRot = nextCamYRot + (animationTimer * ((prevCamYRot - nextCamYRot) / maxAnimationTimer));
        float size = nextCamSize + (animationTimer * ((prevCamSize - nextCamSize) / maxAnimationTimer));

        transform.position = new Vector3(xPos, yPos, zPos);
        transform.rotation = Quaternion.Euler(xRot, yRot, transform.rotation.z);
        camera.orthographicSize = size;
    }

    private float CalcMomentumScale()
    {
        return (a * Mathf.Pow(animationTimer, 2.0f)) + (b * animationTimer) + c;
    }

    private void SetupCameras()
    {
        // Start Position
        cameras[0].position = new Vector3(0.5f, 4.2f, 86.5f);
        cameras[0].rotation = new Vector3(48.3f, 0.3f, 0.0f);
        cameras[0].size = 6.0f;

        // Main Menu
        cameras[1].position = new Vector3(0.5f, -1.75f, 84.0f);
        cameras[1].rotation = new Vector3(1.5f, 0.3f, 0.0f);
        cameras[1].size = 3.0f;

        // Start Game Screen
        cameras[2].position = new Vector3(0.32f, -1.75f, 84.0f);
        cameras[2].rotation = new Vector3(1.4f, -18.5f, 0.0f);
        cameras[2].size = 4.8f;

        // Options Screen
        cameras[3].position = new Vector3(3.65f, -1.75f, 84.0f);
        cameras[3].rotation = new Vector3(1.5f, 0.3f, 0.0f);
        cameras[3].size = 2.15f;

        // Practice Screen
        cameras[4].position = new Vector3(0.5f, -2.92f, 84.0f);
        cameras[4].rotation = new Vector3(-5.5f, 0.3f, 0.0f);
        cameras[4].size = 12.5f;

        // Main Game
        cameras[5].position = new Vector3(0.04f, 0.73f, -10.44f);
        cameras[5].rotation = new Vector3(1.45f, 0.28f, 0.0f);
        cameras[5].size = 3.0f;
    }

    public void SetCameraValues(int arrayPos)
    {
        transform.position = cameras[arrayPos].position;
        transform.rotation = Quaternion.Euler(cameras[arrayPos].rotation);
        camera.orthographicSize = cameras[arrayPos].size;
    }

    public void SetMovemementPhase(int movementPhase)
    {
        this.movementPhase = movementPhase;

        SetUpMovementValues(movementPhase);
    }

    private void SetUpMovementValues(int phase)
    {
        CameraVals prevCam = cameras[0], nextCam = cameras[0];
        switch (phase)
        {
            case 0:     // Start Swoop-In
                minMomentumScale = 0.3f;
                maxAnimationTimer = 1.0f;
                animateCamera = true;
                prevCam = cameras[0];
                nextCam = cameras[1];
                break;
            case 1:     // Main to Start
                minMomentumScale = 0.5f;
                maxAnimationTimer = 1.5f;
                animateCamera = true;
                prevCam = cameras[1];
                nextCam = cameras[2];
                break;
            case 2:     // Main to Options
                minMomentumScale = 0.5f;
                maxAnimationTimer = 1.0f;
                animateCamera = true;
                prevCam = cameras[1];
                nextCam = cameras[3];
                break;
            case 3:     // Main to Practice
                minMomentumScale = 0.5f;
                maxAnimationTimer = 1.0f;
                animateCamera = true;
                prevCam = cameras[1];
                nextCam = cameras[4];
                break;
            case 4:     // Start to Main
                minMomentumScale = 0.5f;
                maxAnimationTimer = 1.0f;
                animateCamera = true;
                prevCam = cameras[2];
                nextCam = cameras[1];
                break;
            case 5:     // Options to Main
                minMomentumScale = 0.5f;
                maxAnimationTimer = 1.0f;
                animateCamera = true;
                prevCam = cameras[3];
                nextCam = cameras[1];
                break;
            default:        // Nothing
                minMomentumScale = 0.0f;
                maxAnimationTimer = 0.0f;
                animateCamera = false;
                break;
        }

        prevCamXPos = prevCam.position.x;
        prevCamYPos = prevCam.position.y;
        prevCamZPos = prevCam.position.z;
        prevCamXRot = prevCam.rotation.x;
        prevCamYRot = prevCam.rotation.y;
        prevCamSize = prevCam.size;

        nextCamXPos = nextCam.position.x;
        nextCamYPos = nextCam.position.y;
        nextCamZPos = nextCam.position.z;
        nextCamXRot = nextCam.rotation.x;
        nextCamYRot = nextCam.rotation.y;
        nextCamSize = nextCam.size;

        CalculateQuadratic();

        animationTimer = maxAnimationTimer;
        momentumScale = minMomentumScale;
    }

    private void CalculateQuadratic()
    {
        a = ((4.0f * minMomentumScale) - 4.0f) / Mathf.Pow(maxAnimationTimer, 2.0f);
        b = (4.0f - (4.0f * minMomentumScale)) / maxAnimationTimer;
        c = minMomentumScale;
    }

    public bool IsAnimateCamera()
    {
        return animateCamera;
    }
}
