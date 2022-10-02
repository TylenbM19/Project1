using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class Restart : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Player _player;
    [SerializeField] private float _timeRestart;

    private CanvasGroup _canvasGroup;
    private WaitForSeconds _waitForSeconds;

    private void OnEnable()
    {
        _player.CollisionResult += RestartLeval;
    }

    private void OnDisable()
    {
        _player.CollisionResult -= RestartLeval;
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        _waitForSeconds = new WaitForSeconds(_timeRestart);
    }

    private void RestartLeval(bool result)
    {
        if (result)
        {
            _canvasGroup.alpha = 1f;
            StartCoroutine(Name());
        }
    }

    private IEnumerator Name()
    {
            yield return _waitForSeconds;
            SceneManager.LoadScene(0);
    }
}
