using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
//=====================================
// IF YOU INTEND TO USE THIS SCRIPT FOR ENEMIES RANGE
// copy and paste this in a new script
// replace if condition on the trigger enter+exit to  (collision.gameObject.CompareTag("player") || collision.gameObject.CompareTag("enemy"))
//
// HOW TO USE
//
// on the object you want to give this script to
// create empty child
// attach a circle collider2d to the empty
// size = range
// IS TRIGGER X
// in the script controller of this thing 
// ============================
//
//
//   void Start()
//   {
//        RangeController rangeController = GetComponentInChildren<RangeController>();
//   }
//  // inside an if(rangeController.isAnEnemyInRange())
//  //call rangeController.enemyPosition() to get a vector3 
//
//=====================================
public class RangeController : MonoBehaviour
{
    private List<GameObject> enemiesInRange = new List<GameObject>();// all things in range of the colider

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))//if enemy enter range
        {
            enemiesInRange.Add(collision.gameObject);// add to the list
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))// if enemy exit range
        {
            enemiesInRange.Remove(collision.gameObject);// remove from list
        }
    }
    public Vector3 enemyPosition()
    {
        return enemiesInRange[0].transform.position;
    }
    public bool isAnEnemyInRange()
    {
        if (enemiesInRange.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
