using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public Canvas canvas;
    public GameObject player;
    public LayerMask layerMask;

    public float maxDistance;
    public float speed;

    public float targetTime = 2f;
    float timer;
    bool isCounting;
    bool isLoading = false;

    bool cameraMoveEnable = false;
    Transform targetTransform;

    void Update()
    {
        if(cameraMoveEnable)
        {
            // this.transform.position = Vector3.Lerp(transform.position, targetTransform.position, speed * Time.deltaTime);
            this.transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
            this.transform.rotation = Quaternion.Lerp(transform.rotation, targetTransform.rotation, speed * Time.deltaTime);

            if(Vector3.Distance(this.transform.position, targetTransform.position) < 0.01f
                && Quaternion.Angle(this.transform.rotation, targetTransform.rotation) < 0.01f && isCounting)
            {
                timer += Time.deltaTime;
                canvas.transform.Find("GameOver").GetComponent<CanvasGroup>().alpha = timer / targetTime;
                
                if (canvas.transform.Find("GameOver").GetComponent<CanvasGroup>().alpha >= 1 && isLoading == false)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    SceneManager.LoadScene("MainMenu");
                    isLoading = true;
                }
            }
        }
    }

    public void EndGame()
    {
        timer = 0f;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            if(hit.collider.gameObject.name == "Paper")
            {
                // Disable player control
                player.SetActive(false);
                this.GetComponent<PlayerCam>().enabled = false;

                // Move camera to target position(Zoom in)
                targetTransform = hit.collider.gameObject.transform.Find("targetPosition").transform;
                cameraMoveEnable = true;

                // Fade to black
                isCounting = true;
            }
        }
    }
}
