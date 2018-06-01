using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterStatManager : BaseCharacterStatManagement {

    [SerializeField] HeroCharacter heroStats;

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

    protected override void LoadStats(BaseCharacter stats)
    {
        base.LoadStats(stats);

        HeroCharacter heroCharacterStats = (HeroCharacter)stats;
        attributeType = heroCharacterStats.CharacterAttribute;
        strength = heroCharacterStats.BaseStrength;
        agility = heroCharacterStats.BaseAgility;
        intelligence = heroCharacterStats.BaseIntelligence;
        strengthPerLevel = heroCharacterStats.StrengthPerLevel;
        agilityPerLevel = heroCharacterStats.AgilityPerLevel;
        intelligencePerLevel = heroCharacterStats.IntelligencePerLevel;

        Debug.Log(attributeType);
    }
}
