using UnityEngine;
using TMPro;

public class IncomeOnBuilding : MonoBehaviour
{
    [Header("50 for t1 / 75 for t2 / 100 for t3")]
    public int incomeCoef;// probably do 100 for t1, 175 for t2, 250 for t3
    public bool startBought;
    [Header("150 for t1 / 175 for t2 / 200 for t3")]
    public int cost;//


    private int maxNumUpgrades=3;
    private int numUpgrades=0;

    public TMP_Text UpgradeButton;

    public TMP_Text DescText;

    private int givenGold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (startBought)
        {
            EconManager.upgradeIncome(incomeCoef);
            numUpgrades++;
        }
        DescText.text = $"{incomeCoef} g per round for {cost}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void upgrade()
    {
        if (EconManager.cost(cost))
        {
            if (numUpgrades != maxNumUpgrades)
            {
                numUpgrades++;
                EconManager.upgradeIncome(incomeCoef);
            }
            else
            {
                UpgradeButton.text = "MAXXED!";
            }
        }
    }



}
