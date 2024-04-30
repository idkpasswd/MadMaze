using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Include this for scene management, like reloading or changing scenes
using UnityEngine.XR.Interaction.Toolkit;

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
    [SerializeField] private XRBaseController headController; // Reference to the player's XR controller
    [SerializeField] private float arrivalDistance = 1.0f; // Distance to consider "arrival" at the node


    private void Update()
    {
        CheckPlayerDistance();
    }

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

    private void CheckPlayerDistance()
    {
        // Ensure there is a valid head controller assigned
        if (headController != null)
        {
            float distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                              new Vector3(headController.transform.position.x, 0, headController.transform.position.z));
            if (distance <= arrivalDistance)
            {
                EndGame();
            }
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
