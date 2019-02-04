using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour
{

    [SerializeField]
    private Transform healthBarRect;
    [SerializeField]
    private Text healthText;
    public Transform player;

    void Start()
    {
        
        if (healthBarRect == null)
        {
            Debug.LogError("STATUS INDICATOR: No health bar object referenced!");
        }
        if (healthText == null)
        {
            Debug.LogError("STATUS INDICATOR: No health text object referenced!");
        }
    }

    public void SetHealth(int _cur, int _max)
    {
        float _value = (float)_cur / _max;

        //healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y - player.localScale.y, healthBarRect.localScale.z - player.localScale.z);
        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.x, healthBarRect.localScale.y);
        //healthBarRect.localPosition = new Vector3(healthBarRect.localPosition.x, healthBarRect.localPosition.y + 180, healthBarRect.localPosition.z);
        //healthBarRect.localRotation = new Quaternion(healthBarRect.rotation.x, player.rotation.y*-1, healthBarRect.rotation.z, 1f);
        //healthBarRect.localRotation = new Quaternion(healthBarRect.localRotation.x - player.localRotation.x*-1, healthBarRect.localRotation.y - player.localRotation.y*-1, healthBarRect.localRotation.z - player.localRotation.z*-1, 1f);
        //healthBarRect.SetSize(_value);
        healthText.text = _cur + " /" + _max + " ";
    }

}
