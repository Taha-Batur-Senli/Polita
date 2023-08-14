using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class BeginGame : MonoBehaviour
{
    float timer = 0;
    private bool buttonPressed = true;
    [SerializeField] public GameObject fadeText;
    [SerializeField] public GameObject Ataturk;
    public int id;
    float duration = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("SaveFile.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("Files");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            // These playing params should be set to false while returning to the main menu!!!!
            if (mydoc.SelectSingleNode("Files/File1/playing").InnerText.Trim().Equals("True"))
                id = 1;
            else if (mydoc.SelectSingleNode("Files/File2/playing").InnerText.Trim().Equals("True"))
                id = 2;
            else if (mydoc.SelectSingleNode("Files/File3/playing").InnerText.Trim().Equals("True"))
                id = 3;

            if (int.Parse(mydoc.SelectSingleNode("Files/File" + id + "/turnNumber").InnerText.Trim()) > 0)
            {
                buttonPressed = false;
            }
            else
            {
                fadeText.GetComponent<Animator>().Play("TextAppear");
            }
        }

        XmlDocument mydoc2 = new XmlDocument();
        mydoc2.Load("Language.xml");
        XmlNodeList nodelist2 = mydoc2.SelectNodes("Language");
        nodelist2 = nodelist2[0].ChildNodes;

        if (nodelist2.Count > 0)
        {
            if (mydoc2.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                fadeText.GetComponent<TMP_Text>().text = mydoc2.SelectSingleNode("Language/Turkish/startQuote").InnerText.Trim();
            }
            else if (mydoc2.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                fadeText.GetComponent<TMP_Text>().text = mydoc2.SelectSingleNode("Language/English/startQuote").InnerText.Trim();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            timer += Time.deltaTime;

            if (timer >= duration - 2f)
            {
                Ataturk.GetComponent<Animator>().Play("textAppear");
            }

            if (timer >= duration)
            {
                fadeText.GetComponent<Animator>().Play("textDisappear");
            }

            if (timer >= duration + 0.5f)
            {
                timer = 0;
                buttonPressed = false;
                Ataturk.GetComponent<Animator>().Play("textDisappear");
            }
        }
    }
}
