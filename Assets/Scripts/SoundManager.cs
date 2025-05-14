using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip[] audioClips;
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClick()
    {
        audiosource.clip = audioClips[0];
        audiosource.Play();
    }

    public void Navigation()
    {
        audiosource.clip = audioClips[1];
        audiosource.Play();
    }
    
    public void OutofBalls()
    {
        audiosource.clip = audioClips[3];
        audiosource.Play();
    }
    public void Play()
    {
        audiosource.clip = audioClips[4];
        audiosource.Play();
    }
}
