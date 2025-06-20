using UnityEngine;

public class InputButton : MonoBehaviour
{
    public static float HorizontalInput;

    public enum State
    {
        None,
        Left,
        Right
    }

    private State state = State.None;

    private void Update()
    {
        if (state == State.None)
        {
            HorizontalInput = 0f;
        }
        else if (state == State.Left)
        {
            HorizontalInput = -1f;
        }
        else if (state == State.Right)
        {
            HorizontalInput = 1f;
        }
    }

    public void OnMoveLeftButtonPressed()
    {
        state = State.Left;
    }

    public void OnMoveLeftButtonUp()
    {
        if (state == State.Left)
        {
            state = State.None;
        }
    }

    public void OnMoveRightButtonPressed()
    {
        state = State.Right;
    }

    public void OnMoveRightButtonUp()
    {
        if (state == State.Right)
        {
            state = State.None;
        }
    }
}
