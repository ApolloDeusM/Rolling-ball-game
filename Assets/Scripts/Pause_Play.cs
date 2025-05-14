using UnityEngine;

public class Pause_Play : MonoBehaviour
{
    public BallController ballController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        Time.timeScale = 0;
        ballController.isPlaying = false;
    }
    public void Play()
    {
        Time.timeScale = 1;
        ballController.isPlaying = true;
    }
    public void Reset_Timescale()
    {
        Time.timeScale = 1;
        ballController.isPlaying = false;
    }
    public void Menu()
    {

    }
}
