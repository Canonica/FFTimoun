using UnityEngine;
using System.Collections;
using System;

namespace GambitSystem
{
    public class UnderCondition : /*ICondition*/ MonoBehaviour
    {

        /*public override bool CheckCondition(EntityType parEntityType, ConditionTarget parConditionTarget, ConditionOperator parOperator, float parValue)
        {
            switch(parConditionTarget)
            {
                case ConditionTarget.Life:
                    if(parEntityType == EntityType.Ally)
                    {
                        return CheckOperator(parOperator, target.GetComponent<Life>().life, parValue);
                    }
                    else if(parEntityType == EntityType.Enemy)
                    {
                        return CheckOperator(parOperator, target.GetComponent<Life>().life, parValue);
                    }
                    return true;
                    break;

                case ConditionTarget.MagicalResistance:
                    return true;
                    break;

                case ConditionTarget.PhysicalResistance:
                    return true;
                    break;

                case ConditionTarget.Stamina:
                    if (parEntityType == EntityType.Ally)
                    {
                        return CheckOperator(parOperator, target.GetComponent<Stamina>().stamina, parValue);
                    }
                    else if (parEntityType == EntityType.Enemy)
                    {
                        return CheckOperator(parOperator, target.GetComponent<Stamina>().stamina, parValue);
                    }
                    return true;
                    break;

                case ConditionTarget.None:
                    return true;
                    break;
            }

            return true; ;
        }*/

        /*bool CheckOperator(ConditionOperator parOperator, float parValue1, float parValue2)
        {
            if(parOperator == ConditionOperator.Equal)
            {
                if(parValue1 == parValue2)
                {
                    return true;
                }
            }else if(parOperator == ConditionOperator.Diff)
            {
                if (parValue1 != parValue2)
                {
                    return true;
                }
            }
            else if (parOperator == ConditionOperator.Sup)
            {
                if (parValue1 > parValue2)
                {
                    return true;
                }
            }
            else if (parOperator == ConditionOperator.SupOrEqual)
            {
                if (parValue1 >= parValue2)
                {
                    return true;
                }
            }
            else if (parOperator == ConditionOperator.Under)
            {
                if (parValue1 < parValue2)
                {
                    return true;
                }
            }
            else if (parOperator == ConditionOperator.UnderOrEqual)
            {
                if (parValue1 <= parValue2)
                {
                    return true;
                }
            }

            return false;
        }*/
        
    }
}

