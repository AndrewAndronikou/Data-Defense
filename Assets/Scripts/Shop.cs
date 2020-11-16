using UnityEngine;
public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint LaserTurret;
    [SerializeField] GameObject selectedStandard;
    [SerializeField] GameObject selectedMissile;
    [SerializeField] GameObject selectedLaser;
    [SerializeField] int buildCapacityCost = 750;

    BuildManager buildManager;
    MessageLog messageLog;


    [HideInInspector]
    public GameObject temp;

    RaycastHit hit;

    private void Start()
    {
        buildManager = BuildManager.instance;
        messageLog = MessageLog.instance;
    }

    private void Update()
    {
        if (temp == null)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider)
            {
                temp.transform.position = hit.point;
            }
        }
    }

    public void SelectStandardTurret()
    {
        Destroy(temp);
        temp = null;
        buildManager.SelectTurretToBuild(standardTurret);

        temp = (GameObject)Instantiate(selectedStandard, transform.position, Quaternion.identity);
    }

    public void SelectMissileTurret()
    {
        Destroy(temp);
        temp = null;
        buildManager.SelectTurretToBuild(missileLauncher);

        temp = (GameObject)Instantiate(selectedMissile, transform.position, Quaternion.identity);
    }

    public void SelectLaserTurret()
    {
        Destroy(temp);
        temp = null;
        buildManager.SelectTurretToBuild(LaserTurret);

        temp = (GameObject)Instantiate(selectedLaser, transform.position, Quaternion.identity);
    }

    public void IncreaseBuildCapacity()
    {
        if (PlayerStats.Money < buildCapacityCost)
        {
            messageLog.ShowMessage("Not enough money to purchase that");
            return;
        }
        PlayerStats.Money -= buildCapacityCost;
        PlayerStats.BuildCapacity++;
    }
}
