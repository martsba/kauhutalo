using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changescene : MonoBehaviour
{
    public SceneState changeStateFrom;
    public SceneState changeStateTo;

    private void OnTriggerEnter(Collider other)
    {
        if (Lightmanager.Instance.sceneState == changeStateFrom)
        {
            Lightmanager.Instance.ChangeState(changeStateTo);
        }
    }
}
