using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasitKamera : MonoBehaviour
{
    [SerializeField]
    float sens = 120f;

    public GameObject oyuncuAna;

    float xEkseni = 0f;

    public bool isCursorLocked = true;

    // Start is called before the first frame update
    private void Awake()
    {
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        xEkseni -= mouseY;
        xEkseni = Mathf.Clamp(xEkseni, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xEkseni, 0f, 0f);

        oyuncuAna.transform.Rotate(Vector3.up * mouseX);
        

    }


}
