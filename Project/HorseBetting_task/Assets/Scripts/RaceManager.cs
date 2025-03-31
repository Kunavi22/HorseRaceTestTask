using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    [SerializeField]
    List<HorseController> horses;

    [SerializeField]
    Animator[] doorAnimators;


    UIManager uiManager;
    CameraFollow cameraFollow;

    int[] horsePlace;

    int horsesFinished;

    int doorOpenedHash;

    private void Start()
    {
        horsePlace = new int[horses.Count];

        uiManager = UIManager.instance;

        cameraFollow = Camera.main.GetComponent<CameraFollow>();

        doorOpenedHash = Animator.StringToHash("doorOpened");

        ResetRace();
    }

    public void StartRace()
    {
        horsesFinished = 0;

        foreach (var horse in horses)
        {
            horse.StartRunning();
        }

        foreach(var doorAnim in  doorAnimators)
        {
            doorAnim.SetBool(doorOpenedHash, true);
        }

        cameraFollow.target = horses[uiManager.horseSelected - 1].transform;
    }

    public void ResetRace()
    {
        foreach (var horse in horses)
        {
            horse.StopRunning();

            //set horse to start coords
            horse.transform.position = new Vector3(199, horse.transform.position.y, horse.transform.position.z);
        }

        foreach (var doorAnim in doorAnimators)
        {
            doorAnim.SetBool(doorOpenedHash, false);
        }

        cameraFollow.ResetCamera();
    }


    public void RegisterHorseFinished(HorseController horse)
    {
        int horseIndex = horses.IndexOf(horse);

        horsePlace[horseIndex] = ++horsesFinished;

        if(horseIndex + 1 == uiManager.horseSelected)
        {
            //show win UI
            uiManager.ShowWinUI(horsesFinished);
        }
    }

}
