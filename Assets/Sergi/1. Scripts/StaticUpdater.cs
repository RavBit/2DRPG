using UnityEngine;

public class StaticUpdater : MonoBehaviour {

	void Update () {
        if (EventManager.GetEvent("Update") != null)
        {
            Debug.Log("UPDATER RUNNING!!");
            EventManager.TriggerEvent("Update");
        }
    }
}
