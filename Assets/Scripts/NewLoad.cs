using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLoad : MonoBehaviour
{
    [SerializeField] public int saveID;
    [SerializeField] public GameObject startFade;
    private bool buttonPressed = false;
    float timer = 0;
    float duration = 2f;

    public void confirmLoad()
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
