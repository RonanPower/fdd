using UnityEngine;
using System.Collections;

public class FlashlightBattery : MonoBehaviour {
    // Torch light variable.
    public Light torchLight;
    // Counter for torch battery
    float torchBattery = 10.0f;

	// Use this for initializations
	void Start ()
    {
        StartCoroutine(batteryTimer());
	}

    public IEnumerator batteryTimer()
    {
        while (torchBattery > 0.0f)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("battery: " + torchBattery);
            torchBattery--;

            if (Input.GetKey("r"))
            {
                break;
            }
        }
        Debug.Log("The first While loop has completed.");
        while (torchBattery < 100.0f && Input.GetKey("r"))
        {
            yield return new WaitForSeconds(2);
            Debug.Log("battery: " + torchBattery);
            torchBattery++;

            if (Input.GetKeyUp("r"))
            {
                StartCoroutine(batteryTimer());
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        

        if (torchBattery <= 100.0f)
        {
            torchLight.intensity = 3.0f;
            torchLight.range = 20;
        }
        else if (torchBattery <= 80.0f)
        {
            torchLight.intensity = 0.8f;
            torchLight.range = 18;
        }
        else if (torchBattery <= 60.0f)
        {
            torchLight.intensity = 2.6f;
            torchLight.range = 16;
        }
        else if (torchBattery <= 40.0f)
        {
            torchLight.intensity = 2.0f;
            torchLight.range = 12;
        }
        else if (torchBattery <= 20.0f)
        {
            torchLight.intensity = 1.4f;
            torchLight.range = 8;
        }
        else if (torchBattery <= 10.0f)
        {
            torchLight.intensity = 0.8f;
            torchLight.range = 4;
        }
        else
        {
            torchLight.intensity = 0.0f;
            torchLight.range = 0;
        }
	}
}
