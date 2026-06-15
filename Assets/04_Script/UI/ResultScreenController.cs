using UnityEngine;
using TMPro;

public class ResultScreenController : MonoBehaviour
{
    //Reference
    public GameObject ResultScreen;

    //Events

    //Result Info

    //Private Variables
    private void Awake()
    {
        Hide();
    }
    public void Show()
    {

    }

    public void Hide()
    {
        ResultScreen.SetActive(false);
    }
}
