using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    [SerializeField] private Image uiElement; // The UI element to blink
    [SerializeField] private float blinkSpeed = 2f; // Speed of blinking

    private Coroutine blinkCoroutine;

    void Start()
    {
        if (uiElement != null)
        {
            // Start blinking
            blinkCoroutine = StartCoroutine(BlinkUI());
        }
    }
    void Update()
    {
        StartCoroutine(BlinkUI());
    }


    IEnumerator BlinkUI()
    {
        while (true) // Keep blinking
        {
            
            float alpha = Mathf.Abs(Mathf.Sin(Time.time * blinkSpeed));
            
            // Apply alpha to the UI element's color
            Color newColor = uiElement.color;
            newColor.a = alpha; // Update alpha
            uiElement.color = newColor;
            Debug.Log(alpha);
            yield return null; // Wait for the next frame
        }
    }

   /* public void StopBlinking()
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;

            // Reset UI element's alpha (optional)
            Color resetColor = uiElement.color;
            resetColor.a = 1f; // Full opacity
            uiElement.color = resetColor;
        }
    }*/
}