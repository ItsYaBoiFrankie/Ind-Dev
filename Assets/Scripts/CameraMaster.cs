using UnityEngine;

public class CameraMaster : MonoBehaviour
{

    //pan speed
    public float panSpeed = 30f;
    //Check for edges of the screen for camera panning
    public float panBorderThickness = 10f;

    //Check to make sure camera panning is within level
    private bool inBoundries = true;

    //Control var for camera zoom
    public float minY = 10f;
    public float maxY = 80f;
    //helps determine speed of camera zoom based on scroll
    public float scrollSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        //TODO: Add level boundries for the bool check
        if(!inBoundries)
        {
            return;
        }

        //Checks to see if ___ key is inputted on keyboard by user OR
        //if mouse is at the ___ of the screen
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            //***Easiest way to move obj w/o physiscs system
            //***Vector3.forward is the same as new Vector3 (0f, 0f, 1f)
            //***multiply by time to keep speed of camera movement consistent across varying
            //levels of hardware
            //***Camera obj has two axis. Local (in reference to where the actual camera is
            //pointing) and global (In reference to the position you naturally asume when you
            //are looking at the scene in the manager. --Space.World
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        //backwards
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        //right
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        //left
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        //stores speed of user scroll on mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        //1000 int added in equation because scroll values are small
        pos.y = pos.y - scroll * 1000 * scrollSpeed * Time.deltaTime;
        //posistion Y stays within control var
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

    }
}