using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret ()
    {
        Debug.Log("Standard Turret built");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchasedAnotherTurret()
    {
        Debug.Log("A different Turret built");
        //buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }

}
