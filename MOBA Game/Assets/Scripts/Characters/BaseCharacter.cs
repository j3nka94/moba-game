using UnityEngine;

[CreateAssetMenu(fileName = "New Base Character", menuName = "Characters/Base Character")]
public class BaseCharacter : ScriptableObject {

    [SerializeField] protected string characterName;
    [SerializeField] protected string description;
    [SerializeField] protected Texture2D image;

    // In game variables
    [SerializeField] protected Vector2 baseDamage;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float health, mana;
    [SerializeField] protected float armor, magicArmor;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected float healthRegeneration;
    [SerializeField] protected float manaRegeneration;
    [SerializeField] protected int goldGivenUponDeath;
    [SerializeField] protected CharacterAttackType attackType = CharacterAttackType.PHYSICAL;
    [SerializeField] protected CharacterAttackRangeType attackRangeType = CharacterAttackRangeType.MELEE;

    public string CharacterName { get { return characterName; } }
    public string Description { get { return description; } }
    public Vector2 BaseDamage { get { return baseDamage; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float Health { get { return health; } }
    public float Mana { get { return mana; } }
    public float Armor { get { return armor; } }
    public float MagicArmor { get { return magicArmor; } }
    public float AttackRange { get { return attackRange; } }
    public float MovementSpeed { get { return movementSpeed; } }
    public float HealthRegeneration { get { return healthRegeneration; } }
    public float ManaRegeneration { get { return manaRegeneration; } }
    public int GoldGivenUponDeath { get { return goldGivenUponDeath; } }
    public CharacterAttackType AttackType { get { return attackType; } }
    public CharacterAttackRangeType RangeType { get { return attackRangeType; } }
}

public enum CharacterAttackType
{
    PHYSICAL,
    SIEGE,
    MAGICAL,
    TRUE,
    MIXED
}

public enum CharacterAttackRangeType
{
    MELEE,
    RANGED
}