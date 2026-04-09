using UnityEngine;

public class MenuTabs : MonoBehaviour
{
    public GameObject panelRules;
    public GameObject panelControls;

    public void ShowRules()
    {
        panelRules.SetActive(true);
        panelControls.SetActive(false);
    }

    public void ShowControls()
    {
        panelRules.SetActive(false);
        panelControls.SetActive(true);
    }
}