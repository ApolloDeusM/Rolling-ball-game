using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class menuMemory : MonoBehaviour
{
    public TextMeshProUGUI Coins;
    TextMeshProUGUI CollectedCoins_text;
    public CoinManager coinManager;
    public BallController ballController;
    public GameObject Ballcounter,pauseButton,IngameLevel;
    public GameObject GeneralCoins,CollectedCoins;
    public TextMeshProUGUI GeneralCoins_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CollectedCoins_text = CollectedCoins.GetComponent<TextMeshProUGUI>();
        //Coins.text = coinManager.top_Coins.text;
        CollectedCoins_text = ballController.collected_Coins;
        GeneralCoins_text.text = GameDataManager.Instance.playerData.coins.ToString();
        Debug.Log(GeneralCoins_text.text);
    }

    // Update is called once per frame
    void Update()
    {
        GeneralCoins_text.text = GameDataManager.Instance.playerData.coins.ToString();
        CollectedCoins_text = ballController.collected_Coins;
        Coins.text = coinManager.top_Coins.text;
        
        if(ballController.isPlaying)
        {
            Ballcounter.transform.localPosition = new Vector3(0,740,0);
            pauseButton.SetActive(true);
            IngameLevel.SetActive(true);
            GeneralCoins.SetActive(false);
            CollectedCoins.SetActive(true);
        }
        else
        {
            Ballcounter.transform.localPosition = new Vector3(-284,860,0);
            pauseButton.SetActive(false); 
            IngameLevel.SetActive(false);
            GeneralCoins.SetActive(true);
            CollectedCoins.SetActive(false);
        }
    }
}
