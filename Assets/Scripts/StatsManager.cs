using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;

    public int statPoints;

    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;
    public float attackSpeed;
    public float intelligence;
    public float mana;
    public float crit;

    [Header("Movement Stats")]
    public int speed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
