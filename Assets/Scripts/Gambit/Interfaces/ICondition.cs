using UnityEngine;
using System.Collections;
using System;

namespace GambitSystem
{
    [Serializable]
    public class ICondition
    {

        public EntityType entityType;
        public enum EntityType
        {
            Ally,
            Enemy,
            None,
        }
        
        public ConditionTarget conditionTarget;
        public enum ConditionTarget
        {
            Life,
            MagicalResistance,
            PhysicalResistance,
            Stamina,
            None,
        }
        
        public ConditionOperator conditionOperator;
        public enum ConditionOperator
        {
            Under,
            UnderOrEqual,
            Equal,
            SupOrEqual,
            Sup,
            Diff,
        }

        public float value;

        public Action action;
        public enum Action
        {
            Magical,
            Physical,
            Heal,
            None,
        }
        
        
        public bool CheckCondition(EntityType parEntityType, ConditionTarget parConditionTarget, ConditionOperator parOperator, float parValue)
        {
            if (parConditionTarget == ConditionTarget.Life)
            {
               if (parEntityType == EntityType.Ally)
                {
                    return CheckOperator(parOperator, CombatManager.instance.listOfEntity[0].currentLife, parValue);
                }
                else if (parEntityType == EntityType.Enemy)
                {
                    return CheckOperator(parOperator, CombatManager.instance.listOfEntity[0].currentLife, parValue);
                }
                return false;
            }else if(parConditionTarget == ConditionTarget.MagicalResistance)
            {
                return false;
            }
            else if (parConditionTarget == ConditionTarget.PhysicalResistance)
            {
                return false;
            }
            else if (parConditionTarget == ConditionTarget.Stamina)
            {
                /*if (parEntityType == EntityType.Ally)
                    {
                        return CheckOperator(parOperator, target.GetComponent<Stamina>().stamina, parValue);
                    }
                    else if (parEntityType == EntityType.Enemy)
                    {
                        return CheckOperator(parOperator, target.GetComponent<Stamina>().stamina, parValue);
                    }*/
                return false;
            }
            else if (parConditionTarget == ConditionTarget.None)
            {
                return false;
            }

            return false;
        }

        bool CheckOperator(ConditionOperator parOperator, float parValue1, float parValue2)
        {
            if (parOperator == ConditionOperator.Equal)
            {
                if (parValue1 == parValue2)
                {
                    return true;
                }
            }
            else if (parOperator == ConditionOperator.Diff)
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
        }
    }
}

