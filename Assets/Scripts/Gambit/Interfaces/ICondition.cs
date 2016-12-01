using UnityEngine;
using System.Collections;
using System;

namespace GambitSystem
{
    [Serializable]
    public class ICondition
    {

        public Entity entity;

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
        }

        public void ExecuteAction()
        {
            switch (action)
            {
                case Action.Heal:
                    entity.heal.DoHeal();
                    break;
                case Action.Physical:
                    entity.physicalAttack.DoAttack();
                    break;
                case Action.Magical:
                    entity.magicalAttack.DoAttack();
                    break;

                default:
                    break;
            }

            TurnManager.instance.CheckEndTurn(entity);
        }
        
        
        public bool CheckCondition(/*EntityType parEntityType, ConditionTarget parConditionTarget, ConditionOperator parOperator, float parValue*/)
        {
            if (conditionTarget == ConditionTarget.Life)
            {
               if (entityType == EntityType.Ally)
                {
                    if(entity.currentCamp == Entity.Camp.Player)
                    {
                        foreach (Entity player in CombatManager.instance.playerEntities)
                        {
                            entity.currentTarget = player;
                            return CheckOperator(conditionOperator, player.currentLife, value);
                        }
                    }else
                    {
                        foreach (Entity enemy in CombatManager.instance.enemyEntities)
                        {
                            entity.currentTarget = enemy;
                            return CheckOperator(conditionOperator, enemy.currentLife, value);
                        }
                    }
                    
                }
                return false;
            }else if(conditionTarget == ConditionTarget.MagicalResistance)
            {
                
                if (entityType == EntityType.Enemy)
                {
                    if(entity.currentCamp == Entity.Camp.Player)
                    {
                        Entity betterTarget = CombatManager.instance.enemyEntities[0];
                        for(int i= 0; i < CombatManager.instance.enemyEntities.Count; i++)
                        {
                            if(CombatManager.instance.enemyEntities[i].magicalResistancePercentage < betterTarget.magicalResistancePercentage)
                            {
                                betterTarget = CombatManager.instance.enemyEntities[i];
                            }
                        }

                        entity.currentTarget = betterTarget;
                        return true;
                    }else
                    {
                        Entity betterTarget = CombatManager.instance.playerEntities[0];
                        for (int i = 0; i < CombatManager.instance.playerEntities.Count; i++)
                        {
                            if (CombatManager.instance.playerEntities[i].magicalResistancePercentage < betterTarget.magicalResistancePercentage)
                            {
                                betterTarget = CombatManager.instance.playerEntities[i];
                            }
                        }

                        entity.currentTarget = betterTarget;
                        return true;
                        /*foreach (Entity player in CombatManager.instance.playerEntities)
                        {
                            entity.currentTarget = player;
                            return CheckOperator(ConditionOperator.UnderOrEqual, player.physicalResistancePercentage, player.magicalResistancePercentage);
                        }*/
                    }
                    
                }
                return false;
            }
            else if (conditionTarget == ConditionTarget.PhysicalResistance)
            {
                if (entity.currentCamp == Entity.Camp.Player)
                {
                    Entity betterTarget = CombatManager.instance.enemyEntities[0];
                    for (int i = 0; i < CombatManager.instance.enemyEntities.Count; i++)
                    {
                        if (CombatManager.instance.enemyEntities[i].physicalResistancePercentage < betterTarget.physicalResistancePercentage)
                        {
                            betterTarget = CombatManager.instance.enemyEntities[i];
                        }
                    }

                    entity.currentTarget = betterTarget;
                    return true;
                }
                else
                {
                    Entity betterTarget = CombatManager.instance.playerEntities[0];
                    for (int i = 0; i < CombatManager.instance.playerEntities.Count; i++)
                    {
                        if (CombatManager.instance.playerEntities[i].physicalResistancePercentage < betterTarget.physicalResistancePercentage)
                        {
                            betterTarget = CombatManager.instance.playerEntities[i];
                        }
                    }

                    entity.currentTarget = betterTarget;
                    return true;
                    /*foreach (Entity player in CombatManager.instance.playerEntities)
                    {
                        entity.currentTarget = player;
                        return CheckOperator(ConditionOperator.UnderOrEqual, player.physicalResistancePercentage, player.magicalResistancePercentage);
                    }*/
                }
                return false;
            }
            else if (conditionTarget == ConditionTarget.None)
            {
                return true;
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

