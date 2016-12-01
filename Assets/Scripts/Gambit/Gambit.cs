using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace GambitSystem
{
    public class Gambit : MonoBehaviour
    {
        public ICondition[] arrayOfConditions;

        public void CheckAllCondition()
        {

            for(int i=0; i < arrayOfConditions.Length; i++)
            {
                arrayOfConditions[i].entity = GetComponent<Entity>();
                if (arrayOfConditions[i].CheckCondition())
                {
                    arrayOfConditions[i].ExecuteAction();
                    break;
                }
            }
        }

        /*[Serializable]
        public struct IInputContext
        {
            public InputContextList IContext;
            public List<InToAction> InputMap;
        }

        [Serializable]
        public struct InToAction
        {
            public GamePadButttons Inputs;
            public InputActionList IAction;
        }*/
    }
}

