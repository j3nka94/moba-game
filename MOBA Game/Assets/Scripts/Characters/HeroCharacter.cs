using UnityEngine;

[CreateAssetMenu(fileName = "New Hero Character", menuName = "Characters/Hero Character")]
public class HeroCharacter : BaseCharacter {

    [SerializeField] protected float baseStrength;
    [SerializeField] protected float baseAgility;
    [SerializeField] protected float baseIntelligence;

    [SerializeField] protected float strengthPerLevel;
    [SerializeField] protected float agilityPerLevel;
    [SerializeField] protected float intelligencePerLevel;

    public float BaseStrength { get { return baseStrength; } }
    public float BaseAgility { get { return baseAgility; } }
    public float BaseIntelligence { get { return baseIntelligence; } }
    public float StrengthPerLevel { get { return strengthPerLevel; } }
    public float AgilityPerLevel { get { return agilityPerLevel; } }
    public float IntelligencePerLevel { get { return intelligencePerLevel; } }
}
