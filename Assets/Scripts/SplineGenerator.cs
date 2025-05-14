using UnityEngine;
using UnityEngine.Splines;

public class SplineGenerator : MonoBehaviour
{
    public GameObject t_spline,s_spline;
    Spline spline1;
    Spline spline2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spline spline1 = t_spline.GetComponent<Spline>();
        SplineContainer spline2 = s_spline.GetComponent<SplineContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void splineConnector()
    {
        
    }
}
