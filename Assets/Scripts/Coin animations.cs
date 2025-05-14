using System.Collections;
using UnityEngine;
using TMPro;
using System;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEditor.Advertisements;

public class CoinManager : MonoBehaviour
{
    public GameObject coin_Instance,nextLevel_title,comingLevel,Advertisement,watchAd,levelCompletedName,levelCompleted;
    public BallController ballController;
    public GameObject[] animated_coins;
    public float coin_duration;
    public Transform animated_coins_targetPosition;
    public Image next_level_BG;
    public Transform topCoins,collectedCoins;
    public float rotationalSpeed,movingSpeed,translationalIncreement,rotationalIncreement;
    public int collectedCoins_Value;
    public TextMeshProUGUI collected_Coins,top_Coins,top_left_levelName;
    public AnimationCurve animationCurve;
    public AudioClip applause;
    public AudioSource audioSource;
    Vector3 coinRotation;
    public float animationDuration;
    string collectedValue,topValue;
    TextMeshProUGUI next_Level;
    public Transform canvas;
    float alpha;
    bool isAnimating_coins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        LeanTween.init(20000);
        isAnimating_coins = false;
        Advertisement.SetActive(false);
         if(GameDataManager.Instance.playerData.coins < 1000)
        {   
           top_Coins.text = Convert.ToString(GameDataManager.Instance.playerData.coins); 
        }
        if(GameDataManager.Instance.playerData.coins >= 1000)
        {
            float coinValue_float = GameDataManager.Instance.playerData.coins;
            top_Coins.text = $"{coinValue_float/1000}k";
        }

        top_left_levelName.text = $"Level {GameDataManager.Instance.playerData.currentLevel} ";
        alpha = 0;
        next_level_BG.color = new Color(1,1,1,alpha);
        next_Level = comingLevel.GetComponent<TextMeshProUGUI>();
        next_Level.text = top_left_levelName.text = $"Level {GameDataManager.Instance.playerData.currentLevel+1} ";
        comingLevel.transform.localScale = Vector3.zero;
        nextLevel_title.transform.localPosition = new Vector3(-900,41,0);
        coinRotation = coin_Instance.transform.localEulerAngles;
        coinRotation.y =0;

