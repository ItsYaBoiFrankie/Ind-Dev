using UnityEngine;

public class BuildManager : MonoBehaviour {

    //singleton pattern (stores reference to itself)
    public static BuildManager instance;
    private GameObject turretBuild;

    void Awake()
    {
        if(instance != null)
        {
           
        }
        instance = this;
    }

    //Where different turret types go
    public GameObject Crusader;
  

    public GameObject BuildTurret ()
    {
        return turretBuild;
    }
	
	public void SetTurretToBuild (GameObject turret)
    {
        turretBuild = turret;
    }
}
