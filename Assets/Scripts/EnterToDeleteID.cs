using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToDeleteID : MonoBehaviour
{
    [SerializeField] public ClearSaveFile deletePopup;
    [SerializeField] public GameObject blocker;
    [SerializeField] public GameObject button;

    private void Start()
    {
        checkButton();
    }

    public void checkButton()
    {
        if (blocker.activeSelf == true)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
    }

    public void setFileID(int id)
    {
        deletePopup.fileID = id;
    }
}
