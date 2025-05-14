using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject musicButton,soundButton,hapticsButton,settingsPanel,noAds_Panel,out_ofCoins;
    [SerializeField] TextMeshProUGUI musictext,soundtext,hapticstext;
    public LeanTweenType leanTweenType;
    [SerializeField] AnimationCurve animationCurve;
    public float scaleIncreement,settingsPanel_duration = 1;
    Image image1,image2,image3;
    bool musicON,soundON,hapticsON;
    void Start()
    {
        settingsPanel.transform.localScale = noAds_Panel.transform.localScale = Vector3.zero;
        out_ofCoins.transform.localScale = Vector3.zero;
        settingsPanel.SetActive(true);
        noAds_Panel.SetActive(true);
        out_ofCoins.SetActive(true);
        musicON = true;
        soundON = true;
        hapticsON = true;

         image1 = musicButton.GetComponent<Image>();
         image2 = soundButton.GetComponent<Image>();
         image3 = hapticsButton.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Toggle music ON/OFF
    public void music_switch()
    {
        if(musicON)
        {
             StartCoroutine(buttonScale(musicButton));
             image1.color = new Color(1f,1f,1f,0.196f);
             musictext.color = new Color(1f,1f,1f,0.196f);
             musicON = false;
        }
        else
        {
            StartCoroutine(buttonScale(musicButton));
             image1.color = new Color(1f,1f,1f,1f);
             musictext.color = new Color(1f,1f,1f,1f);
             musicON = true;
        }
    }
    //Toggle sound ON/OFF
        public void sound_switch()
    {
        if(soundON)
        {
             StartCoroutine(buttonScale(soundButton));
             image2.color = new Color(1f,1f,1f,0.196f);
             soundtext.color = new Color(1f,1f,1f,0.196f);
             soundON = false;
        }
        else
        {
            StartCoroutine(buttonScale(soundButton));
             image2.color = new Color(1f,1f,1f,1f);
            soundtext.color = new Color(1f,1f,1f,1f);
             soundON = true;
        }
    }
    //Toggle haptics ON/OFF
        public void haptics_switch()
    {
        if(hapticsON)
        {
             StartCoroutine(buttonScale(hapticsButton));
             image3.color = new Color(1f,1f,1f,0.196f);
             hapticstext.color = new Color(1f,1f,1f,0.196f);
             hapticsON = false;
        }
        else
        {
            StartCoroutine(buttonScale(hapticsButton));
             image3.color = new Color(1f,1f,1f,1f);
             hapticstext.color = new Color(1f,1f,1f,1f);
             hapticsON = true;
        }
    }

    public void Settings_ON()
    {
        StartCoroutine(ToggleUI_panel(settingsPanel,true));
    }

    public void Settings_OFF()
    {
        StartCoroutine(ToggleUI_panel(settingsPanel,false));
    }

    public void noAds_ON()
    {
        StartCoroutine(ToggleUI_panel(noAds_Panel,true));
    }

    public void noAds_OFF()
    {
        StartCoroutine(ToggleUI_panel(noAds_Panel,false));
    }

    public void outOf_Coins_ON()
    {
        StartCoroutine(ToggleUI_panel(out_ofCoins,true));
    }

    public void outOf_Coins_OFF()
    {
        StartCoroutine(ToggleUI_panel(out_ofCoins,false));
    }

    IEnumerator buttonScale(GameObject button)
    {
        float progress = 0f;
        while(progress <= 1)
        {
            progress += scaleIncreement;
            button.transform.localScale = Vector3.Lerp(new Vector3(1,1,1),new Vector3(1.1f,1.1f,1.1f),animationCurve.Evaluate(progress));
            yield return null;
        }
        progress = 0f;

        while(progress <= 1)
        {
            progress += scaleIncreement;
            button.transform.localScale = Vector3.Lerp(new Vector3(1.1f,1.1f,1.1f),new Vector3(1,1,1),animationCurve.Evaluate(progress));
            yield return null;
        }
    }

    public IEnumerator ToggleUI_panel(GameObject panel,bool ON)
    {
        if(ON)
        {
            panel.SetActive(true);
            LeanTween.scale(panel,Vector3.one,settingsPanel_duration).setEase(leanTweenType);
        }
        else
        {
            LeanTween.scale(panel,Vector3.zero,settingsPanel_duration).setEase(leanTweenType);
            yield break;
        }
    }
}
