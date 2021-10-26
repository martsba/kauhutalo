using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightmanager : MonoBehaviour
{
    public float lightIntensityOff;
    public float lightIntensityOn;
    public bool lightsOn;
    public Light dynamicLight;
    public float fLuku = 0;

    // Start is called before the first frame update
    void Start()
    {
        LightsOnOff();
    }

    private void Update()
    {
        if (fLuku != 100)
        {
            fLuku = fLuku +1;
            if (fLuku == 100)
            {
                Debug.Log(fLuku);
            }
        }
    }

    public void LightsOnOff()
    {
        if (lightsOn == true)
        {
            lightsOn = false;
            dynamicLight.intensity = lightIntensityOff;
        }
        else
        {
            lightsOn = true;
            dynamicLight.intensity = lightIntensityOn;
        }
    }

    public void SetLightIntensity()
    {
        
    }
}
