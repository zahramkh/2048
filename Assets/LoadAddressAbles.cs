
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class LoadAddressAbles : MonoBehaviour
{
    //Intatiate GameObject
    public string prefabAdress = "MyCube";

    //Load Sprite
    public string SpriteAdress = "MySprite";
    public SpriteRenderer spriteRenderer;

    //LoadScene
    public string scene = "Sample";
    void Start()
    {
            Addressables.InstantiateAsync(prefabAdress).Completed += OnCubeLoade;

            Addressables.LoadAssetAsync<Sprite>(SpriteAdress).Completed += OnSpriteLoad;
    }
    void OnCubeLoade(AsyncOperationHandle<GameObject>handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded) 
        
        {
            Debug.Log("GameObject Created");
        }
        else
        {
            Debug.Log("Faild");

        }
    }
    void OnSpriteLoad(AsyncOperationHandle<Sprite> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded) {

            spriteRenderer.sprite = handle.Result;
            Debug.Log("sprite Loaded");

        }
        else
        {
            Debug.Log("Faild");
        }
    }
    public void LoadScene()
    {
        Addressables.LoadSceneAsync(scene);
    }
}
