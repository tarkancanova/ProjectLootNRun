using Cinemachine;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Animator _animator;
    [SerializeField] GameObject player;
    [SerializeField] Camera cam;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravityValue = -9.81f;
    private InputManager _inputManager;
    private bool notSliding = true;
    private bool isWallRunning = false;
    private List<Vector3> _wallRunDirectionsToCheck = new() { Vector3.right, Vector3.forward + Vector3.right, Vector3.left, Vector3.left + Vector3.forward };
    private bool wallJumpPerformed = false;
    private GameObject[] itemList;
    private ItemRaycast itemRaycast;
    GameObject chestObject;
    ChestScript chestScript;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        _inputManager = InputManager.Instance;
        _animator = GetComponentInChildren<Animator>();
        chestObject = GameObject.Find("Chest");
        chestScript = chestObject.GetComponent<ChestScript>();

    }

    void Update()
    {
        PlayerMove();
        EnableWallRun();
        TakeItem();
        OpenChest();
    }


    private IEnumerator BackToOriginalSize()
    {
        yield return new WaitForSeconds(1f);
        playerSpeed = 6f;
        transform.localScale = Vector3.one;
        notSliding = true;
    }


    private void PlayerMove()
    {
        jumpHeight = 1.0f;
        controller.transform.rotation = new Quaternion(0, cam.transform.rotation.y, 0, cam.transform.rotation.w);
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            playerVelocity.y = 0f;
        }


        if (isWallRunning)
        {
            playerVelocity.z *= 2;
            playerVelocity.y = -0.5f;
            jumpHeight = 0.5f;
        }

        if (_inputManager != null)
        {
            Vector2 movement = _inputManager.GetPlayerMovement();
            Vector3 move = new(movement.x, 0f, movement.y);
            var lastMove = cam.transform.forward * move.z + cam.transform.right * move.x;
            lastMove.y = 0f;
            controller.Move(playerSpeed * Time.deltaTime * lastMove);

            if (_inputManager.PlayerJumped() && (groundedPlayer || isWallRunning) && !wallJumpPerformed)
            {
                if (isWallRunning)
                {
                    wallJumpPerformed = true;
                    StartCoroutine(WallJumpCooldown());
                }
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -4.0f * gravityValue);
            }
        }



        playerVelocity.y += gravityValue * Time.deltaTime;


        controller.Move(playerVelocity * Time.deltaTime);


        SetAnimatorValues();

        notSliding = true;

        if (notSliding && Input.GetKey(KeyCode.LeftShift))
        {
            transform.localScale = Vector3.one * 0.5f;
            playerSpeed = playerSpeed * 2;
            notSliding = false;
            StartCoroutine(nameof(BackToOriginalSize));

        }
    }

    private void SetAnimatorValues()
    {
        if (_inputManager.GetPlayerMovement().x == 0 && _inputManager.GetPlayerMovement().y == 0)
        {
            _animator.SetFloat("Run", 0f);
        }

        else
        {
            _animator.SetFloat("Run", 1f);
        }
    }

    private void EnableWallRun()
    {

        isWallRunning = false;

        Vector3 wallRunRaycast = controller.transform.position;

        foreach (var direction in _wallRunDirectionsToCheck)
        {
            if (Physics.Raycast(wallRunRaycast, direction, 0.8f) && !groundedPlayer)
            {
                isWallRunning = true;
                
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Left Wall") && isWallRunning)
        {

        }

        else if (collision.gameObject.CompareTag("Right Wall") && isWallRunning)
        {

        }

        else
        {

        }
    }

    IEnumerator WallJumpCooldown()
    {
        yield return new WaitForSeconds(1f);
        wallJumpPerformed = false;
    }

    private void TakeItem()
    {
        itemList = GameObject.FindGameObjectsWithTag("Item");
        foreach (var item in itemList)
        {
            itemRaycast = item.GetComponent<ItemRaycast>();
            if (itemRaycast.playerCanTakeItem)
            {
                GameObject itemToTake = item;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    itemRaycast.playerCanTakeItem = false;
                }
            }
        }
    }
    
    public void OpenChest()
    {
        if (chestScript.chestCanBeOpened)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                chestScript.OpenChest();
            }
        }
    }
}
