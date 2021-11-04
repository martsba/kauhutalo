using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePicture : MonoBehaviour
{
    public List<GameObject> kuutio;
    public List<GameObject> maali;
    public float etaisyys;
    public List<bool> kuutiomaalissa;
    public GameObject teksti;
    public GameObject nappi;
    static public bool kuutiotpaikoillaan;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPosition;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("dragging: " + hit.collider.gameObject.name);
                mouseWorldPosition = hit.point;
                hit.collider.gameObject.transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, 0f);
            }
        }

        for (int i = 0; i < kuutio.Count; i++)
        {
            if (Vector3.Distance(kuutio[i].gameObject.transform.position, maali[i].gameObject.transform.position) < etaisyys)
            {
                kuutiomaalissa[i] = true;
            }
        }
        if (IsAllKuutioInMaali() == true)
        {
            teksti.SetActive(true);
            nappi.SetActive(true);
            kuutiotpaikoillaan = true;
        }
    }
    private bool IsAllKuutioInMaali()
    {
        for (int i = 0; i < kuutiomaalissa.Count; i++)
        {
            if(kuutiomaalissa[i] == false)
            {
                return false;
            }
        }
        return true;
    }
}
