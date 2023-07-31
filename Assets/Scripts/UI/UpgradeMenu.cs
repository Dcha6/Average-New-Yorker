using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject upgradeMenuUI;
    public GameObject playerObject;

    void Start()
    {
        
    }

    void Update()
    {
        Player player = playerObject.GetComponent<Player>();
        if (player.isUpgrading == true) 
        {
            Pause();
        }
    }

    public void Resume()
    {
        Player player = playerObject.GetComponent<Player>();
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        player.isUpgrading = false;
    }

    void Pause()
    {
        upgradeMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
