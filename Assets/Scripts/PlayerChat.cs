using System;
using System.Collections;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerChat : NetworkBehaviour
{
    [SerializeField] private GameObject mInputField;
    [SerializeField] private GameObject mChatText;

 

    private bool _isChatting;

    private NetworkVariable<FixedString128Bytes> _chatText = new NetworkVariable<FixedString128Bytes>(writePerm: NetworkVariableWritePermission.Owner, readPerm: NetworkVariableReadPermission.Everyone);

    private float _timer;
    private bool _startTimer;
    

    #region Unity Methods
    
    void Update()
    {
        if (!IsOwner) return;
        
         HandleInput();
         UpdateTimer();
    }
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        _chatText.OnValueChanged += OnChatTextChanged;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        _chatText.OnValueChanged -= OnChatTextChanged;
    }
    #endregion

    #region Input Handling
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!_isChatting)
            {
                PlayerStateHandling.Instance.SetState(PlayerStateHandling.PlayerState.Chatting);
                _isChatting = true;
                OpenInputField();
            }
            else
            {
                PlayerStateHandling.Instance.SetState(PlayerStateHandling.PlayerState.Moving);
                _isChatting = false;
                SubmitChatText(_chatText.Value.ToString());
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerStateHandling.Instance.SetState(PlayerStateHandling.PlayerState.Moving);
            _isChatting = false;
            mInputField.SetActive(false);
            mChatText.SetActive(false);
        }
    }
    private void ReadStringInput(string s)
    {
        SubmitChatText(s);
    }

    #endregion
    
    #region UI Methods
    private void OpenInputField()
    {
        mInputField.SetActive(true);
        mChatText.SetActive(false);


        var inputField = mInputField.GetComponent<TMP_InputField>();
        inputField.onEndEdit.RemoveListener(ReadStringInput);
        inputField.onEndEdit.AddListener(ReadStringInput);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mInputField.gameObject);
           
    }

    private void ShowText(string s)
    {
        mInputField.SetActive(false);
        mChatText.SetActive(true);
        mChatText.GetComponent<TextMeshProUGUI>().text = s;

        _startTimer = true;
        _timer = 0;
    }
    #endregion

    #region Timer Methods

    private void UpdateTimer()
    {
        if (_startTimer)
        {
            _timer += Time.deltaTime;
            if (_timer >= 3)
            {
                _timer = 0;
                _startTimer = false;
                HideChatTextServerRpc();
            }
        }
    }

    #endregion
    
    #region Network Methods
    private void SubmitChatText(string newText)
    {
        if (IsOwner)
        {
            _chatText.Value = new FixedString128Bytes(newText);
            ShowText(newText);
        }
    }
    [ServerRpc]
    private void HideChatTextServerRpc()
    {
        if (IsServer)
        {
            HideChatTextClientRpc();
        }
    }
    
    [ClientRpc]
    private void HideChatTextClientRpc()
    {
       
             mChatText.SetActive(false);
        
    }


    private void OnChatTextChanged(FixedString128Bytes oldValue, FixedString128Bytes newValue)
    {
        ShowText(newValue.ToString());
    }

 
    #endregion
}
