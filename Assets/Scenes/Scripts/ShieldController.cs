using UnityEngine;

public class ShieldController : MonoBehaviour
{
    //time shield should be deactivated
    public float deactiveTime = 3f;
    private float deactiveTimeDelta = 0f;
    
    private bool isDeactivated = false;

    void Update()
    {
        if (isDeactivated)
        {
            if (deactiveTimeDelta > deactiveTime)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                deactiveTimeDelta = 0f;
                isDeactivated = false;
            }
            else
            {
                deactiveTimeDelta += Time.deltaTime;
            }
        }
    }

    public void deactiveShieldObject()
    {
        //Shield objekt von Children holen (Hirachy)
        transform.GetChild(0).gameObject.SetActive(false);
        isDeactivated = true;
    }
}
