using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchGlow : MonoBehaviour
{
    [SerializeField]
    public float blinckSpeed;

    [SerializeField]
    public float minAlpha;

    [SerializeField]
    public Image LightImg;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UIBlinck(LightImg);
    }

    private void UIBlinck(Image img)
    {
        float _a = Mathf.Lerp(minAlpha, 1f, Mathf.PingPong(Time.time * blinckSpeed, 1));
        Color c = img.color;
        c.a = _a;
        img.color = c;
    }
}
