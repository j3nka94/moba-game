using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterStatManagement : MonoBehaviour {

    float currentHealth;
    float currentMana;

    #region CharacterBaseStats
    [SerializeField] BaseCharacter characterStats;

    protected Vector2 baseDamage;
    protected float attackSpeed;
    protected float maxHealth, maxMana;
    protected float armor, magicArmor;
    protected float attackRange;
    protected float movementSpeed;
    protected float healthRegeneration;
    protected float manaRegeneration;
    protected float goldGivenUponDeath;
    protected CharacterAttackType attackType = CharacterAttackType.PHYSICAL;
    protected CharacterAttackRangeType attackRangeType = CharacterAttackRangeType.MELEE;
    #endregion

    private void Start()
    {
        LoadStats(characterStats);
    }

    protected virtual void LoadStats(BaseCharacter stats)
    {
        baseDamage = stats.BaseDamage;
        attackSpeed = stats.AttackSpeed;
        maxHealth = stats.Health;
        maxMana = stats.Mana;
        armor = stats.Armor;
        magicArmor = stats.MagicArmor;
        attackRange = stats.AttackRange;
        movementSpeed = stats.MovementSpeed;
        healthRegeneration = stats.HealthRegeneration;
        manaRegeneration = stats.ManaRegeneration;
        goldGivenUponDeath = stats.GoldGivenUponDeath;
        attackType = stats.AttackType;
        attackRangeType = stats.RangeType;
    }

    public virtual void OnDamageTaken(BaseCharacter attackingCharacter, CharacterAttackType type, float dmg)
    {
        // Damage after armor damage reduction.
        float reducedDmg;

        if(type == CharacterAttackType.PHYSICAL || type == CharacterAttackType.SIEGE)
        {
            reducedDmg = dmg * (1 - armor / 50);
        }
        else if(type == CharacterAttackType.MAGICAL)
        {
            reducedDmg = dmg * (1 - magicArmor / 50);
        }
        else if(type == CharacterAttackType.MIXED)
        {
            reducedDmg = (dmg / 2) * (1 - armor / 50) + (dmg / 2) * (1 - magicArmor / 50);
        }
        else
        {
            reducedDmg = dmg;
        }
    }
}
