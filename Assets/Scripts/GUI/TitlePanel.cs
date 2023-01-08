using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePanel : MonoBehaviour
{
    public static string LEVEL = "LEVEL";
    public Text titleText;

    public void UpdateTitle(string text)
    {
        titleText.text = text;
    }
}
