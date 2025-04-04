using System;
using HorrorGame.NPC;
using HorrorGame.Weapon;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace HorrorGame.Player
{
  [RequireComponent(typeof(CharacterController))]
  public class PlayerController : MonoBehaviour
  {
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float mouseRotationSpeed = 5f;
    [SerializeField, Range(1, 5f)] private float jumpValue = 2f;
    [SerializeField] private int maxHoldingWeapon = 3;
    [SerializeField] private Transform hand;
    //[SerializeField] private Gun gun;
    //[SerializeField] private NPCController nPCController;
    private Vector3 movementInputValue = Vector2.zero;
    private Vector2 mouseDelta = Vector2.zero;
    private Transform cameraTransform => Camera.main.transform;
    private float mouseDeltaY = 0f;
    private WeaponController weaponController;
    private InventoryController inventoryController;
    private bool isSprinting = false;
    private bool isJumping = false;
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
      weaponController = new WeaponController();
      inventoryController = new InventoryController(maxHoldingWeapon, weaponController);
      inventoryController.Attach += AttachWeapon;
      inventoryController.Detach += DetachWeapon;
      //weaponController.SetCurrentHoldingWeapon(gun);
      //nPCController.OnPlayerDead += PlayerIsDead;
    }
    void Update()
    {
      CheckForGroundAndJump();
      Move();
      Rotate();
    }
    private void PlayerIsDead()
    {
      print("NPC dead called from player");
    }

    private void AttachWeapon(Transform weaponTransform){
      weaponTransform.SetParent(hand);
      weaponTransform.localPosition = Vector3.zero;
      weaponTransform.localRotation = Quaternion.identity;
      weaponTransform.localScale = Vector3.one;
    }

    private void DetachWeapon(Transform weaponTransform){
      weaponTransform.SetParent(null);
    }
    private void CheckForGroundAndJump()
    {
      if (characterController.isGrounded)
      {
        if (isJumping)
        {
          movementInputValue.y = jumpValue;
          isJumping = false;
        }
        return;
      }
      movementInputValue.y += Physics.gravity.y * Time.deltaTime;
    }

    private void Move()
    {
      Vector3 moveVal = transform.TransformDirection(movementInputValue);
      characterController.Move(moveVal * Time.deltaTime * speed * (isSprinting ? 1.5f : 1));
    }

    private void Rotate()
    {
      transform.Rotate(0, mouseDelta.x, 0);
      mouseDeltaY -= mouseDelta.y;
      mouseDeltaY = Mathf.Clamp(mouseDeltaY, -60, 60);
      cameraTransform.localRotation = Quaternion.Euler(mouseDeltaY, 0, 0);
    }

    private void UseWeapon()
    {
      weaponController.Shoot();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
      if(hit.gameObject.TryGetComponent<AbstractWeapon>(out AbstractWeapon weapon)){
        inventoryController.Pick(weapon);
      }
    }

    private void OnMovement(InputValue inputValue)
    {
      Vector2 value = inputValue.Get<Vector2>();
      movementInputValue = new Vector3(value.x, 0, value.y);
    }

    private void OnMouseDelta(InputValue inputValue)
    {
      mouseDelta = inputValue.Get<Vector2>();
      mouseDelta = mouseDelta * Time.deltaTime * mouseRotationSpeed;
    }

    private void OnShoot()
    {
      UseWeapon();
    }

    private void OnSprint() => isSprinting = !isSprinting;
    private void OnJump() => isJumping = true;

    void OnDestroy()
    {
      inventoryController.Attach -= AttachWeapon;
      inventoryController.Detach -= DetachWeapon;
      //nPCController.OnPlayerDead -= PlayerIsDead;
    }

    void OnValidate()
    {
      //Assert.IsNotNull(nPCController, "npc controller is null");
    }
  }

}
