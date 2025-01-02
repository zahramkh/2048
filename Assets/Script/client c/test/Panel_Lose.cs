using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Panel_Lose : Popup
{
    [SerializeField] private TextMeshProUGUI textlose;
    [SerializeField] private TextMeshProUGUI score;
    public string scene = "MainMenu";

    public void Setup(string lose, string scoret)
    {
        if (textlose != null)
        {
            textlose.text = lose;

        }
        if (score != null)
        {
            score.text = scoret;

        }
    }
    public void LoadScene()
    {
        Addressables.LoadSceneAsync(scene);
    }
}
