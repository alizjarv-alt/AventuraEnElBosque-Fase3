using UnityEngine;

public class HighContrastToggle : MonoBehaviour
{
    public GameObject highContrastVolume;
    public KeyCode toggleKey = KeyCode.H;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            highContrastVolume.SetActive(!highContrastVolume.activeSelf);
        }
    }
}