using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartNewGame : MonoBehaviour
{
    [SerializeField] public int saveID;
    [SerializeField] public Button loadButton;
    [SerializeField] public GameObject warning;
    [SerializeField] public GameObject overwritepopup;
    [SerializeField] public GameObject startFade;
    private bool buttonPressed = false;
    float timer = 0;
    float duration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        warning.SetActive(false);
        overwritepopup.SetActive(false);

        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("SaveFile.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("Files");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            if (mydoc.SelectSingleNode("Files/File" + saveID.ToString() + "/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                warning.SetActive(true);
            }
        }
    }

    public void checkOverwrite()
    {
        if (warning.activeSelf == true)
        {
            overwritepopup.GetComponent<NewLoad>().saveID = saveID;
            overwritepopup.SetActive(true);
            overwritepopup.GetComponent<Animator>().Play("PopupOpen");
        }
        else
        {
            XmlDocument mydoc = new XmlDocument();
            mydoc.Load("SaveFile.xml");
            XmlNodeList nodelist = mydoc.SelectNodes("Files");
            nodelist = nodelist[0].ChildNodes;

            if (nodelist.Count > 0)
            {
                mydoc.SelectSingleNode("Files/File" + saveID.ToString() + "/isBeingUsed").InnerText = "True";
                mydoc.SelectSingleNode("Files/File" + saveID.ToString() + "/playing").InnerText = "True";
                mydoc.Save("SaveFile.xml");
            }


            startFade.SetActive(true);
            startFade.GetComponent<Animator>().Play("Appear");
            buttonPressed = true;

        }
    }

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
                startFade.SetActive(false);
                SceneManager.LoadScene("Gameplay Scene");
            }
        }
    }

}
