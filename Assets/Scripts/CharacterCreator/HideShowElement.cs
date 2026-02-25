using UnityEngine;

public class HideShowElement : MonoBehaviour
{
    public GameObject target;
    public void Toggle()
    {
        target.SetActive(!target.activeSelf);
    }
}
