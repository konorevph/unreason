using UnityEngine;

public class LightSource : MonoBehaviour
{
    public bool isEnabled = true;
    public AudioSource workLoop;
    private new Light light;
    
    void Start()
    {
        light = this.GetComponentInChildren<Light>();
        if (isEnabled) On();
        else Off();
    }

    public void Off()
    {
        light.enabled = false;
        if (workLoop)
        {
            workLoop.Pause();
        }
    }

    public void On()
    {
        light.enabled = true;
        if (workLoop)
        {
            workLoop.Play();
        }
    }
}
