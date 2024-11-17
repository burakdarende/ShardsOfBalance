using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller_Test : MonoBehaviour
{
    [SerializeField] float speed = 5f;                  // Karakterin hareket h�z�
    [SerializeField] Camera mainCamera;                // Ana kamera referans�

    Vector3 inputVector;  // Hareket girdisi
    Rigidbody rb;         // Karakterin fiziksel hareketi i�in Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.freezeRotation = true;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        Cursor.lockState = CursorLockMode.None; // Fare serbest
    }

    void Update()
    {
        // Hareket girdisini al
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Karakteri fare pozisyonuna g�re d�nd�r
        RotatePlayerToMousePosition();
    }

    private void FixedUpdate()
    {
        // Hareket fonksiyonunu fiziksel g�ncellemeye ba�la
        Movement();
    }

    private void Movement()
    {
        // Karakterin bak�� y�n�ne g�re hareket y�n�n� hesapla
        Vector3 moveDirection = (transform.forward * inputVector.z + transform.right * inputVector.x).normalized;

        // Hareket vekt�r�n� uygula
        Vector3 moveVector = moveDirection * speed;

        rb.MovePosition(rb.position + moveVector * Time.fixedDeltaTime);
    }

    private void RotatePlayerToMousePosition()
    {
        // Fare pozisyonunu d�nya uzay�na �evir
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                // Hedef pozisyon (fare pozisyonu) ve mevcut pozisyon aras�ndaki y�n
                Vector3 targetDirection = (hit.point - transform.position).normalized;

                // Y�kseklik fark�n� s�f�rla (karakter sadece yatay eksende d�nmeli)
                targetDirection.y = 0;

                // Hedef rotasyonu hemen uygula (yumu�ak ge�i� yok)
                transform.rotation = Quaternion.LookRotation(targetDirection);
            }
            
        }
    }
}
