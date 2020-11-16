using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] float panSpeed = 20f;
    [SerializeField] float panBorderThickness = 10f;
    [SerializeField] Vector2 panLimit;

    [SerializeField] float scrollSpeed = 20f;
    [SerializeField] float minY = 10f;
    [SerializeField] float maxY = 80f;

    private bool doMovement = true;

    // Update is called once per frame
    void Update () 
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);



        //Vector3 pos = transform.position;

      //  pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        transform.position = pos;
    }
}
