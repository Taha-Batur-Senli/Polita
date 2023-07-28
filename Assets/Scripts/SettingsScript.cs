using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] public GameObject[] renNames;
    [SerializeField] public GameObject[] nonRenNames;
    [SerializeField] public GameObject listRenewable;
    [SerializeField] public GameObject listNonRenewable;
    [SerializeField] public GameObject textRenewable;
    [SerializeField] public GameObject textNonRenewable;
    [SerializeField] public GameObject switchButton;
    [SerializeField] public GameObject codexHeader;

    // Start is called before the first frame update
    void Start()
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("Language.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("Language");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            if (mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                textRenewable.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/textRenewable").InnerText.Trim();
                textNonRenewable.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/textNonRenewable").InnerText.Trim();
                switchButton.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/switchButton").InnerText.Trim();
                codexHeader.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/codexHeader").InnerText.Trim();

                for (int x = 1; x < 7; x++)
                {
                    renNames[x - 1].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/R" + "plantname" + x).InnerText.Trim();
                    nonRenNames[x - 1].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/NR" + "plantname" + x).InnerText.Trim();
                }
            }
            else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                textRenewable.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/textRenewable").InnerText.Trim();
                textNonRenewable.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/textNonRenewable").InnerText.Trim();
                switchButton.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/switchButton").InnerText.Trim();
                codexHeader.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/codexHeader").InnerText.Trim();

                for (int x = 1; x < 7; x++)
                {
                    renNames[x - 1].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/R" + "plantname" + x).InnerText.Trim();
                    nonRenNames[x - 1].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/NR" + "plantname" + x).InnerText.Trim();
                }
            }
        }
    }
}
