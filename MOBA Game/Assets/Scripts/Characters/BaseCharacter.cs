using UnityEngine;

[CreateAssetMenu(fileName = "New Base Character", menuName = "Characters/Base Character")]
public class BaseCharacter : ScriptableObject {

    [SerializeField] protected string characterName;
    [SerializeField] protected string description;

    // In game variables
    [SerializeField] protected int health;
    [SerializeField] protected float armor, magicArmor;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected AttackType attackType = AttackType.PHYSICAL;
    [SerializeField] protected AttackRangeType attackRangeType = AttackRangeType.MELEE;
}

public enum AttackType
{
    PHYSICAL,
    MAGICAL,
    TRUE,
    MIXED
}

public enum AttackRangeType
{
    MELEE,
    RANGED
}