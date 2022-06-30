using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoList : MonoBehaviour
{
    public int AllTasks;
    public int finishedTasks;

    public int NumberOfRoofSpikesToFix;
    public int FixedRoofSpikes;

    public int NumberOfTrapDoorsToFix;
    public int FixedTrapDoors;

    public int NumberOfPlatformsToFix;
    public int FixedPlatforms;

    public int NumberOfPressurePlatesFix;
    public int FixedPressurePlates;

    public int NumberOfEnemiesNotInPosition;
    public int EnemiesInPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] CountingPlatforms = GameObject.FindGameObjectsWithTag("MoveablePlatforms");
        NumberOfPlatformsToFix = CountingPlatforms.Length;

        GameObject[] CountingRoofSpikes = GameObject.FindGameObjectsWithTag("RoofSpikes");
        NumberOfRoofSpikesToFix = CountingRoofSpikes.Length;

        GameObject[] CountingPressurePlates = GameObject.FindGameObjectsWithTag("PressurePlates");
        NumberOfPressurePlatesFix = CountingPressurePlates.Length;

        GameObject[] CountingTrapDoors = GameObject.FindGameObjectsWithTag("TrapDoors");
        NumberOfTrapDoorsToFix = CountingTrapDoors.Length;

        GameObject[] CountingEnemies = GameObject.FindGameObjectsWithTag("Enemies");
        NumberOfEnemiesNotInPosition = CountingEnemies.Length;

        AllTasks = (NumberOfTrapDoorsToFix + NumberOfRoofSpikesToFix + NumberOfPressurePlatesFix + NumberOfPlatformsToFix + NumberOfEnemiesNotInPosition);
    }

    // Update is called once per frame
    void Update()
    {
     
        if(FixedPlatforms == NumberOfPlatformsToFix)
        {
            //Code that adds tick to section of To-Do list
        }

        if(FixedTrapDoors == NumberOfTrapDoorsToFix)
        {
            //Code that adds tick to section of To-Do list
        }

        if (FixedRoofSpikes == NumberOfRoofSpikesToFix)
        {
            //Code that adds tick to section of To-Do list
        }

        if (FixedPressurePlates == NumberOfPressurePlatesFix)
        {
            //Code that adds tick to section of To-Do list
        }

        if(EnemiesInPosition == NumberOfEnemiesNotInPosition)
        {
            //Code that adds tick to section of To-Do list
        }

        if (finishedTasks == AllTasks)
        {
            //Code that adds tick to section of To-Do list and lets the player finish the level
        }

    }
}
