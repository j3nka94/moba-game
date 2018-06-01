using UnityEngine;

public class HeroCharacterStatManagement : BaseCharacterStatManagement, IHeroCharacterStatManagement<HeroCharacter, HeroCharacterStatManagement> {

    [SerializeField] HeroCharacter heroStats;

    public int currentGold;

    protected AttributeType attributeType;
    protected float strength;
    protected float agility;
    protected float intelligence;

    protected float strengthPerLevel;
    protected float agilityPerLevel;
    protected float intelligencePerLevel;

    private void Start()
    {
        LoadStats(heroStats);
    }

    public void LoadStats(HeroCharacter stats)
    {
        base.LoadStats(stats);

        currentGold = 600;
        attributeType = stats.CharacterAttribute;
        strength = stats.BaseStrength;
        agility = stats.BaseAgility;
        intelligence = stats.BaseIntelligence;
        strengthPerLevel = stats.StrengthPerLevel;
        agilityPerLevel = stats.AgilityPerLevel;
        intelligencePerLevel = stats.IntelligencePerLevel;

        Debug.Log(maxHealth);
        Debug.Log(attributeType);
    }
    public void OnStrengthChange(HeroCharacterStatManagement heroStatManagement, float amount)
    {
        heroStatManagement.strength += amount;
        Debug.Log("Strength increased to " + heroStatManagement.strength);
        if (heroStatManagement.attributeType == AttributeType.STRENGTH)
        {
            heroStatManagement.baseDamage += new Vector2(amount, amount);
            Debug.Log("Damage increased to " + heroStatManagement.BaseDamage);
        }
    }

    public void OnAgilityChange(HeroCharacterStatManagement heroStatManagement, float amount)
    {
        heroStatManagement.agility += amount;
        Debug.Log("Agility increased to " + heroStatManagement.agility);
        if (heroStatManagement.attributeType == AttributeType.AGILITY)
        {
            heroStatManagement.baseDamage += new Vector2(amount, amount);
            Debug.Log("Damage increased to " + heroStatManagement.BaseDamage);
        }
    }

    public void OnIntelligenceChange(HeroCharacterStatManagement heroStatManagement, float amount)
    {
        heroStatManagement.intelligence += amount;
        Debug.Log("Intelligence increased to " + heroStatManagement.intelligence);
        if (heroStatManagement.attributeType == AttributeType.INTELLIGENCE)
        {
            heroStatManagement.baseDamage += new Vector2(amount, amount);
            Debug.Log("Damage increased to " + heroStatManagement.BaseDamage);
        }
    }

    public void OnDamageTaken(HeroCharacterStatManagement recievingCharacter, BaseCharacterStatManagement attackingCharacter, CharacterAttackType type, float dmg)
    {
        base.OnDamageTaken(recievingCharacter, attackingCharacter, type, dmg);
    }
}

public interface IHeroCharacterStatManagement<T,Y> : IBaseCharacterStatManagement<T, Y> {

    void OnStrengthChange(Y statManager, float amount);
    void OnAgilityChange(Y statManager, float amount);
    void OnIntelligenceChange(Y statManager, float amount);
}
