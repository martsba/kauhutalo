using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;


public enum SceneState
{
    alku,
    talossa,
    avain,
    ulos
}

public class Lightmanager : MonoBehaviour
{
    static public Lightmanager Instance;
    public SceneState sceneState;

    public float lightIntensityAlku;
    public Color colorAlku;
    public float lightIntensityTalossa;
    public Color colorTalossa;
    public float lightIntensityUlos;
    public Color colorUlos;
    public List<Light> dynamicLights;
    public List<GameObject> oviLaudat;
    public GameObject avain;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(sceneState);
    }

    private void Update()
    {
       
    }

    public void ChangeState(SceneState setState)
    {
        sceneState = setState;

        foreach (Light valo in dynamicLights)
        {
            if (sceneState == SceneState.talossa)
            {
                valo.intensity = lightIntensityTalossa;
                valo.color = colorTalossa;
            }
            else if (sceneState == SceneState.alku)
            {
                valo.intensity = lightIntensityAlku;
                valo.color = colorAlku;
            }
            else if (sceneState == SceneState.ulos)
            {
                valo.intensity = lightIntensityUlos;
                valo.color = colorUlos;
            }
        }

        foreach (GameObject lauta in oviLaudat)
        {
            if (sceneState == SceneState.alku)
            {
                lauta.SetActive(false);
            }
            else if (sceneState == SceneState.talossa)
            {
                lauta.SetActive(true);
            }
            else if (sceneState == SceneState.avain)
            {
                lauta.SetActive(true);
            }
            else if (sceneState == SceneState.ulos)
            {
                lauta.SetActive(false);
            }
        }

        if (sceneState == SceneState.avain)
        {
            avain.SetActive(true);
        }
        else
        {
            avain.SetActive(false);
        }
    }
}
