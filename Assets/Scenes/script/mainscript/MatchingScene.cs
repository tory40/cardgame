using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchingScene : MonoBehaviour
{
    public void BattleScene()
    {
        SceneManager.LoadScene("Wait");
    }
}
