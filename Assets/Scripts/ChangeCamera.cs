using UnityEngine;
using Cinemachine;
using System;
using System.Collections;

public class TriggerHandler : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCameras;
    public GameObject chart;
    public GameObject nameHorse;
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < ChartController.instance.horseControllers.Count; i++)
        {
            if (other.transform == ChartController.instance.horseControllers[i].transform)
            {
                virtualCameras.gameObject.SetActive(true);
                chart.SetActive(true);
                nameHorse.SetActive(true);
                Time.timeScale = 0.3f;
                StartCoroutine(WaitForSlow());
                break;
            }
        }
    }
    IEnumerator WaitForSlow()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 1f;
        virtualCameras.gameObject.SetActive(false);
    }
}
