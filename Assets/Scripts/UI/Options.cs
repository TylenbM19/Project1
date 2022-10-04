using UnityEngine;
using UnityEngine.UI;

public class Options : UI
{  
    [SerializeField] private Slider _volueSound;
    
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
