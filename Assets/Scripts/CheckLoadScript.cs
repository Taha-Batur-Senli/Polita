using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckLoadScript : MonoBehaviour
{
    [SerializeField] public Button loadButton;
    [SerializeField] public GameObject blocker;

    // Start is called before the first frame update
    void Start()
    {
        loadButton.interactable = false;
        loadButton.enabled = false;
        blocker.SetActive(true);

        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("SaveFile.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("Files");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            if (mydoc.SelectSingleNode("Files/File1/isBeingUsed").InnerText.Trim().Equals("True") || mydoc.SelectSingleNode("Files/File2/isBeingUsed").InnerText.Trim().Equals("True") || mydoc.SelectSingleNode("Files/File3/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                loadButton.interactable = true;
                loadButton.enabled = true;
                blocker.SetActive(false);
            }
        }
    }
}
