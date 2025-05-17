using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    public int level;
    public int currentExp;
    public int expToLevel = 10;
    public float expGrowthMultilier = 1.2f;
    public Slider expSlider;
    public TMP_Text currentLevelText;

    private void Start()
    {
        UpdateUI();

    }

    private void OnEnable()
    {
        Enemy_Health.OnMonsterDefeat += GainExperience;
    }
    private void OnDisable()
    {
        Enemy_Health.OnMonsterDefeat -= GainExperience;
    }

    public void GainExperience(int amount)
    {
        currentExp += amount;
        if (currentExp > expToLevel)
        {
            LevelUp();
        }
        UpdateUI();
    }

    private void LevelUp()
    {
        StatsManager.Instance.statPoints += 2;
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expGrowthMultilier);
    }

    public void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level: " + level;
    }
}
