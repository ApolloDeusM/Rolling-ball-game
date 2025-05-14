using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public float increment = 0.01f; // Small incremental value
    public GameObject Object;
    private Vector3 initialPos;
    public Vector3 finalPos;
    private float fullDistance;
    public AnimationCurve animationCurve;

    void Start()
    {
        initialPos = Object.transform.localPosition;
        finalPos = new Vector3(100, 0, 0);
        fullDistance = Vector3.Distance(initialPos, finalPos);
    }

    // Coroutine to move the object smoothly to the right
    public void ToRight()
    {
        StartCoroutine(MoveToRightCoroutine());
    }

    private System.Collections.IEnumerator MoveToRightCoroutine()
{
    float progress = 0f;

    while (progress <= 1f)
    {
        progress += increment * Time.deltaTime; // Dynamic increment
        Object.transform.localPosition = Vector3.Lerp(initialPos, finalPos, animationCurve.Evaluate(progress));
        yield return null; // Wait for the next frame
    }
}

    // Reset object to its initial position
    public void ResetPosition()
    {
        Object.transform.localPosition = initialPos;
    }
}