using UnityEngine;

public class BaseCharacterStatManagement : MonoBehaviour, IStatManagement<BaseCharacter, BaseCharacterStatManagement> {

    public float currentHealth;
    public float currentMana;

    #region CharacterBaseStats
    [SerializeField] protected BaseCharacter characterStats;

    protected Vector2 baseDamage;
    protected float attackSpeed;
    protected float maxHealth, maxMana;
    protected float armor, magicArmor;
    protected float attackRange;
    protected float movementSpeed;
    protected float healthRegeneration;
    protected float manaRegeneration;
    protected int goldGivenUponDeath;
    protected CharacterAttackType attackType = CharacterAttackType.PHYSICAL;
    protected CharacterAttackRangeType attackRangeType = CharacterAttackRangeType.MELEE;

    public Vector2 BaseDamage { get { return baseDamage; } }
    #endregion

    private void Start()
    {
        LoadStats(characterStats);
    }

    public void LoadStats(BaseCharacter stats)
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

        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    public void OnDamageTaken(BaseCharacterStatManagement recievingCharacter, BaseCharacterStatManagement attackingCharacter, CharacterAttackType type, float dmg)
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

        Debug.Log("Damage after armor damage reduction = " + reducedDmg);

        if(recievingCharacter.currentHealth - reducedDmg <= 0)
        {
            recievingCharacter.currentHealth = 0;
            if(attackingCharacter is HeroCharacterStatManagement)
            {
                HeroCharacterStatManagement heroCharacterStatManager = (HeroCharacterStatManagement)attackingCharacter;
                heroCharacterStatManager.currentGold += recievingCharacter.goldGivenUponDeath;
                Debug.Log(recievingCharacter.characterStats.CharacterName + " died. " + recievingCharacter.goldGivenUponDeath + " gold added to " + attackingCharacter.characterStats.CharacterName);
            }
        }
        else
        {
            recievingCharacter.currentHealth -= reducedDmg;
        }
    }
}

public interface IStatManagement<T, Y> {

    void LoadStats(T stats);
    void OnDamageTaken(Y recievingCharacterStatManagement, BaseCharacterStatManagement attackingCharacterStatManagement, CharacterAttackType attackType, float damage);
}