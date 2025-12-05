using UnityEngine;

public class IncomeOnBuilding : MonoBehaviour
{
    public int incomeCoef;// probably do 1 for t1, 3 for t2, 5 for t3


    private int numProduced = 1;
    private float defaultDelay = 10;
    private float incomeDelayTimeIncrement = 0;

    private int givenGold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeIncome();
    }
    private void timeIncome()
    {
        incomeDelayTimeIncrement += Time.deltaTime;
        if (incomeDelayTimeIncrement > defaultDelay )
        {
            incomeDelayTimeIncrement = 0;
            paycheck();
        }


    }
    private void paycheck()
    {
        givenGold = incomeCoef;// base val
        givenGold *= numProduced;//multiplier
        EconManager.Income(givenGold);
    }
    public void upgrade(int number)
    {
        if (number ==1 )
        {//upgrade rate
            defaultDelay -= 5f;//-5sec
        }
        else if (number == 2)
        {// upgrade base ammount 
            incomeCoef++;//+1 per
        }
        else if (number == 3)
        {// upgrade qtty produced
            numProduced++;
        }
    }



}
