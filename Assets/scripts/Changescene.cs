using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changescene : MonoBehaviour
{
    public SceneState changeStateFrom;
    public SceneState changeStateTo;

    private void OnTriggerEnter(Collider other)
    {
        if (Scenemanager.Instance.sceneState == changeStateFrom)
        {
            Scenemanager.Instance.ChangeState(changeStateTo);
        }
    }
}
