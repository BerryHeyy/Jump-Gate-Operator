using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class JumpgateController : MonoBehaviour
{

    public float yaw, pitch;
    public float yawDeviation, pitchDeviation;
    public float jumpFailedTimer = 2f;
    public GameObject jumpFailedAlert;

    public GameObject beam1;
    public GameObject beam2;
    public Image tractorBeamButton;

    bool aligning;
    bool showingJumpAlert;

    Jumpgate jumpgate;
    Transform gameSpace;

    float increase = 10f;
    float deviation = 0.05f;

    void Start()
    {
        jumpgate = gameObject.GetComponent<Jumpgate>();
        gameSpace = GameObject.Find("GameSpace").transform;
        showingJumpAlert = false;

        
    }

    void Update()
    {

        if (jumpgate.HasShip())
        {

            if (aligning)
            {
                Align();
            }

            if (showingJumpAlert)
            {
                jumpFailedTimer -= Time.smoothDeltaTime;

                if (jumpFailedTimer >= 0) jumpFailedAlert.SetActive(true);
                else
                {
                    jumpFailedAlert.SetActive(false);
                    jumpFailedTimer = 2f;
                    showingJumpAlert = false;
                }


            }

            if (jumpgate.ship.locked)
            {
                beam1.SetActive(true);
                beam2.SetActive(true);
                beam1.GetComponent<LineRenderer>().SetPosition(0, beam1.transform.position);
                beam1.GetComponent<LineRenderer>().SetPosition(1, GameObject.Find("Ship").transform.position);

                beam2.GetComponent<LineRenderer>().SetPosition(0, beam2.transform.position);
                beam2.GetComponent<LineRenderer>().SetPosition(1, GameObject.Find("Ship").transform.position);

                tractorBeamButton.color = new Vector4(0f, 0.7386749f, 1f, 1f);
            }
            else
            {
                beam1.SetActive(false);
                beam2.SetActive(false);

                tractorBeamButton.color = Color.white;
            }

            updateValues();
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
        if (jumpgate.CanJump()) GameObject.Find("EventManager").GetComponent<EventManager>().InvokeOnJump();
        else showingJumpAlert = true;
    }

    public void Align()
    {
        if (yawDeviation == 0 && pitchDeviation == 0) { aligning = false; return; }

        if (yawDeviation > 0)
        {
            yaw -= deviation;
            yawDeviation -= deviation;
            gameSpace.Rotate(new Vector3(0f, -deviation, 0f));
            if (yawDeviation < 0) yawDeviation = 0f;
        }
        else if (yawDeviation < 0)
        {
            yaw += deviation;
            yawDeviation += deviation;
            gameSpace.Rotate(new Vector3(0f, deviation, 0f));
            if (yawDeviation > 0) yawDeviation = 0f;
        }

        if (pitchDeviation > 0)
        {
            pitch -= deviation;
            pitchDeviation -= deviation;
            gameSpace.Rotate(new Vector3(-deviation, 0f, 0f));
            if (pitchDeviation < 0) pitchDeviation = 0f;
        }
        else if (pitchDeviation < 0f)
        {
            pitch += deviation;
            pitchDeviation += deviation;
            gameSpace.Rotate(new Vector3(deviation, 0f, 0f));
            if (pitchDeviation > 0) pitchDeviation = 0f;
        }

    }

    public void onAlignButton()
    {
        if (jumpgate.ship.locked) aligning = true;
    }

    public void onDeviationButtonRight()
    {
        yawDeviation += increase;
    }
    public void onDeviationButtonLeft()
    {
        yawDeviation -= increase;
    }
    public void onDeviationButtonUp()
    {
        pitchDeviation += increase;
    }
    public void onDeviationButtonDown()
    {
        pitchDeviation -= increase;
    }

    // Display Values

    public TextMeshProUGUI yawDeviationValue;
    public TextMeshProUGUI pitchDeviationValue;
    

    void updateValues()
    {
        yawDeviationValue.SetText((int) yawDeviation + "°");
        pitchDeviationValue.SetText((int) pitchDeviation + "°");
    }

}
