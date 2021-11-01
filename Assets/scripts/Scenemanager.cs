using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum SceneState
{
    alku,
    talossa,
    avain,
    ulos
}

public class Scenemanager : MonoBehaviour
{
    static public Scenemanager Instance;
    public SceneState sceneState;

    public float lightIntensityAlku;
    public Color colorAlku;
    public float lightIntensityTalossa;
    public Color colorTalossa;
    public float lightIntensityUlos;
    public Color colorUlos;
    public List<Light> dynamicLights;
    public List<GameObject> oviLaudat;
    public GameObject avainkuva;
    public GameObject avain;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(sceneState); //alku, talossa, ulos yms
        aktiivinenScene = SceneManager.GetActiveScene().name;
        muutaScene = aktiivinenScene;
    }

    string aktiivinenScene;
    string muutaScene;

    private void Update()
    {
       if (muutaScene != aktiivinenScene)
        {
            if (SceneManager.GetActiveScene().name == muutaScene) //EI TOIMI, skene latautuu mutta ei vaihdu eik‰ tee mit‰‰n t‰st‰ eteenp‰in
            {
                Debug.Log("skene on latautunut");
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(muutaScene));
                aktiivinenScene = muutaScene;
                //muutaScene = aktiivinenScene;
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        Debug.Log("nappi painettu");
        SceneManager.LoadScene(sceneName,LoadSceneMode.Additive);
        muutaScene = sceneName;
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
            avainkuva.SetActive(true);
            avain.SetActive(false);
        }
        else
        {
            avainkuva.SetActive(false);
        }
    }
}
