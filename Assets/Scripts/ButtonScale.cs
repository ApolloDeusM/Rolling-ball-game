using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScale : MonoBehaviour
{
    public float scaleIntensity,scaleSpeed;
    float delta;
    public TextMeshProUGUI MenuLevel_name;
    
    void Start()
    {
        MenuLevel_name.text = $"Level {GameDataManager.Instance.playerData.currentLevel} ";
    }

    // Update is called once per frame
    void Update()
    {
        MenuLevel_name.text = $"Level {GameDataManager.Instance.playerData.currentLevel} ";
        delta = scaleIntensity*Math.Abs(Mathf.Sin(scaleSpeed*Time.time));
        gameObject.transform.localScale = new Vector3(1+delta,1+delta,1+delta);
    }

}