        collected_Coins.text = Convert.ToString(collectedCoins_Value);
        Debug.Log(Convert.ToString(collectedCoins_Value));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isAnimating_coins)
        {
            animateCoins_Func();
        }
       top_left_levelName.text = $"Level {GameDataManager.Instance.playerData.currentLevel} "; 
    }
    public void Claim_Coins()
    {
        StartCoroutine(animateCoins(true));
    }

     public void Claim_Coins_noThanks()
    {
        StartCoroutine(animateCoins(false));
    }
    public IEnumerator animateCoins(bool isClaiming)
{ 
    levelCompleted.SetActive(true);
    levelCompletedName.SetActive(true);

    int new_collectedCoins_Value = collectedCoins_Value * 2;
        Advertisement.SetActive(true);
        yield return new WaitForSeconds(3);
        Advertisement.SetActive(false);
        ballController.nothanks_LC.color = new Color(1,1,1,0);

        levelCompleted.SetActive(false);
        levelCompletedName.SetActive(false);

        watchAd.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        isAnimating_coins = true;

        bool rampCoins = true;
    
    alpha = 0;
    
    while(alpha <=1)
    {
        alpha += 0.05f;
        next_level_BG.color = new Color(0.427f,0.859f,0.133f,alpha);
        yield return null;
    }

     if(isClaiming)
         {
            
            int loopingValue = collectedCoins_Value;
            
            while(loopingValue <= new_collectedCoins_Value && rampCoins)
            {
                loopingValue++;
                collected_Coins.text = loopingValue.ToString();
                rampCoins = false;
                yield return null;
            }
            GameDataManager.Instance.UpdateCoins(2);
            
           }
             else
           {
             yield return null;
           }
          
  while (new_collectedCoins_Value > 0)
    {
      /*    GameObject currentCoin = Instantiate(coin_Instance, collectedCoins.localPosition, Quaternion.identity, canvas);
        LeanTween.moveLocal(currentCoin,topCoins.localPosition,0.1f).setEaseOutElastic();

        float proggress = 0;

        while (proggress < 1)
        {
            currentCoin.transform.position = Vector3.Lerp(collectedCoins.localPosition, topCoins.localPosition , movingSpeed * animationCurve.Evaluate(proggress));
            coinRotation.y += rotationalIncreement;
            currentCoin.transform.localEulerAngles = coinRotation; // Apply rotation
            Debug.Log(coinRotation.y);
            proggress += translationalIncreement;
            yield return null;
        }
*/      
        GameDataManager.Instance.UpdateCoins(1);
        new_collectedCoins_Value--;
       
        

        topValue = GameDataManager.Instance.playerData.coins.ToString();
        collectedValue = new_collectedCoins_Value.ToString();
        collected_Coins.text = collectedValue;
         if(GameDataManager.Instance.playerData.coins < 1000)
        {   
           top_Coins.text = Convert.ToString(GameDataManager.Instance.playerData.coins); 
        }
        if(GameDataManager.Instance.playerData.coins >= 1000)
        {
            float coinValue_float = GameDataManager.Instance.playerData.coins;
            top_Coins.text = $"{coinValue_float/1000}k";
        }
        

       // Destroy(currentCoin);
        yield return null;
    }
        nextLevel_title.transform.localPosition = new Vector3(-900,41,0);
        LeanTween.moveLocal(nextLevel_title,new UnityEngine.Vector3(0,41,0),animationDuration).setEase(LeanTweenType.easeInOutQuad);
        yield return new WaitForSeconds(0.5f);
        LeanTween.scale(comingLevel,new Vector3(1,1,1),animationDuration).setEaseInElastic();
        comingLevel.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(0.5f);
        LeanTween.moveLocal(nextLevel_title,new UnityEngine.Vector3(900,41,0),animationDuration).setEase(LeanTweenType.easeInOutQuad);
        yield return new WaitForSeconds(1);
        LeanTween.scale(comingLevel,new Vector3(0,0,0),animationDuration).setEaseInElastic();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        GameDataManager.Instance.toNextLevel();
        top_left_levelName.text = $"Level {GameDataManager.Instance.playerData.currentLevel} ";
        next_Level.text = $"Level {GameDataManager.Instance.playerData.currentLevel +1} ";
        ballController.isPlaying = true;
        ballController.gameObject.transform.position = new Vector3(0,2,0);
        collectedCoins_Value = 50;
        next_level_BG.color = new Color(0.427f,0.859f,0.133f,0);
        ballController.PlayGame();
        //reset values
        ballController.nothanks_LC.color = new Color(1,1,1,0);
        watchAd.SetActive(true);
        isAnimating_coins = false;
    
}

    IEnumerator coinCollection()
    {
       int initialCoins = 0;
       while(initialCoins < collectedCoins_Value) 
       {
        initialCoins++;
        collected_Coins.text = initialCoins.ToString();
        yield return new WaitForSeconds(0.005f);

       }
    }
    public void LevelComplete_Sound()
    {
      audioSource.clip = applause;
      audioSource.Play();

    }
    IEnumerator delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        yield break;
    }
    IEnumerator animateCoins()
    {
        while(isAnimating_coins)
        {
            for(int i=0;i < animated_coins.Length; i++)
            {
                LeanTween.moveLocal(animated_coins[i],animated_coins_targetPosition.localPosition,coin_duration).setEaseOutElastic();
                yield return new WaitForSeconds(.1f);
            }
             for(int i=0;i < animated_coins.Length; i++)
            {
                animated_coins[i].transform.localPosition = Vector3.zero;
            }
        }

            
    }
    void animateCoins_Func()
    {
        StartCoroutine(animateCoins());
    }
}
