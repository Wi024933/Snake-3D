using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text LoseText;

    public delegate void UIEventHandler();
    public event UIEventHandler UIEvent;

    public void LoseScreen()
    {
        LoseText.gameObject.SetActive(true);
    }
}
