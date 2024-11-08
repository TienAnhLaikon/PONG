using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float moveSpeed = 5f;
    private Camera mainCamera;
    private float yMinCamera, yMaxCamera;
    void Start()
    {
        mainCamera = Camera.main;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        yMinCamera = mainCamera.transform.position.y - cameraHeight / 2;
        yMaxCamera = mainCamera.transform.position.y + cameraHeight / 2;
    }
    public void ResetPosition()
    {
        // Đặt lại vị trí player về vị trí gốc (hoặc vị trí bất kỳ mà bạn muốn)
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
        float clampedY = Mathf.Clamp(transform.position.y, yMinCamera + 1f, yMaxCamera - 1f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
