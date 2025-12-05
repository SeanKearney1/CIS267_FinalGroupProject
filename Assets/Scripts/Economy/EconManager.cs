using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
public static class EconManager // BUG FOUND, i know that when you change between levels it wont default to the base ammount, 
{//////////////////////////////// probably can add a reset ammt function to this, then call it on load in the gamemanager
    private static int gold = 100;
    public static int GiveGold()
    {
        return gold;
    }
    public static void Income(int ammt)
    {
        gold += ammt;
    }
    public static bool cost(int ammt)// when using any gold use "if(EconManager.cost(COSTOFWHATYOUAREDOING))
    {////////////////////////////////// if the player can afford it it takes the money away automatically and returns true otherwise the transaction is denied return false
        if (gold < ammt)
        {
            return false;
        }
        else
        {
            gold -= ammt;
            return true;
        }
    }




}
