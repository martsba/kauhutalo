using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0.0f));
        if (Physics.Raycast(ray, out hit, 3.0f))
        {
            //Debug.Log("You looked at the " + hit.transform.name); // ensure you picked right object
            if (Input.GetMouseButtonDown(0))
            {
                InteractableObject objekti;
                objekti = hit.transform.gameObject.GetComponent<InteractableObject>();
                if (objekti != null)
                {
                    objekti.Klikattu();
                }
            }
        }

    }
}
