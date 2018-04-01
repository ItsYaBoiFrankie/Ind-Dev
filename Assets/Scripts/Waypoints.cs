using UnityEngine;

public class Waypoints : MonoBehaviour {

    //public static so it can be accessed from anywhere
    public static Transform[] wp;

    //Load all children waypoints into the waypoints array
    void Awake()
    {
        wp = new Transform[transform.childCount];
        for (int i = 0; i < wp.Length; i++)
        {
            wp[i] = transform.GetChild(i);
        }
    }
}
