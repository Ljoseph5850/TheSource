using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundEntrance : MonoBehaviour
{
    public string insideGameLevel;
    public float raycastDistance = 5f;
    public LayerMask playerLayer;
    private bool isPlayerNear = false;

    void Update()
    {
        CheckPlayerInRange();
        if (isPlayerNear && Input.GetKeyDown(KeyCode.UpArrow)) // Assuming 'E' is the interact key
        {
            LoadLevel();
        }
    }

    void CheckPlayerInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, playerLayer);
        isPlayerNear = hit.collider != null;
    }

    public void LoadLevel () {
        SceneManager.LoadScene(insideGameLevel);
    }
}
