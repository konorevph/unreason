using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Starting : MonoBehaviour
{
    public GameObject doorToCloseObject;
    public GameObject[] lightObjects;

    public GameObject doorToOpenObject;
    public GameObject flashlightObject;
    public Monster monster;
    
    private Door doorToClose;
    private Door doorToOpen;
    private LightSource[] LightSources;
    private LightSource flashlight;

    void Start()
    {
        doorToClose = doorToCloseObject.GetComponent<Door>();
        doorToOpen = doorToOpenObject.GetComponent<Door>();
        LightSources = new LightSource[lightObjects.Length];
        for (int i = 0; i < lightObjects.Length; i++)
        {
            LightSource lightSource = lightObjects[i].GetComponent<LightSource>();
            LightSources[i] = lightSource;
        }
        flashlight = flashlightObject.GetComponent<LightSource>();
        
        doorToClose.PartiallyOpen(20f);
        if (monster)
        {
            monster.MoveToPoint(this.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartScript();
        }
    }

    private void StartScript()
    {
        if (doorToClose != null)
        {
            doorToClose.Close();
        }

        foreach (var lightSource in LightSources)
        {
            lightSource.Off();
        }

        if (flashlight != null)
        {
            flashlight.On();
        }

        if (doorToOpen != null)
        {
            doorToOpen.PartiallyOpen(30f);
        }
        
        Destroy(gameObject);
    }
}
