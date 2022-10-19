using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SdkYandex : MonoBehaviour
{
    private IEnumerator Start()
    {
#if UNITY_WEBGL || !UNITY_EDITOR

        yield return YandexGamesSdk.Initialize();

        InterstitialAd.Show();
#endif
        SceneManager.LoadScene(1);
        yield break;
    }
}
