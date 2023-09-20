using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D flame;
    public float torchLife = 5.0f;
    public float remainingLife = 5.0f;

    public enum TorchState
    {
        Lit,
        Unlit
    }

    public TorchState state = TorchState.Lit;

    void Start()
    {
        enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(state == TorchState.Lit)
        {
            flame.intensity = Mathf.Lerp(0, 1, Mathf.Clamp(remainingLife / torchLife, 0, 1));

            remainingLife -= Time.deltaTime;
        }

        if(remainingLife < 0f)
        {
            state = TorchState.Unlit;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !enabled)
        {
            Debug.Log("Collecting torch");
            enabled = true;

            gameObject.transform.SetParent(col.gameObject.transform);
            gameObject.transform.localPosition = new Vector3(.3f, .1f, 0f);
        }
        if(col.gameObject.tag == "Sconce")
        {
            remainingLife = torchLife;
        }
    }
    public void ResetTorch()
    {
        Debug.Log("Resetting Torch");
        remainingLife = torchLife;
        Debug.Log(state);
        state = TorchState.Lit;
        Debug.Log(state);
        flame.intensity = 1;
    }
}
