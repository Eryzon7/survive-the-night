using System;
using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statSlots;
    private int[] Upgrades = new int[8] {0,0,0,0,0,0,0,0};
    public CanvasGroup statCanvas;
    public CanvasGroup playerUICanvas;
    private int pointUsed;
   

    private bool statsShowing = false;
    private bool upgradePending = false;

    private void Start()
    {
        UpdateAllStats();
    }

    private void Update()
    {
        if(Input.GetButtonDown("ToggleStats"))
        {
            if(statsShowing)
            {
                UpdateAllStats();
                statCanvas.alpha = 0;
                playerUICanvas.alpha = 1;
                statsShowing = false;
            }
            else
            {
                statCanvas.alpha = 1;
                playerUICanvas.alpha = 0;
                statsShowing = true;
            }
        }
    }

    public void UpgradeStat(int stat)
    {
        if (StatsManager.Instance.statPoints > 0)
        {
            StatsManager.Instance.statPoints--;
            pointUsed++;
            int baseStat = Convert.ToInt16(statSlots[stat].GetComponentInChildren<TMP_Text>().text);
            baseStat++;
            statSlots[stat].GetComponentInChildren<TMP_Text>().text = Convert.ToString(baseStat);
            statSlots[stat].GetComponentInChildren<TMP_Text>().color = Color.blue;
            Upgrades[stat]++;
        }
    }

    public void ConfirmUpgrade()
    {
        if (pointUsed > 0)
        {
            for (int i = 0; i < Upgrades.Length; i++)
            {
                statSlots[i].GetComponentInChildren<TMP_Text>().color = Color.white;
                switch (i)
                {
                    case 0:
                        StatsManager.Instance.damage = StatsManager.Instance.damage + Upgrades[i];
                        break;
                    case 1:
                        StatsManager.Instance.speed = StatsManager.Instance.speed + Upgrades[i];
                        break;
                    case 2:
                        StatsManager.Instance.maxHealth = StatsManager.Instance.maxHealth + Upgrades[i];
                        break;
                    case 3:
                        StatsManager.Instance.attackSpeed = StatsManager.Instance.attackSpeed + Upgrades[i];
                        break;
                    case 4:
                        StatsManager.Instance.intelligence = StatsManager.Instance.intelligence + Upgrades[i];
                        break;
                    case 5:
                        StatsManager.Instance.mana = StatsManager.Instance.mana + Upgrades[i];
                        break;
                    case 6:
                        StatsManager.Instance.crit = StatsManager.Instance.crit + Upgrades[i];
                        break;
                }

                Upgrades[i] = 0;
            }
            pointUsed = 0;
        }
        
    }
    public void CancelUpgrade()
    {
        if (pointUsed > 0)
        {
            for (int i = 0; i < Upgrades.Length; i++)
            {
                int currentStat = Convert.ToInt16(statSlots[i].GetComponentInChildren<TMP_Text>().text);
                statSlots[i].GetComponentInChildren<TMP_Text>().text = Convert.ToString(currentStat - Upgrades[i]);
                statSlots[i].GetComponentInChildren<TMP_Text>().color = Color.white;

                Upgrades[i] = 0;
            }
            pointUsed = 0;
        }
            
    }

    public void UpdateAllStats()
    {
        statSlots[0].GetComponentInChildren<TMP_Text>().text = Convert.ToString(StatsManager.Instance.damage);
        statSlots[1].GetComponentInChildren<TMP_Text>().text = Convert.ToString(StatsManager.Instance.speed);
        statSlots[2].GetComponentInChildren<TMP_Text>().text = Convert.ToString(StatsManager.Instance.maxHealth);
        statSlots[3].GetComponentInChildren<TMP_Text>().text = Convert.ToString(StatsManager.Instance.attackSpeed);
        statSlots[4].GetComponentInChildren<TMP_Text>().text = Convert.ToString(StatsManager.Instance.intelligence);
        statSlots[5].GetComponentInChildren<TMP_Text>().text = Convert.ToString(StatsManager.Instance.mana);
        statSlots[6].GetComponentInChildren<TMP_Text>().text = Convert.ToString(StatsManager.Instance.crit);

    }

    public enum statType
    {
        damage,
        speed,
        Attacking,
        Knockback
    }
}
