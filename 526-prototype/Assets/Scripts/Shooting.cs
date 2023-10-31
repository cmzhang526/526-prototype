using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private CharacterController2D cc;
    private PlayerController pc;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cc = gameObject.GetComponentInParent<CharacterController2D>();
        pc = gameObject.GetComponentInParent<PlayerController>();
        if (pc.currentShape == Shape.ShapeType.Triangle)
        {
            bulletTransform.gameObject.SetActive(true);
        }
        else
        {
            bulletTransform.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (pc.currentShape == Shape.ShapeType.Triangle)
        {
            if (!bulletTransform.gameObject.activeSelf)
            {
                bulletTransform.gameObject.SetActive(true);
            }

            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 rotation = mousePos - transform.position;

            if (!cc.m_FacingRight)
            {
                rotation = -rotation;
            }

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }

            if (Input.GetMouseButtonDown(0) && canFire)
            {
                canFire = false;
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            }
        }
        else
        {
            if (bulletTransform.gameObject.activeSelf)
            {
                bulletTransform.gameObject.SetActive(false);
            }
        }
    }
}
