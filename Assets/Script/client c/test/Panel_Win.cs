using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Panel_Win : Panel
{
   [SerializeField] private TextMeshProUGUI textWin ;
   [SerializeField] private TextMeshProUGUI score ;
    public string scene = "MainMenu";

    public void Setup(string win ,string scoret )
    {
        if (textWin != null)
        {
            textWin.text = win;

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
