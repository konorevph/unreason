using UnityEngine;

public class LightSource : MonoBehaviour
{
    public bool isEnabled = true;
    private new Light light;
    
    void Start()
    {
        light = this.GetComponentInChildren<Light>();
        light.enabled = isEnabled;
    }

    public void Off()
    {
        light.enabled = false;
    }

    public void On()
    {
        light.enabled = true;
    }
}
