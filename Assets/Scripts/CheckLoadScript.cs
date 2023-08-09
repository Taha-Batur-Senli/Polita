using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckLoadScript : MonoBehaviour
{
    [SerializeField] public Button loadButton;
    [SerializeField] public GameObject mainBlocker;
    [SerializeField] public GameObject file1Blocker;
    [SerializeField] public GameObject file2Blocker;
    [SerializeField] public GameObject file3Blocker;

    // Start is called before the first frame update
    void Start()
    {
        checkLoad();
    }

    public void checkLoad()
    {
        loadButton.interactable = false;
        loadButton.enabled = false;
        mainBlocker.SetActive(true);
        file1Blocker.SetActive(true);
        file2Blocker.SetActive(true);
        file3Blocker.SetActive(true);

        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("SaveFile.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("Files");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            if (mydoc.SelectSingleNode("Files/File1/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                loadButton.interactable = true;
                loadButton.enabled = true;
                mainBlocker.SetActive(false);
                file1Blocker.SetActive(false);
            }
            
            if (mydoc.SelectSingleNode("Files/File2/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                loadButton.interactable = true;
                loadButton.enabled = true;
                mainBlocker.SetActive(false);
                file2Blocker.SetActive(false);
            }
            
            if (mydoc.SelectSingleNode("Files/File3/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                loadButton.interactable = true;
                loadButton.enabled = true;
                mainBlocker.SetActive(false);
                file3Blocker.SetActive(false);
            }
        }
    }
}
