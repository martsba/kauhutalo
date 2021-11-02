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
    private void OnEnable()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(sceneState); //alku, talossa, ulos yms
        Debug.Log("start");
    }

    static string aktiivinenScene = "kauhutalo";
    static string muutaScene = "kauhutalo";

    private void Update()
    {
       if (muutaScene != aktiivinenScene)
        {
            Debug.Log("MuutaSecene: "+ muutaScene + " / AktiivinenScene: "+ aktiivinenScene);
            Debug.Log("Is scene '" + SceneManager.GetSceneByName(muutaScene).name + " loaded: "+ SceneManager.GetSceneByName(muutaScene).isLoaded);

            if (SceneManager.GetSceneByName(muutaScene).isLoaded)
            {
                Debug.Log("skene on latautunut");
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(muutaScene));
                aktiivinenScene = muutaScene;
                ShowSceneObjects();
                this.gameObject.SetActive(false);
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        Debug.Log("nappi painettu, scene '"+sceneName+"' isLoaded: "+ SceneManager.GetSceneByName(sceneName).isLoaded);
        if(SceneManager.GetSceneByName(sceneName).isLoaded == false)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        muutaScene = sceneName;
        HideSceneObjects();

        // kursorin näkyminen skeneissä
        bool loadingFirstPersonScene = false;
        if (sceneName == "kauhutalo")
        {
            loadingFirstPersonScene = true;
        }
        if (loadingFirstPersonScene == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        Cursor.visible = !loadingFirstPersonScene;
    }

    public void HideSceneObjects()
    {
        Debug.Log("Hiding objects in '" + SceneManager.GetActiveScene().name + "' (" + SceneManager.GetActiveScene().GetRootGameObjects().Length + ")");
        foreach (var go in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            if (go.GetComponent<Scenemanager>() == null)
            {
                go.SetActive(false);
            }
        }
    }

    public void ShowSceneObjects()
    {
        Debug.Log("Showing objects in '" + SceneManager.GetActiveScene().name + "' (" + SceneManager.GetActiveScene().GetRootGameObjects().Length + ")");
        foreach (var go in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            go.SetActive(true);
        }
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
