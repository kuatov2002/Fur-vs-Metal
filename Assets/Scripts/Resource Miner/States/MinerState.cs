using UnityEngine;

public abstract class MinerState : MonoBehaviour
{
    [SerializeField] private MinerTransition[] _transitions;

    public void Enter()
    {
        if (!enabled)
        {
            enabled=true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if (enabled)
        {

            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
            enabled = false;
        }
    }

    public MinerState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedSwitch)
            {
                return transition.NexState;
            }
        }

        return null;
    }
}
