using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] ballLocks;
    public GameObject[] ballShops;
    public bool[] isPurchasedBall;
    public Settings settings;
    public GameObject[] ballPrices,ballCoins;
    public Material[] ballMaterials;
    MeshRenderer BallMaterial;
    public GameObject notEnough_Coins;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BallMaterial = gameObject.GetComponent<MeshRenderer>();
        BallMaterial.material = ballMaterials[0];

       foreach(var locks in ballLocks)
       {
        locks.SetActive(true);
       }
       foreach(var balls in ballShops)
       {
        balls.SetActive(true);
       }
       for(int i=0; i< isPurchasedBall.Length; i++)
       {
        isPurchasedBall[i] = false;
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void select_Ball1()
    {
       
        BallMaterial.material = ballMaterials[0];
       
    }

    public void select_Ball2()
    {
        
        BallMaterial.material = ballMaterials[1];
       
    }

     public void select_Ball3()
    {
        
        BallMaterial.material = ballMaterials[2];
        
    }
    
    public void buy_Ball1()
    {
        if(!isPurchasedBall[0])
        {
            if(GameDataManager.Instance.playerData.coins > 400)
        {
            ballLocks[0].SetActive(false);
            ballCoins[0].SetActive(false);
            TextMeshProUGUI tag = ballPrices[0].GetComponent<TextMeshProUGUI>();
            ballPrices[0].transform.localPosition = new Vector3(0,0,0);
            tag.text = "PURCHASED";
            tag.fontSize = 25;
            isPurchasedBall[0] = true;
            GameDataManager.Instance.UpdateCoins(-400);
        }
        else
        {
            notEnough_Coins.SetActive(true);
            StartCoroutine(settings.ToggleUI_panel(settings.out_ofCoins,true));
        }
        }
    }

    public void buy_Ball2()
    {
        if(!isPurchasedBall[1])
        {
            if(GameDataManager.Instance.playerData.coins > 400)
        {
            ballLocks[1].SetActive(false);
            ballCoins[1].SetActive(false);
            TextMeshProUGUI tag = ballPrices[1].GetComponent<TextMeshProUGUI>();
            ballPrices[1].transform.localPosition = new Vector3(0,0,0);
            tag.text = "PURCHASED";
            tag.fontSize = 25;
            isPurchasedBall[1] = true;
            GameDataManager.Instance.UpdateCoins(-400);
        }
        else
        {
            notEnough_Coins.SetActive(true);
            StartCoroutine(settings.ToggleUI_panel(settings.out_ofCoins,true));
        }
        }
    }

    public void buy_Ball3()
    {
        if(!isPurchasedBall[2])
        {
            if(GameDataManager.Instance.playerData.coins > 400)
        {
            ballLocks[2].SetActive(false);
            ballCoins[2].SetActive(false);
            TextMeshProUGUI tag = ballPrices[2].GetComponent<TextMeshProUGUI>();
            ballPrices[2].transform.localPosition = new Vector3(0,0,0);
            tag.text = "PURCHASED";
            tag.fontSize = 25;
            isPurchasedBall[2] = true;
            GameDataManager.Instance.UpdateCoins(-400);
        }
        else
        {
            notEnough_Coins.SetActive(true);
            StartCoroutine(settings.ToggleUI_panel(settings.out_ofCoins,true));
        }
        }
    }
}
