using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret ()
    {
        Debug.Log("Crusader Selected");
        buildManager.SetTurretToBuild(buildManager.Crusader);
    }

    public void PurchasedAnotherTurret()
    {
        Debug.Log("A different Turret built");
        //buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }

}
