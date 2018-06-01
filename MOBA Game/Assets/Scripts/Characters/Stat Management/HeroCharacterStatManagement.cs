using UnityEngine;

public class HeroCharacterStatManagement : BaseCharacterStatManagement, IStatManagement<HeroCharacter, HeroCharacterStatManagement> {

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
        LoadStats(characterStats);
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

    public void OnDamageTaken(HeroCharacterStatManagement recievingCharacter, BaseCharacterStatManagement attackingCharacter, CharacterAttackType type, float dmg)
    {
        base.OnDamageTaken(recievingCharacter, attackingCharacter, type, dmg);
    }
}
