using UnityEngine;

public class MinerTransition : MonoBehaviour
{
    [SerializeField]private MinerState _nexState;
    public bool NeedSwitch { get; protected set; }
    public MinerState NexState { get=>_nexState;}

    private void OnEnable()
    {
        NeedSwitch = false;
    }
}
