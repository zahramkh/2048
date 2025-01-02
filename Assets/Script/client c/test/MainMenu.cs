using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MainMenu : Panel
{
    public string sceneGame = "sceneGame";

    public void PlayGame()
    {
        Addressables.LoadSceneAsync(sceneGame);
    }

    public void QuitGame()
    {
        Debug.Log("The Game Is Closed");
    }

}
