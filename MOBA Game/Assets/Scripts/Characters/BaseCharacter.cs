using UnityEngine;

[CreateAssetMenu(fileName = "New Base Character", menuName = "Characters/Base Character")]
public class BaseCharacter : ScriptableObject {

    [SerializeField] protected string characterName;

    [SerializeField] protected int health;
    [SerializeField] protected float armor, magicArmor;


}
