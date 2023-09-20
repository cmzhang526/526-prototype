using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sconce : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D flameLight;

    enum SconceState
    {
        Lit,
        Unlit
    }

    [SerializeField] SconceState state = SconceState.Lit;

    // Start is called before the first frame update
    void Start()
    {
        if (state == SconceState.Lit)
        {
            flameLight.enabled = true;
        }
        else
        {
            flameLight.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(state == SconceState.Lit)
        {
            if(col.gameObject.tag == "Torch")
            {
                Debug.Log("Colliding with Torch");
                Torch torch = col.gameObject.GetComponent<Torch>();
                torch.ResetTorch();
            }
        }
    }
}