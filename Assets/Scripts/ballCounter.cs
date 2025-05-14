using System.Collections;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ballCounter : MonoBehaviour
{
    [SerializeField]private GameObject[] ballsleft;
    [SerializeField]private GameObject outofBalls;
    public BallController ballController;
    public CoinManager coinManager;
    public float BlinkIncreement;
    public GameObject warning,OutOfBalls;
    int ballCount;
    bool noBallLeft;
    void Start()
    {
        ballController.nothanks_LF.color = new Color(1,1,1,0);
        noBallLeft = false;
        ballCount = 5;
        outofBalls.SetActive(false);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if(noBallLeft)
    //     {
    //         //StartCoroutine(warningEdge());
    //     }
    // }
    // public void onPlayerDead()
    // {
    //     StartCoroutine(CountBallsLeft());
        
    // }
    //  IEnumerator CountBallsLeft()
    //  {
    //     yield return new WaitForSeconds(3);
    //     for(int i =0; i< ballsleft.Length && ballController.isPlaying; i++)
    //     {
    //         ballsleft[4-i].SetActive(false);
    //         yield return new WaitForSeconds(3);
    //         ballCount--;
    //         if(ballController.levelDone)
    //     {
    //         break;
    //     }
    //     }
    //     if(!ballController.levelDone)
    //     {
    //         outofBalls.SetActive(true);
    //         yield return StartCoroutine(ballController.display_Nothanks_LF());
    //     }
    //     else
    //     {
    //         outofBalls.SetActive(false);
    //     }
    //     noBallLeft = true;
    //  }

    // public void RestartLevel()
    // {
    //     StartCoroutine(RestartLevel_Cor());
    // }
    // public IEnumerator RestartLevel_Cor()
    // {
    //     coinManager.Advertisement.SetActive(true);
    //     yield return new WaitForSeconds(3);
    //     OutOfBalls.SetActive(false);
    //     ballController.isPlaying = true;
    //     coinManager.Advertisement.SetActive(false);
        
    //     for(int i =0; i< ballsleft.Length && ballController.isPlaying; i++)
    //     {
    //         ballsleft[i].SetActive(true);
    //         yield return new WaitForSeconds(0.1f);  
    //     }
    //     yield return StartCoroutine(CountBallsLeft());
    // }
}
