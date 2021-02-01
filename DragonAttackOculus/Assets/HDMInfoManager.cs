using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HDMInfoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Esta el dispositivo activo: " + XRSettings.isDeviceActive);
        Debug.Log("Nombre del dispositivo: " + XRSettings.loadedDeviceName);

        if (!XRSettings.isDeviceActive)
        {
            Debug.Log("No hay visores conectados!");
        }
        else if (XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD" 
            || XRSettings.loadedDeviceName == "MockHMD" 
            || XRSettings.loadedDeviceName == "MockHMDDisplay" 
            || XRSettings.loadedDeviceName == "MockHMD Display"))
        {
            Debug.Log("Usando " + XRSettings.loadedDeviceName + "!");
        } else
        {
            Debug.Log("Usando el visor " + XRSettings.loadedDeviceName + "!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
