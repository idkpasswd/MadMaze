using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Include this for scene management, like reloading or changing scenes

public enum eNodeState
{
    Available,
    Current,
    Completed
}

public class eMazeNode : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    [SerializeField] MeshRenderer floor;

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            EndGame();
        }
    }

    public void RemoveWall(int wallToRemove)
    {
        walls[wallToRemove].gameObject.SetActive(false);
    }

    public void SetState(eNodeState state)
    {
        switch (state)
        {
            case eNodeState.Available:
                floor.material.color = Color.white;
                break;
            case eNodeState.Current:
                floor.material.color = Color.yellow;
                break;
            case eNodeState.Completed:
                floor.material.color = Color.white;
                break;
        }
    }

    private void EndGame()
    {
        // Logic for ending the game
        Debug.Log("Game Over! You've reached the destination!");
        // Optional: Reload the scene or load a different one
        // SceneManager.LoadScene("YourSceneName");
    }
}
