using UnityEngine;
using TMPro;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private int _resources;
    [SerializeField] private TMP_Text _resourcesText;

    private static ResourceCounter _instance;

    public static ResourceCounter Instance
    {
        get => _instance;
    }

    private void Awake()
    {
        if (_instance!=null&&_instance!=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ReceiveResources(int resource)
    {
        _resources += resource;
        _resourcesText.text = _resources.ToString();
    }
}
