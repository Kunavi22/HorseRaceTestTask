using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI horseSelectionText;
    [SerializeField]
    GameObject prevHorseButton;
    [SerializeField]
    GameObject nextHorseButton;

    [SerializeField]
    Slider betSlider;
    [SerializeField]
    TextMeshProUGUI betText;


    [SerializeField]
    GameObject resultWindow;

    [SerializeField]
    TextMeshProUGUI resultTextPannel;

    int maxHorses = 6;

    public int horseSelected { get; private set; } = 1;
    public int currentBet { get; private set; } = 500;


    public static UIManager instance;
    private void Awake()
    {
        instance = this;

        
    }

    void Update()
    {
        currentBet = (int)betSlider.value;
        betText.text = currentBet + "$";
    }

    public void NextHorse()
    {
        horseSelected++;

        prevHorseButton.SetActive(true);

        if (horseSelected == maxHorses)
        {
            nextHorseButton.SetActive(false);
        }

        horseSelectionText.text = horseSelected.ToString();
    }

    public void PrevHorse()
    {
        horseSelected--;

        nextHorseButton.SetActive(true);

        if (horseSelected == 1)
        {
            prevHorseButton.SetActive(false);
        }

        horseSelectionText.text = horseSelected.ToString();
    }


    public void ShowWinUI(int horsePlace)
    {
        string[] ordinalNum = {"first", "second", "third", "fourth", "fifth", "sixth"};

        string resultText = "Your horse fihished " + ordinalNum[horsePlace - 1] +"!";

        if (horsePlace == 1)
        {
            resultText += "\r\n\r\nYou won " + currentBet * maxHorses + "$!";          
        }

        resultTextPannel.text = resultText;

        resultWindow.SetActive(true);
    }
}
