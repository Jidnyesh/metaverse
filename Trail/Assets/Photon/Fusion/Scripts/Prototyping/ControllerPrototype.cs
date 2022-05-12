
using UnityEngine;
using Fusion;
[RequireComponent(typeof(Animator))]
[ScriptHelp(BackColor = EditorHeaderBackColor.Steel)]
public class ControllerPrototype : Fusion.NetworkBehaviour
{
    protected NetworkCharacterControllerPrototype _ncc;
    protected NetworkRigidbody _nrb;
    protected NetworkRigidbody2D _nrb2d;
    protected NetworkTransform _nt;

    [Networked]
    public Vector3 MovementDirection { get; set; }
    public Animator m_Animator;
    public bool TransformLocal = false;
    public Transform m_Camera;
    [DrawIf(nameof(ShowSpeed), DrawIfHideType.Hide, DoIfCompareOperator.NotEqual)]
    public float Speed = 6f;

    bool HasNCC => GetComponent<NetworkCharacterControllerPrototype>();

    bool ShowSpeed => this && !TryGetComponent<NetworkCharacterControllerPrototype>(out _);

    public void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        //PlayerPrefs.SetString("type", "NONE");
        CharacterController per = GetComponent<CharacterController>();
        if (PlayerPrefs.GetInt("play")==1)
        {
            per.center = new Vector3(0, 1.17f, 0);
            m_Animator.SetInteger("Sit", 1);
            PlayerPrefs.SetInt("play",0);
        }
        

    }

    public void Update()
    {
        Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, m_Camera.transform.eulerAngles.y, transform.eulerAngles.z);
        //Vector3 eulerRotatio = new Vector3(0, m_Camera.transform.rotation.y,0);
        transform.rotation = Quaternion.Euler(eulerRotation);
        




        //transform.rotation = m_Camera.transform.rotation;
        //Vector3 nr = m_Camera.eulerAngles;
        //nr.y = m_Camera.eulerAngles.y;
        //transform.eulerAngles = nr;
    }

    public void Awake()
    {
        CacheComponents();
    }

    public override void Spawned()
    {
        CacheComponents();
    }

    private void CacheComponents()
    {
        if (!_ncc) _ncc = GetComponent<NetworkCharacterControllerPrototype>();
        if (!_nrb) _nrb = GetComponent<NetworkRigidbody>();
        if (!_nrb2d) _nrb2d = GetComponent<NetworkRigidbody2D>();
        if (!_nt) _nt = GetComponent<NetworkTransform>();
    }

    public override void FixedUpdateNetwork()
    {
        
        if (Runner.Config.PhysicsEngine == NetworkProjectConfig.PhysicsEngines.None)
        {
            return;
        }

        Vector3 direction;
        if (GetInput(out NetworkInputPrototype input))
        {
            direction = default;

            

            if (input.IsUp(NetworkInputPrototype.FOR_UP) || input.IsUp(NetworkInputPrototype.BACK_UP) || input.IsUp(NetworkInputPrototype.LEFT_UP) || input.IsUp(NetworkInputPrototype.RIGHT_UP))
            {
                m_Animator.SetFloat("Forward", 0, 0.1f, Time.deltaTime);

            }

            if (input.IsDown(NetworkInputPrototype.BUTTON_BACKWARD) || input.IsDown(NetworkInputPrototype.MOUSE))
            {
                //direction += TransformLocal ? transform.forward : Vector3.forward;
                m_Animator.SetFloat("Forward", 1, 0.1f, Time.deltaTime);
            }
            
            if (input.IsDown(NetworkInputPrototype.HAND))
            {
                m_Animator.SetInteger("hand", 1);
            }
            if (input.IsDown(NetworkInputPrototype.HANDUP))
            {
                m_Animator.SetInteger("hand", 0);
            }


           

            

            direction = direction.normalized;
            //MovementDirection = m_Camera.transform.rotation * direction;
            //MovementDirection = direction;

            if (input.IsDown(NetworkInputPrototype.BUTTON_JUMP))
            {
                if (_ncc)
                {
                    _ncc.Jump();
                }
                else
                {
                    direction += (TransformLocal ? transform.up : Vector3.up);
                }
            }
        }
        else
        {
            direction = MovementDirection;
        }

        
        if (_ncc)
        {
            _ncc.Move(direction);
        }
        else if (_nrb && !_nrb.Rigidbody.isKinematic)
        {
            _nrb.Rigidbody.AddForce(direction * Speed);
        }
        else if (_nrb2d && !_nrb2d.Rigidbody.isKinematic)
        {
            Vector2 direction2d = new Vector2(direction.x, direction.y + direction.z);
            _nrb2d.Rigidbody.AddForce(direction2d * Speed);
        }
        else
        {
            transform.position += (direction * Speed * Runner.DeltaTime);
        }
    }
}