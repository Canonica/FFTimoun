﻿using UnityEngine;
using System.Collections;
public class Entity : MonoBehaviour {

    public string entityName;

    [Header("Characteristics")]
    public float maxLife;
    public float maxMana;

    [HideInInspector]
    public float currentLife;
    [HideInInspector]
    public float currentMana;

    [Header ("Resistance")]
    public float physicalResistancePercentage;
    public float magicalResistancePercentage;

    public bool hasDoneAction;

    protected Archetype.CurrentArchetype archetype;
    protected AttackType.Type attackPreference;

    public enum CharacteristicType
    {
        Life,
        Mana
    }

    protected virtual void Start()
    {
        currentLife = maxLife;
        currentMana = maxMana;
    }

    public void SubstractCharacteristic(CharacteristicType type, float amount)
    {
        if(type == CharacteristicType.Life)
        {
            currentLife -= amount;
            currentLife = Mathf.Max(0, currentLife);
            if(currentLife <= 0)
            {
                Debug.Log(entityName + " is dead !");
                Destroy(this.gameObject);
            }
        }

        if(type == CharacteristicType.Mana)
        {
            currentMana -= amount;
            currentMana = Mathf.Max(0, currentMana);
        }
    }

    public void AddCharacteristic(CharacteristicType type, float amount)
    {
        if (type == CharacteristicType.Life)
        {
            currentLife += amount;
            currentLife = Mathf.Min(currentLife, maxLife);
        }

        if (type == CharacteristicType.Mana)
        {
            currentMana += amount;
            currentMana = Mathf.Min(currentMana, maxMana);
        }
    }

    public void ReceiveDamage(AttackType.Type type, float amount)
    {
        if(type == AttackType.Type.Magic)
        {
            amount = amount * magicalResistancePercentage / 100;
            SubstractCharacteristic(CharacteristicType.Life, amount);
        }

        if(type == AttackType.Type.Physical)
        {
            amount = amount * physicalResistancePercentage / 100;
            SubstractCharacteristic(CharacteristicType.Life, amount);
        }
    }
}