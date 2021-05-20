using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputKey))]
public class Kontrol : MonoBehaviour
{
    public InputKey masukkan;
    public List<WheelCollider> rodaPenggerak;
    public List<GameObject> rodaStir;
    public List<GameObject> rodaPutar;
    public GameObject stir;
    public Rigidbody rb;
    public Text gear;
    public float torsi=0f;
    private bool mundur = false;
    private bool maju = true;
    private float gerigi = 0f;
    private float speedMultiply;

    // Start is called before the first frame update
    void Start()
    {
        masukkan = GetComponent<InputKey>();
        gear.text = "N";
    }

    // Update is called once per frame
    void Update()
    {
  
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {

                foreach (WheelCollider roda in rodaPenggerak)
                {
                    roda.motorTorque = 0f;
                    roda.brakeTorque = 40000f;
                }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {   
            foreach (WheelCollider roda in rodaPenggerak)
            {
                roda.brakeTorque = 0f;
                roda.motorTorque = (torsi * Time.deltaTime) * 10;
            }
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            foreach (WheelCollider roda in rodaPenggerak)
            {
                roda.brakeTorque = 0f;
                roda.motorTorque = (torsi * Time.deltaTime * -1) * 10;
            }
        }

        foreach (GameObject roda in rodaStir)
        {
            roda.GetComponent<WheelCollider>().steerAngle = 45f * masukkan.stir;
            roda.transform.localEulerAngles = new Vector3(0f, masukkan.stir * 45f, 0f);   
        }

        stir.transform.localEulerAngles = new Vector3(masukkan.stir * -5f, 180f + (masukkan.stir * 15f), masukkan.stir * 90f);

        foreach (GameObject putar in rodaPutar)
        {
            putar.transform.Rotate(0f, 0f, rb.velocity.magnitude * (transform.InverseTransformDirection(rb.velocity).z >= 0 ? 1 : -1) / (0.5f * Mathf.PI * 0.33f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "power")
        {
            foreach (WheelCollider roda in rodaPenggerak)
            {
                roda.motorTorque = 10000;
            }
        }
    }

}
