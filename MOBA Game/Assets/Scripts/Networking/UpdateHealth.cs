using UnityEngine;
using UnityEngine.Networking;

public class UpdateHealth : NetworkBehaviour {

    public float maxHealth;

    [SyncVar(hook = "OnUpdateHealthBar")]
    public float currentHealth;

    public RectTransform healthBar;

    public void OnUpdateMaxHealth(float amount)
    {
        maxHealth += amount;
    }

	public void OnUpdateHealth(float amount)
    {
        if (!isServer)
            return;

        currentHealth += amount;
    }

    void OnUpdateHealthBar(float health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
}
