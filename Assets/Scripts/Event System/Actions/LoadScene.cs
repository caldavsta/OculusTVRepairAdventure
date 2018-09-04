using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Event_System.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;


class LoadScene : ActionBehaviour
{
    public string SceneToLoad;
    public override void OnStart()
    {
        if (SceneToLoad.Equals(""))
        {
            Debug.LogError("SceneToLoad is blank!");
        }
    }

    public override void OnUpdate()
    {

    }

    public override void DoAction()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}

