using UnityEngine;
//to ensure shop UI meshes with rest of game
using UnityEngine.EventSystems;

//Handles user input on node, and is responsible for if anything is built on it


public class Node : MonoBehaviour {

    public Color hoverColor;
    //When turret is built, ensures it lays above the node tile
    public Vector3 positionOffset;

    private GameObject turret;

    //colors for selected and unselected
    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        //stores Renderer once so code can just call variable
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        //Makes sure UI doesn't preform actions while over game world
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //Build turret on node tile only if turret has been selected already from menu
        if (buildManager.BuildTurret() == null)
        {
            return;
        }
        //If there is something built on the tile (Node)
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on Screen");
            return;
        }

        //part of the singleton pattern(in BuildManager)
        GameObject turretToBuild = buildManager.BuildTurret();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    // Called when the mouse is hovered over the tile
    void OnMouseEnter()
    {
        //Makes sure UI doesn't preform actions while over game world
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //Highlight node tile only if a turret was selected to be built from menu
        if (buildManager.BuildTurret() == null)
        {
            return;
        }
        //sets a color to indicate the tile is selected (highlighted)
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
