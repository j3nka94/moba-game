﻿using UnityEngine;

public class TestReduceHealth : MonoBehaviour {

    public BaseCharacterStatManagement recieving;
    public HeroCharacterStatManagement giving;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            float damageGiven = Random.Range(giving.BaseDamage.x, giving.BaseDamage.y);
            Debug.Log("Damage before armor damage reduction = " + damageGiven);
            recieving.OnDamageTaken(recieving, giving, CharacterAttackType.PHYSICAL, damageGiven);
            Debug.Log("Character's remaining health = " + recieving.currentHealth);
        }
	}
}
