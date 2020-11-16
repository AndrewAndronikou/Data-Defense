using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Color notEnoughMoney; 
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;
    MessageLog messageLog;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
 
        buildManager = BuildManager.instance;
        messageLog = MessageLog.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
           // messageLog.ShowMessage("Invalid Build Location");
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {    
        if (PlayerStats.Money < blueprint.cost)
        {
            messageLog.ShowMessage("Not enough money to build that");
            return;
        }

        if (PlayerStats.BuildAmount >= PlayerStats.BuildCapacity)
        {
            messageLog.ShowMessage("Turret Capacity Reached");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        PlayerStats.BuildAmount++;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        GameObject buildSoundEffect = (GameObject)Instantiate(buildManager.buildSoundEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildSoundEffect, 3f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            messageLog.ShowMessage("Not enough money to upgrade that");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Remove old turret
        Destroy(turret);

        //Building upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        //Spawn effect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffectUpgraded, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        GameObject buildSoundEffect = (GameObject)Instantiate(buildManager.buildSoundEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildSoundEffect, 3f);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        PlayerStats.BuildAmount--;

        //Spawn effect
        
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        GameObject sellSoundEffect = (GameObject)Instantiate(buildManager.sellSoundEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(sellSoundEffect, 3f);

        Destroy(turret);
        turretBlueprint = null;

        messageLog.ShowMessage("Turret Sold");
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoney;
        }

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
