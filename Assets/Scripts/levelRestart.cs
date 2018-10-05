using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fizzyo;

public class levelRestart : MonoBehaviour {


    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    void Start () {
        //myLoadedAssetBundle = AssetBundle.LoadFromFile("/Assets/Scenes/");
        print(SceneManager.sceneCountInBuildSettings);
       Destroy(FizzyoFramework.Instance);

        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();
        StartCoroutine(Load());
	}

    IEnumerator Load()
    {
        yield return new WaitForSecondsRealtime(1);
        print(Time.time);
        SceneManager.LoadScene("ChillehSnow");
    }
}
/*
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    // Use this for initialization
    void Start()
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Change Scene"))
        {
            Debug.Log("Scene2 loading: " + scenePaths[0]);
            SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
        }
    }
}
*/
