using System;
using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class BallController : MonoBehaviour
{
   
    [SerializeField] private float rollingSpeed = 5f,particleThreshold; // Constant speed
    public float Targetspeed,rollFactor;
    public ParticleSystem particleSystem_;
    public ParticleSystemRenderer psRenderer;
    public CoinManager coinManager;
    public GameObject Camera,PlayerLeader;
    public GameObject LevelComplete,Nothanks_LC,Nothanks_LF;
    public ballCounter ballCounter;
    public bool isPlaying;
    private bool isRolling = false;
    public float cameraOffset_y,cameraOffset_z;
    public bool levelDone;
    int collectedCoins;
    public TextMeshProUGUI nothanks_LC,nothanks_LF;
   
    public TextMeshProUGUI collected_Coins,topleftLevelname,completedLevel;
    public Shopmanager shopmanager;


    void Start()
    {
        psRenderer.material.color = Color.green;
        //Camera.transform.position = shopmanager.PlayerPoint;
        nothanks_LC = Nothanks_LC.GetComponent<TextMeshProUGUI>();
        nothanks_LC.color = new Color(1,1,1,0);

        nothanks_LF = Nothanks_LF.GetComponent<TextMeshProUGUI>();
        nothanks_LF.color = new Color(1,1,1,0);
        Debug.Log("Level " + GameDataManager.Instance.playerData.currentLevel);
        collected_Coins.text = 0.ToString();
        levelDone = false;
        // Ensure the Rigidbody is assigned
        
        isPlaying = false;
    }

    void Update()
    {
         Camera.transform.SetParent(PlayerLeader.transform);
        gameObject.transform.position = PlayerLeader.transform.position;
        if(isPlaying)
        {
            // Camera.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+cameraOffset_y,gameObject.transform.position.z - cameraOffset_z);
            // Camera.transform.LookAt(gameObject.transform);
            // Debug.Log("Camera is following the ball");
        }
        else
        {
           // Camera.transform.position = shopmanager.PlayerPoint;
           gameObject.transform.position = new Vector3(0,-1.1269f,0);
        }

        
        // Check if the space key is pressed
       
         if (Input.GetAxis("Vertical") > 0 && isPlaying)
        {
           PlayerLeader.transform.Translate(0,0, rollingSpeed * Time.deltaTime);
           gameObject.transform.Rotate(rollFactor*rollingSpeed * Time.deltaTime,0,0);
           particleSystem_.Play();
        //    Camera.transform.LookAt(gameObject.transform);
        }
        else
        {
            particleSystem_.Stop();
        }


          if (Input.GetAxis("Horizontal") > 0 && isPlaying)
        {
            PlayerLeader.transform.Rotate(0,Targetspeed*Time.deltaTime,0,Space.World);
           
            // Camera.transform.LookAt(gameObject.transform);
        }
        else if (Input.GetAxis("Horizontal") < 0 && isPlaying)
        {
           PlayerLeader.transform.Rotate(0,-Targetspeed*Time.deltaTime,0,Space.World);
        //    Camera.transform.SetParent(PlayerLeader.transform);
        //    Camera.transform.LookAt(gameObject.transform);
        }
        else
        {
            //Camera.transform.SetParent(null);
        }
       
        
    }

    // void FixedUpdate()
    // {
    //     if(isPlaying)
    //     {
    //         topleftLevelname.text = "Level " + GameDataManager.Instance.playerData.currentLevel.ToString();
    //        /* Camera.transform.SetParent(gameObject.transform);
    //         Camera.transform.localPosition = Vector3.zero;
    //         Camera.transform.localRotation = Quaternion.identity;*/
    //         float currentSpeed = rb.linearVelocity.z;
    //     // Apply constant force to make the ball roll
    //     if (isRolling && currentSpeed < Targetspeed)
    //     {
    //         rb.AddForce(Vector3.forward *rollingSpeed*Time.fixedDeltaTime,ForceMode.Force);
    //     }
    //     else if(currentSpeed>Targetspeed)
    //     {
    //         Vector3 clampedvelocity = rb.linearVelocity;
    //         clampedvelocity.z = Targetspeed;
    //         rb.linearVelocity = clampedvelocity;
    //     }
    //     else
    //     {
    //         rb.linearVelocity = Vector3.zero; // Stop the ball when space is released
    //     }
    //     }
    //     else
    //     {
    //         return;
    //     }
        
    // }

    public void PlayGame()
    {
        isPlaying = true;
    }
    public void IsnotPlaying()
    {
        isPlaying = false;
    }
    void OnCollisionEnter( Collision collision)
    {


        // You can add specific logic here
        if (collision.gameObject.CompareTag("Finish") && isPlaying)
        {
            LevelComplete.SetActive(true);
            coinManager.LevelComplete_Sound();
            StartCoroutine(CoinrampUp());
            StartCoroutine(display_Nothanks_LC());
            levelDone = true;
            isPlaying = false;
            completedLevel.text = "LEVEL " + GameDataManager.Instance.playerData.currentLevel.ToString();
        }
    }
    IEnumerator CoinrampUp()
    {
       collectedCoins = 0;
       while(collectedCoins < coinManager.collectedCoins_Value) 
       {
        collectedCoins++;
        collected_Coins.text = collectedCoins.ToString();
        yield return new WaitForSeconds(0.005f);

       }
       yield break;
    }
    IEnumerator display_Nothanks_LC()
    {
        yield return new WaitForSeconds(2);
        
        float alpha = 0;
        nothanks_LC.color = new Color(1,1,1,alpha);
        while(alpha < 1)
        {
            alpha += 0.01f;
            nothanks_LC.color = new Color(1,1,1,alpha);
            yield return null;
        }
        Debug.Log("coroutine ran");
    }

    public IEnumerator display_Nothanks_LF()
    {
        yield return new WaitForSeconds(2);
        
        float alpha = 0;
        nothanks_LF.color = new Color(1,1,1,alpha);
        while(alpha < 1)
        {
            alpha += 0.01f;
            nothanks_LF.color = new Color(1,1,1,alpha);
            yield return null;
        }
        Debug.Log("coroutine ran");
    }

    public void rotateball()
    {
        StartCoroutine(rotateActiveBall());
    }

    public void rotateBall_stop()
    {
        StopCoroutine(rotateActiveBall());
        gameObject.transform.rotation = Quaternion.identity;
    }

    public IEnumerator rotateActiveBall()
    {
        
        while(!isPlaying)
      {
        gameObject.transform.Rotate(0,20*Time.deltaTime,0,Space.World);
        yield return null;
        Debug.Log($"ball rotating and angle is {gameObject.transform.localEulerAngles.y}");
      }   
        
    }

    public void RestartLevel()
    {
        gameObject.transform.position = new Vector3(0,2,0);
        //StartCoroutine(ballCounter.RestartLevel_Cor());
    }

    

}