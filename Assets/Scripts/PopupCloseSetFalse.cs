using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCloseSetFalse : MonoBehaviour
{
    float timer = 0;
    [SerializeField] public bool buttonPressed = false;
    public GameObject popup;
    float duration = 1.05f;

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                timer = 0;
                buttonPressed = false;
                popup.SetActive(false);
            }
        }
    }

    public void pressButton()
    {
        buttonPressed = true;
    }
}
