using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterStatManagement : MonoBehaviour {

    #region CharacterBaseStats
    [SerializeField] BaseCharacter characterStats;

    protected Vector2 damage;
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
        LoadStats();
    }

    protected virtual void LoadStats()
    {
        damage = characterStats.DamageRange;
        attackSpeed = characterStats.AttackSpeed;
        maxHealth = characterStats.Health;
        maxMana = characterStats.Mana;
        armor = characterStats.Armor;
        magicArmor = characterStats.MagicArmor;
        attackRange = characterStats.AttackRange;
        movementSpeed = characterStats.MovementSpeed;
        healthRegeneration = characterStats.HealthRegeneration;
        manaRegeneration = characterStats.ManaRegeneration;
        goldGivenUponDeath = characterStats.GoldGivenUponDeath;
        attackType = characterStats.AttackType;
        attackRangeType = characterStats.RangeType;
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
