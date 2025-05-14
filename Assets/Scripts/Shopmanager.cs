
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shopmanager : MonoBehaviour
{
    [SerializeField] private GameObject balls_worlds,Shop;
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] AnimationCurve animationCurve;
    //[SerializeField] Image leftButton;
    //[SerializeField] Image rightButton;
    [SerializeField] GameObject ballsHighlighter,worldsHighlighter,trailHighlighter;
    [SerializeField] Image ballsColor,worldsColor,trailColor;
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject Player,PlayerRoot;
    public BallController ballController;
    private Vector3 ballPosition;
    private Vector3 worldPosition;
    private Vector3 trailPosition;
    public float CameraDuration;
    [SerializeField] float increement = 0.01f;
    public bool is_onBalls,is_onWorlds,is_onTrails,is_Shopping;
    public Vector3 PlayerAngle,ShoppingAngle,PlayerPoint,ShoppingPoint,worldView;
    void Start()
    {
        ballPosition  = new Vector3(0,0,0);
        worldPosition  = new Vector3(-1200,0,0);
        trailPosition = new Vector3(-2400,0,0);
        MainCamera.transform.position = PlayerPoint;
        MainCamera.transform.localEulerAngles = PlayerAngle;

        balls_worlds.transform.localPosition = ballPosition;
        Title.text = "Balls";

        is_onBalls = true;
        is_onWorlds = false;
        is_onTrails = false;

        //rightButton.color = new Color(1f,1f,1f,1f);
        //leftButton.color = new Color(1f,1f,1f,0.118f);

        ballsColor.color = new Color(0.369f,0.169f,0.643f,1f);
        worldsColor.color = new Color(1f,1f,1f,1f);
        trailColor.color = new Color(1f,1f,1f,1f);

        ballsHighlighter.transform.localScale = new Vector3(1f,1f,1f);
        worldsHighlighter.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
        trailHighlighter.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
        is_Shopping = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(MainCamera.transform.position);
        if(is_onWorlds || is_onTrails)
        {
            MainCamera.transform.SetParent(Player.transform);
            MainCamera.transform.LookAt(PlayerRoot.transform);
            LeanTween.moveLocal(MainCamera,worldView,CameraDuration).setEaseLinear();

        }
        else
        {
            if(is_Shopping)
            {
                // ballController.gameObject.transform.position = new Vector3(0,-1.1269f,0);
                LeanTween.moveLocal(MainCamera,ShoppingPoint,CameraDuration).setEaseLinear();
                MainCamera.transform.SetParent(null);
                MainCamera.transform.localEulerAngles = ShoppingAngle;
            }
            
            else
            {
                LeanTween.moveLocal(MainCamera,PlayerPoint,CameraDuration).setEaseLinear();
                MainCamera.transform.SetParent(null);
                MainCamera.transform.localEulerAngles = PlayerAngle;
            }
         }   
    }
    public void onBalls()
    {
        if(!is_onBalls)
        {
        worldsHighlighter.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
        trailHighlighter.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
    
       // rightButton.color = new Color(1f,1f,1f,1f);
        //leftButton.color = new Color(1f,1f,1f,0.118f);

        ballsColor.color = new Color(0.369f,0.169f,0.643f,1f);
        worldsColor.color = new Color(1f,1f,1f,1f);
        trailColor.color = new Color(1f,1f,1f,1f);

        if(is_onWorlds)
        {
            StartCoroutine(swapShops(worldPosition,ballPosition,ballsHighlighter));
            
        }
        else
        {
            StartCoroutine(swapShops(trailPosition,ballPosition,ballsHighlighter));
        }
        
        Title.text = "Balls";
          
        is_onBalls = true;
        is_onWorlds = false;
        is_onTrails = false;
        }
        else
        {
            return;
        }
        
    }
    public void onWorlds()
    {
        
        if(!is_onWorlds)
        {
        ballsHighlighter.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
        trailHighlighter.transform.localScale = new Vector3(0.7f,0.7f,0.7f);

       // leftButton.color = new Color(1f,1f,1f,1f);
       // rightButton.color = new Color(1f,1f,1f,1f);

        ballsColor.color = new Color(1f,1f,1f,1f);
        worldsColor.color = new Color(0.369f,0.169f,0.643f,1f);
        trailColor.color = new Color(1f,1f,1f,1f);
        if(is_onBalls)
        {
            StartCoroutine(swapShops(ballPosition,worldPosition,worldsHighlighter));
        }
        else
        {
            StartCoroutine(swapShops(trailPosition,worldPosition,worldsHighlighter));
        }
        Title.text = "Worlds";

        is_onBalls = false;
        is_onWorlds = true;
        is_onTrails = false;
        }
        else
        {
            return;
        }
        
    }

     public void onTrails()
    {
        if(!is_onTrails)
        {
        ballsHighlighter.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
        worldsHighlighter.transform.localScale = new Vector3(0.7f,0.7f,0.7f);

        //leftButton.color = new Color(1f,1f,1f,1f);
        //rightButton.color = new Color(1f,1f,1f,0.118f);

        ballsColor.color = new Color(1f,1f,1f,1f);
        worldsColor.color = new Color(1f,1f,1f,1f);
        trailColor.color = new Color(0.369f,0.169f,0.643f,1f);
        if(is_onBalls)
        {
            StartCoroutine(swapShops(ballPosition,trailPosition,trailHighlighter));
        
        }
        else
        {
            StartCoroutine(swapShops(worldPosition,trailPosition,trailHighlighter));
        }
        
        Title.text = "Trails";

        is_onBalls = false;
        is_onWorlds = false;
        is_onTrails = true;
        } 
        else
        {
            return;
        }
    }
    public void ShoppingView()
    {
        //ballController.Camera.transform.position = PlayerPoint;
    //   StopCoroutine(shoppingCamera(ShoppingAngle, PlayerAngle, ShoppingPoint, PlayerPoint));
      is_Shopping = true;
    //   StartCoroutine(shoppingCamera(PlayerAngle,ShoppingAngle,PlayerPoint,ShoppingPoint));
      LeanTween.moveLocal(MainCamera,ShoppingPoint,CameraDuration).setEaseLinear();
    //   MainCamera.transform.localPosition = ShoppingPoint;
      MainCamera.transform.localEulerAngles = ShoppingAngle;
    }

    public void isNotShopping()
{   
    is_onWorlds = false;
    is_Shopping = false;
    MainCamera.transform.SetParent(null);
     LeanTween.moveLocal(MainCamera,PlayerPoint,CameraDuration).setEaseLinear();
    // StopCoroutine(shoppingCamera(PlayerAngle,ShoppingAngle,PlayerPoint,ShoppingPoint));
    // Debug.Log("isNotShopping called");
    // Debug.Log("Stopped ball rotation");
    // StartCoroutine(shoppingCamera(ShoppingAngle, PlayerAngle, ShoppingPoint, PlayerPoint));
    // Debug.Log("Camera returning to player view");
    Shop.SetActive(false);
    // Debug.Log("Shop UI hidden");
    LeanTween.moveLocal(MainCamera,PlayerPoint,CameraDuration).setEaseLinear();
    // MainCamera.transform.localPosition = PlayerPoint;
    MainCamera.transform.localEulerAngles = PlayerAngle;
}
    IEnumerator swapShops(Vector3 startPoint, Vector3 endPoint, GameObject tabHighlighter)
    {
        float progress = 0f;
        while(progress <= 1)
        {
            progress += increement*Time.deltaTime;
            balls_worlds.transform.localPosition = Vector3.Lerp(startPoint,endPoint,animationCurve.Evaluate(progress));
            tabHighlighter.transform.localScale = Vector3.Lerp(new Vector3(0.7f,0.7f,0.7f),new Vector3(1,1,1),animationCurve.Evaluate(progress));
            yield return null;
        }
    }
    IEnumerator shoppingCamera(Vector3 startOrientation, Vector3 endOrientation, Vector3 startPoint, Vector3 endPoint)
    {
        float progress = 0f;
        while(progress <= 1)
        {
            progress += increement*Time.deltaTime;
            MainCamera.transform.localPosition = Vector3.Lerp(startPoint,endPoint,animationCurve.Evaluate(progress));
            MainCamera.transform.localEulerAngles = Vector3.Lerp(startOrientation,endOrientation,animationCurve.Evaluate(progress));
            yield return null;
        }
        is_Shopping = true;
    }
    
}
