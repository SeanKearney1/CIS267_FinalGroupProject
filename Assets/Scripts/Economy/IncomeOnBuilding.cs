using UnityEngine;

public class IncomeOnBuilding : MonoBehaviour
{
    [Header("50 for t1 / 75 for t2 / 100 for t3")]
    public int incomeCoef;// probably do 100 for t1, 175 for t2, 250 for t3
    public bool startBought;
    [Header("150 for t1 / 175 for t2 / 200 for t3")]
    public int cost;//


    private int maxNumUpgrades;
    private int numUpgrades=0;




    private int givenGold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (startBought)
        {
            EconManager.upgradeIncome(incomeCoef);
            numUpgrades++;
        }
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
        }
    }



}
