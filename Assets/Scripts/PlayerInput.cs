using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{   
    [SerializeField] private GameObject cam;

    private PhotonView view;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
        playerMovement = GetComponent<PlayerMovement>();

        if (view.IsMine)
        {
            cam.SetActive(true);
        }
    }

    private void Update()
    {
        if (view.IsMine)
        {
            Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            bool jumpInput = Input.GetButtonDown("Jump");

            playerMovement.Move(transform.rotation * moveInput.normalized * Time.deltaTime);
            if (jumpInput)
                playerMovement.Jump();
            
        }
    }

    
}
