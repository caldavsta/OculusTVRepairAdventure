using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Event_System.Actions
{
    public abstract class ActionBehaviour : MonoBehaviour
    {
        public abstract void OnStart();
        public abstract void OnUpdate();

        public void OnTriggerEnter(Collider c)
        {
            
        }

        public void OnCollisionEnter(Collision c)
        {
            
        }

        public void Start()
        {
            if (GetComponents<ActionBehaviour>().Length > 1)
            {
                Debug.LogWarning("ActionBehaviour || There are more than 1 ActionBehaviours attached to this object: " + gameObject.name);
                //Debug.Break();
            }
            OnStart();
        }

        public void Update()
        {
            OnUpdate();
        }
        public abstract void DoAction();
    }
}
