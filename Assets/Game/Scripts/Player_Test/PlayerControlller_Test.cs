using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller_Test : MonoBehaviour
{
    [SerializeField] float speed = 5f;                  // Karakterin hareket hýzý
    [SerializeField] Camera mainCamera;                // Ana kamera referansý
    [SerializeField] Animator animator;
    Vector3 inputVector;  // Hareket girdisi
    Rigidbody rb;         // Karakterin fiziksel hareketi için Rigidbody

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
        if (inputVector == Vector3.zero) animator.SetBool("isMoving", false);
        else animator.SetBool("isMoving", true);
        // Karakteri fare pozisyonuna göre döndür
        RotatePlayerToMousePosition();
    }

    private void FixedUpdate()
    {
        // Hareket fonksiyonunu fiziksel güncellemeye baðla
        Movement();
    }

    private void Movement()
    {
        // Kameranýn ileri yönünü al
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0; // Y eksenini sýfýrla, yalnýzca yatay düzlemde hareket

        // Kameranýn sað yönünü al
        Vector3 cameraRight = mainCamera.transform.right;
        cameraRight.y = 0; // Y eksenini sýfýrla, yalnýzca yatay düzlemde hareket

        // Karakterin hareket yönünü kamera yönüne göre hesapla
        Vector3 moveDirection = (cameraForward * inputVector.z + cameraRight * inputVector.x).normalized;

        // Hareket vektörünü uygula
        Vector3 moveVector = moveDirection * speed;

        rb.MovePosition(rb.position + moveVector * Time.fixedDeltaTime);
    }

    private void RotatePlayerToMousePosition()
    {
        // Fare pozisyonunu dünya uzayýna çevir
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.layer != 3)
            {
                // Hedef pozisyon (fare pozisyonu) ve mevcut pozisyon arasýndaki yön
                Vector3 targetDirection = (hit.point - transform.position).normalized;

                // Yükseklik farkýný sýfýrla (karakter sadece yatay eksende dönmeli)
                targetDirection.y = 0;

                // Hedef rotasyonu hemen uygula (yumuþak geçiþ yok)
                transform.rotation = Quaternion.LookRotation(targetDirection);
            }
        }

    }
}