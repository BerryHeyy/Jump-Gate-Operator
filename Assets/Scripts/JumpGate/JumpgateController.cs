using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class JumpgateController : MonoBehaviour
{

    public float increase = 10f;
    public float deviation = 0.05f;

    public float Yaw { get; private set; }
    public float Pitch { get; private set; }
    public float YawDeviation { get; private set; }
    public float PitchDeviation { get; private set; }
    public float JumpFailedTimer { get; private set; }
    public GameObject jumpFailedAlert;

    public GameObject beam1;
    public GameObject beam2;
    public Image tractorBeamButton;

    bool aligning;
    bool showingJumpAlert;

    JumpgateHandler jumpgate;
    CameraController cameraController;


    void Start()
    {
        jumpgate = gameObject.GetComponent<JumpgateHandler>();
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
        showingJumpAlert = false;

        
    }

    void Update()
    {

        if (jumpgate.HasShip())
        {

            if (CanAlign())
            {
                Align();
            }

            if (showingJumpAlert)
            {
                JumpFailedTimer -= Time.smoothDeltaTime;

                if (JumpFailedTimer >= 0) jumpFailedAlert.SetActive(true);
                else
                {
                    jumpFailedAlert.SetActive(false);
                    JumpFailedTimer = 2f;
                    showingJumpAlert = false;
                }


            }

            if (jumpgate.ship.locked)
            {
                ActivateTractorBeams();
            }
            else
            {
                DeactivateTractorBeams();
            }

            updateValues();
        }
    }

    public void ActivateTractorBeams()
    {
        beam1.SetActive(true);
        beam2.SetActive(true);
        beam1.GetComponent<LineRenderer>().SetPosition(0, beam1.transform.position);
        beam1.GetComponent<LineRenderer>().SetPosition(1, GameObject.Find("Ship").transform.position);

        beam2.GetComponent<LineRenderer>().SetPosition(0, beam2.transform.position);
        beam2.GetComponent<LineRenderer>().SetPosition(1, GameObject.Find("Ship").transform.position);

        tractorBeamButton.color = new Vector4(0f, 0.7386749f, 1f, 1f);
    }

    public void DeactivateTractorBeams()
    {
        beam1.SetActive(false);
        beam2.SetActive(false);

        tractorBeamButton.color = Color.white;
    }

    public bool CanAlign()
    {
        if (!jumpgate.Active) return false;
        if (!aligning) return false;
        return true;
    }

    public void Align()
    {
        if (YawDeviation == 0 && PitchDeviation == 0) { aligning = false; return; }

        if (YawDeviation > 0)
        {
            Yaw -= deviation;
            YawDeviation -= deviation;
            cameraController.ChangeSkyboxRotation(0f, -deviation, 0f);
            //toRotate.Rotate(new Vector3(0f, -deviation, 0f));
            if (YawDeviation < 0) YawDeviation = 0f;
        }
        else if (YawDeviation < 0)
        {
            Yaw += deviation;
            YawDeviation += deviation;
            cameraController.ChangeSkyboxRotation(0f, deviation, 0f);
            //toRotate.Rotate(new Vector3(0f, deviation, 0f));
            if (YawDeviation > 0) YawDeviation = 0f;
        }

        if (PitchDeviation > 0)
        {
            Pitch -= deviation;
            PitchDeviation -= deviation;
            cameraController.ChangeSkyboxRotation(-deviation, 0f, 0f);
            //toRotate.Rotate(new Vector3(-deviation, 0f, 0f));
            if (PitchDeviation < 0) PitchDeviation = 0f;
        }
        else if (PitchDeviation < 0f)
        {
            Pitch += deviation;
            PitchDeviation += deviation;
            cameraController.ChangeSkyboxRotation(deviation, 0f, 0f);
            //toRotate.Rotate(new Vector3(deviation, 0f, 0f));
            if (PitchDeviation > 0) PitchDeviation = 0f;
        }

    }

    public void onTractorBeamButton()
    {
        if (jumpgate.HasShip() && !aligning)
        {
            if (jumpgate.ship.locked) jumpgate.ship.locked = false;
            else jumpgate.ship.locked = true;
        }
    }

    public void onJumpButton()
    {
        if (jumpgate.CanJump())
        {
            jumpgate.ship.GetComponent<Animator>().Play("ShipJumpAnimation");
            GetComponent<JumpgateAnimation>().JumpInProgress = true;
        }
        else showingJumpAlert = true;
    }

    public void onAlignButton()
    {
        if (jumpgate.ship.locked && jumpgate.Active) aligning = true;
    }

    public void onDeviationButtonRight()
    {
        YawDeviation += increase;
    }
    public void onDeviationButtonLeft()
    {
        YawDeviation -= increase;
    }
    public void onDeviationButtonUp()
    {
        PitchDeviation += increase;
    }
    public void onDeviationButtonDown()
    {
        PitchDeviation -= increase;
    }

    // Display Values

    public TextMeshProUGUI YawDeviationValue;
    public TextMeshProUGUI PitchDeviationValue;
    

    void updateValues()
    {
        YawDeviationValue.SetText((int) YawDeviation + "°");
        PitchDeviationValue.SetText((int) PitchDeviation + "°");
    }

}
